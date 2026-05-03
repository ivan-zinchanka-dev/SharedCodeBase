using System.Data;
using JanZi.Csv.Tests.Data.Base;

namespace JanZi.Csv.Tests.Data;

public class ScoresMockData : ICsvMockData
{
    public CsvTestCase TestCase => new()
    {
        Name = "Scores",
        Data = CreateScoresTable(),
        CsvNotation = CreateScoresCsvNotation(),
    };
    
    private static DataTable CreateScoresTable()
    {
        var table = new DataTable("ScoresTable");
    
        table.Columns.Add("FirstName", typeof(string));
        table.Columns.Add("LastName", typeof(string));
        table.Columns.Add("Score", typeof(int));
    
        table.Rows.Add("Alice", "Smith", 95);
        table.Rows.Add("Bob", "Jones", 87);
        table.Rows.Add("Charlie", "Brown", 92);
        table.Rows.Add("Diana", "Prince", 100);
    
        return table;
    }

    private static string CreateScoresCsvNotation()
    {
        return "\"FirstName\",\"LastName\",\"Score\"\r\n" +
               "\"Alice\",\"Smith\",\"95\"\r\n" +
               "\"Bob\",\"Jones\",\"87\"\r\n" +
               "\"Charlie\",\"Brown\",\"92\"\r\n" +
               "\"Diana\",\"Prince\",\"100\"\r\n";
    }
}