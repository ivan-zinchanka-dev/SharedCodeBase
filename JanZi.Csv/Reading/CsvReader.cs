using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JanZi.Csv.Reading
{
    public class CsvReader
    {
        private const char Separator = ',';
        private const string RegexPattern = ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";
        
        public DataTable Read(TextReader textReader)
        {
            var data = new DataTable();
            var line = textReader.ReadLine();

            if (line != null)
            {
                ReadHeaders(line, data.Columns);
            }

            while ((line = textReader.ReadLine()) != null)
            {
                ReadFields(line, data.Rows);
            }

            return data;
        }
        
        public async Task<DataTable> ReadAsync(TextReader textReader)
        {
            var data = new DataTable();
            var line = await textReader.ReadLineAsync();

            if (line != null)
            {
                ReadHeaders(line, data.Columns);
            }

            while ((line = await textReader.ReadLineAsync()) != null)
            {
                ReadFields(line, data.Rows);
            }

            return data;
        }
        
        private static void ReadHeaders(string line, DataColumnCollection dataColumns)
        {
            string[] headers = RemoveDoubledInnerQuotesIfNeed(
                RemoveOuterQuotes(line.Split(Separator)));

            foreach (string header in headers)
            {
                dataColumns.Add(header);
            }
        }

        private static void ReadFields(string line, DataRowCollection dataRows)
        {
            string[] fields = RemoveDoubledInnerQuotesIfNeed(
                RemoveOuterQuotes(Regex.Split(line, RegexPattern)));
            dataRows.Add(fields);
        }
        
        private static string[] RemoveOuterQuotes(string[] sources)
        {
            return sources.Select(RemoveOuterQuotes).ToArray();
        }
        
        private static string RemoveOuterQuotes(string source)
        {
            return source.Trim('"');
        }
        
        private static string[] RemoveDoubledInnerQuotesIfNeed(string[] sources)
        {
            return sources.Select(RemoveDoubledInnerQuotesIfNeed).ToArray();
        }
        
        private static string RemoveDoubledInnerQuotesIfNeed(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new StringBuilder(source.Length);
            bool lastWasQuote = false;
            
            foreach (char c in source)
            {
                if (c == '"' && lastWasQuote)
                {
                    lastWasQuote = false;
                }
                else
                {
                    result.Append(c);
                    lastWasQuote = (c == '"');
                }
            }

            return result.ToString();
        }
    }
}