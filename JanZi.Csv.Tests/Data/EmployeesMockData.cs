using System.Data;
using JanZi.Csv.Tests.Data.Base;

namespace JanZi.Csv.Tests.Data;

public class EmployeesMockData : ICsvMockData
{
    public CsvTestCase TestCase => new()
    {
        Name = "Employees",
        Data = CreateEmployeesTable(),
        CsvNotation = CreateEmployeesCsvNotation(),
    };
    
    private static DataTable CreateEmployeesTable()
    {
        var table = new DataTable("EmployeesTable");
        
        table.Columns.Add("Id", typeof(int));
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("Age", typeof(int));
        table.Columns.Add("Email", typeof(string));
        table.Columns.Add("Salary", typeof(decimal));
        table.Columns.Add("HireDate", typeof(DateTime));
        table.Columns.Add("IsActive", typeof(bool));
        
        table.Rows.Add(1, "John Doe", 30, "john.doe@example.com", 50000m, new DateTime(2020, 1, 15), true);
        table.Rows.Add(2, "Jane Smith", 25, "jane.smith@example.com", 60000m, new DateTime(2021, 3, 20), true);
        table.Rows.Add(3, "Bob Johnson", 40, "bob.johnson@example.com", 75000m, new DateTime(2019, 6, 10), false);
        table.Rows.Add(4, "Alice Brown", 35, null, 55000m, new DateTime(2020, 11, 5), true);
        table.Rows.Add(5, "Charlie Wilson", 28, "charlie@example.com", 48000m, new DateTime(2022, 8, 1), true);
        table.Rows.Add(6, "Eva Davis", 32, "eva.davis@example.com", 62000m, new DateTime(2021, 12, 12), false);
    
        return table;
    }
    
    private static string CreateEmployeesCsvNotation()
    {
        return "\"Id\",\"Name\",\"Age\",\"Email\",\"Salary\",\"HireDate\",\"IsActive\"\r\n" +
               "\"1\",\"John Doe\",\"30\",\"john.doe@example.com\",\"50000\",\"15.01.2020 00:00:00\",\"True\"\r\n" +
               "\"2\",\"Jane Smith\",\"25\",\"jane.smith@example.com\",\"60000\",\"20.03.2021 00:00:00\",\"True\"\r\n" +
               "\"3\",\"Bob Johnson\",\"40\",\"bob.johnson@example.com\",\"75000\",\"10.06.2019 00:00:00\",\"False\"\r\n" +
               "\"4\",\"Alice Brown\",\"35\",\"\",\"55000\",\"05.11.2020 00:00:00\",\"True\"\r\n" +
               "\"5\",\"Charlie Wilson\",\"28\",\"charlie@example.com\",\"48000\",\"01.08.2022 00:00:00\",\"True\"\r\n" +
               "\"6\",\"Eva Davis\",\"32\",\"eva.davis@example.com\",\"62000\",\"12.12.2021 00:00:00\",\"False\"\r\n";
    }
}