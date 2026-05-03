using System.Data;

namespace JanZi.Csv.Tests.Data.Base;

public class CsvTestCase
{
    public DataTable SourceData { get; set; }
    public string ExpectedNotation { get; set; }
}