using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanZi.Csv.Writing
{
    public class CsvWriter
    {
        private const string Separator = ",";
    
        public void Write(TextWriter textWriter, DataTable data, bool writeHeaders = true)
        {
            if (writeHeaders)
            {
                textWriter.WriteLine(GetHeaderLine(data.Columns));
            }
                
            for (int i = 0; i < data.Rows.Count; i++)
            {
                textWriter.WriteLine(GetFieldLine(data.Rows[i], data.Columns.Count));
            }
        }
        
        public async Task WriteAsync(TextWriter textWriter, DataTable data, bool writeHeaders = true)
        {
            if (writeHeaders)
            {
                await textWriter.WriteLineAsync(GetHeaderLine(data.Columns));
            }
             
            for (int i = 0; i < data.Rows.Count; i++)
            {
                await textWriter.WriteLineAsync(GetFieldLine(data.Rows[i], data.Columns.Count));
            }
        }

        private static string GetHeaderLine(DataColumnCollection columns)
        {
            return string.Join(Separator, AddOuterQuotes(
                DoubleInnerQuotesIfNeed(GetHeaders(columns))));
        }

        private static string GetFieldLine(DataRow row, int columnsCount)
        {
            return string.Join(Separator, AddOuterQuotes(
                DoubleInnerQuotesIfNeed(GetFields(row, columnsCount))));
        }
        
        private static string[] GetHeaders(DataColumnCollection dataColumns)
        {
            var headers = new string[dataColumns.Count];

            for (int i = 0; i < headers.Length; i++)
            {
                headers[i] = dataColumns[i].ColumnName;
            }

            return headers;
        }
        
        private static string[] GetFields(DataRow dataRow, int columnsCount)
        {
            var fields = new string[columnsCount];

            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = dataRow[i].ToString();
            }
            
            return fields;
        }

        private static string[] AddOuterQuotes(string[] sources)
        {
            return sources.Select(AddOuterQuotes).ToArray();
        }
        
        private static string AddOuterQuotes(string source)
        {
            return $"\"{source}\"";
        }

        private static string[] DoubleInnerQuotesIfNeed(string[] sources)
        {
            return sources.Select(DoubleInnerQuotesIfNeed).ToArray();
        }

        private static string DoubleInnerQuotesIfNeed(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new StringBuilder(source.Length);
            
            foreach (char c in source)
            {
                result.Append(c);
                
                if (c == '"')
                {
                    result.Append('"');
                }
            }

            return result.ToString();
        }
    }
}