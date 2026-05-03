using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace JanZi.Csv.Reading
{
    public class CsvFileReader
    {
        private readonly CsvReader _csvReader = new CsvReader();
        
        public DataTable Read(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                return _csvReader.Read(reader);
            }
        }
        
        public async Task<DataTable> ReadAsync(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                return await _csvReader.ReadAsync(reader);
            }
        }
    }
}