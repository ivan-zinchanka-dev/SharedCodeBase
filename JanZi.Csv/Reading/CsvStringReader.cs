using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace JanZi.Csv.Reading
{
    public class CsvStringReader
    {
        private readonly CsvReader _csvReader = new CsvReader();
        
        public DataTable Read(string text)
        {
            using (var reader = new StringReader(text))
            {
                return _csvReader.Read(reader);
            }
        }
        
        public async Task<DataTable> ReadAsync(string text)
        {
            using (var reader = new StringReader(text))
            {
                return await _csvReader.ReadAsync(reader);
            }
        }
    }
}