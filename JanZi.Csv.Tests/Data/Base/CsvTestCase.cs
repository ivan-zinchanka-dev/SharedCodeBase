using System.Data;

namespace JanZi.Csv.Tests.Data.Base;

public class CsvTestCase
{
    public string Name { get; set; }
    public DataTable Data { get; set; }
    public string CsvNotation { get; set; }

    public override string ToString() => Name;
}