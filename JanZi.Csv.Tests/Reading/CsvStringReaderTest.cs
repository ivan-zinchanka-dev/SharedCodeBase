using System.Data;
using JanZi.Csv.Reading;
using JanZi.Csv.Tests.Data;
using JanZi.Csv.Tests.Data.Base;
using JanZi.Csv.Tests.Utilities;

namespace JanZi.Csv.Tests.Reading;

[TestClass]
public sealed class CsvStringReaderTest
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
        var stringReader = new CsvStringReader();
        DataTable data = stringReader.Read(testCase.CsvNotation);

        bool areEquals = DataTableUtility.AreEqual(testCase.Data, data);
        Assert.IsTrue(areEquals);
    }
    
    [TestMethod]
    [DynamicData(nameof(TestCases))]
    public async Task ShouldReadAsyncCorrectly(CsvTestCase testCase)
    {
        var stringReader = new CsvStringReader();
        DataTable data = await stringReader.ReadAsync(testCase.CsvNotation);
        
        bool areEquals = DataTableUtility.AreEqual(testCase.Data, data);
        Assert.IsTrue(areEquals);
    }
}