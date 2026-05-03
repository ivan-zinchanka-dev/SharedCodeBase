using System.Data;
using JanZi.Csv.Reading;
using JanZi.Csv.Tests.Data;
using JanZi.Csv.Tests.Data.Base;
using JanZi.Csv.Tests.Utilities;

namespace JanZi.Csv.Tests.Reading;

[TestClass]
public class CsvFileReaderTest
{
    private static IEnumerable<object[]> TestCases { get; } = new[]
    {
        new object[] { new ScoresMockData().TestCase },
        new object[] { new EmployeesMockData().TestCase },
        new object[] { new ProductsMockData().TestCase }
    };
    
    [TestMethod]
    [DynamicData(nameof(TestCases))]
    public void ShouldReadCorrectly(CsvTestCase testCase)
    {
        string filePath = Path.Combine(Config.InputDirectory, $"Sync_{testCase.Name}.csv");
        
        var fileReader = new CsvFileReader();
        DataTable data = fileReader.Read(filePath);

        bool areEquals = DataTableUtility.AreEqual(testCase.Data, data);
        Assert.IsTrue(areEquals);
    }
    
    [TestMethod]
    [DynamicData(nameof(TestCases))]
    public async Task ShouldReadAsyncCorrectly(CsvTestCase testCase)
    {
        string filePath = Path.Combine(Config.InputDirectory, $"Async_{testCase.Name}.csv");
        
        var fileReader = new CsvFileReader();
        DataTable data = await fileReader.ReadAsync(filePath);
        
        bool areEquals = DataTableUtility.AreEqual(testCase.Data, data);
        Assert.IsTrue(areEquals);
    }
}