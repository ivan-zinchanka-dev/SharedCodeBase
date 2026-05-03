using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace JanZi.Csv.Writing
{
    public class CsvFileWriter
    {
        private readonly CsvWriter _csvWriter = new CsvWriter();
        
        public void Write(string filePath, DataTable data, bool append = false)
        {
            bool writeHeaders = MustWriteHeaders(filePath, append);
        
            using (var writer = new StreamWriter(filePath, append))
            {
                _csvWriter.Write(writer, data, writeHeaders);
            }
        }
    
        public async Task WriteAsync(string filePath, DataTable data, bool append = false)
        {
            bool writeHeaders = MustWriteHeaders(filePath, append);
        
            using (var writer = new StreamWriter(filePath, append))
            {
                await _csvWriter.WriteAsync(writer, data, writeHeaders);
            }
        }
        
        private static bool MustWriteHeaders(string filePath, bool append)
        {
            if (append)
            {
                var file = new FileInfo(filePath);
                return !(file.Exists && file.Length > 0);
            }
            else
            {
                return true;
            }
        }
    }
}