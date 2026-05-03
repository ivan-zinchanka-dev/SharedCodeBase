using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace JanZi.Csv.Writing
{
    public class CsvStringWriter
    {
        private readonly CsvWriter _csvWriter = new CsvWriter();
        
        public string Write(DataTable data, bool append = false)
        {
            using (var writer = new StringWriter())
            {
                _csvWriter.Write(writer, data, !append);
                return writer.ToString();
            }
        }
    
        public async Task<string> WriteAsync(DataTable data, bool append = false)
        {
            using (var writer = new StringWriter())
            {
                await _csvWriter.WriteAsync(writer, data, !append);
                return writer.ToString();
            }
        }
    }
}