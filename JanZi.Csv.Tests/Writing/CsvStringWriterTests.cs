using System.Data;
using JanZi.Csv.Tests.Data;
using JanZi.Csv.Tests.Data.Base;
using JanZi.Csv.Writing;

namespace JanZi.Csv.Tests.Writing;

[TestClass]
public sealed class CsvStringWriterTests
{
    [TestMethod]
    [DynamicData(nameof(TestCases), DynamicDataSourceType.Property)]
    public void ShouldWriteCorrectly(CsvTestCase testCase)
    {
        var csvStringWriter = new CsvStringWriter();
        string csvNotation = csvStringWriter.Write(testCase.SourceData);
        Console.WriteLine(csvNotation);
        
        Assert.AreEqual(testCase.ExpectedNotation, csvNotation);
    }
    
    public static IEnumerable<object[]> TestCases { get; } = new[]
    {
        new object[] { new ScoresMockData().TestCase },
        new object[] { new EmployeesMockData().TestCase }
    };
}