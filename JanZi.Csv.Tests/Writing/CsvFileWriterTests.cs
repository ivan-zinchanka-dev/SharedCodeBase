using JanZi.Csv.Tests.Data;
using JanZi.Csv.Tests.Data.Base;
using JanZi.Csv.Writing;

namespace JanZi.Csv.Tests.Writing;

[TestClass]
public sealed class CsvFileWriterTests
{
    private static IEnumerable<object[]> TestCases { get; } = new[]
    {
        new object[] { new ScoresMockData().TestCase },
        new object[] { new EmployeesMockData().TestCase },
        new object[] { new ProductsMockData().TestCase }
    };
    
    [TestMethod]
    [DynamicData(nameof(TestCases))]
    public void ShouldWriteCorrectly(CsvTestCase testCase)
    {
        string filePath = Path.Combine(Config.OutputDirectory, $"Sync_{testCase.Name}.csv");
        
        var fileWriter = new CsvFileWriter();
        fileWriter.Write(filePath, testCase.Data);

        string csvNotation = File.ReadAllText(filePath);
        Console.WriteLine(csvNotation);
        
        Assert.AreEqual(testCase.CsvNotation, csvNotation);
    }
    
    [TestMethod]
    [DynamicData(nameof(TestCases))]
    public async Task ShouldWriteAsyncCorrectly(CsvTestCase testCase)
    {
        string filePath = Path.Combine(Config.OutputDirectory, $"Async_{testCase.Name}.csv");
        
        var fileWriter = new CsvFileWriter();
        await fileWriter.WriteAsync(filePath, testCase.Data);

        string csvNotation = await File.ReadAllTextAsync(filePath);
        Console.WriteLine(csvNotation);
        
        Assert.AreEqual(testCase.CsvNotation, csvNotation);
    }
}