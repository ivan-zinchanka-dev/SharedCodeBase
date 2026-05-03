using System.Data;
using JanZi.Csv.Tests.Data.Base;

namespace JanZi.Csv.Tests.Data;

public class ProductsMockData : ICsvMockData
{
    public CsvTestCase TestCase => new()
    {
        Name = "Products",
        Data = CreateProductsTable(),
        CsvNotation = CreateProductsCsvNotation(),
    };
    
    private static DataTable CreateProductsTable()
    {
        var table = new DataTable("ProductsTable");
        
        table.Columns.Add("ProductId", typeof(int));
        table.Columns.Add("ProductName", typeof(string));
        table.Columns.Add("Category", typeof(string));
        table.Columns.Add("Price", typeof(decimal));
        table.Columns.Add("InStock", typeof(bool));
        table.Columns.Add("LastUpdated", typeof(DateTime));
        
        // Данные те же самые
        table.Rows.Add(101, "Laptop", "Electronics", 999.99m, true, new DateTime(2024, 1, 10));
        table.Rows.Add(102, "Mouse", "Electronics", 25.50m, true, new DateTime(2024, 1, 15));
        table.Rows.Add(103, "Keyboard", "Electronics", 75.00m, false, new DateTime(2024, 1, 5));
        table.Rows.Add(104, "Notebook", "Stationery", 3.99m, true, new DateTime(2024, 1, 20));
        table.Rows.Add(105, "Pen", "Stationery", 1.50m, true, new DateTime(2024, 1, 18));
        table.Rows.Add(106, "Desk", "Furniture", 299.99m, false, new DateTime(2023, 12, 1));
        
        return table;
    }
    
    private static string CreateProductsCsvNotation()
    {
        // Строка в точности как в EmployeesMockData:
        // - кавычки вокруг всех полей
        // - даты в формате "dd.MM.yyyy HH:mm:ss"
        // - десятичные числа с точкой (как в "999.99")
        // - в конце каждой строки \r\n, включая последнюю
        return "\"ProductId\",\"ProductName\",\"Category\",\"Price\",\"InStock\",\"LastUpdated\"\r\n" +
               "\"101\",\"Laptop\",\"Electronics\",\"999,99\",\"True\",\"10.01.2024 00:00:00\"\r\n" +
               "\"102\",\"Mouse\",\"Electronics\",\"25,50\",\"True\",\"15.01.2024 00:00:00\"\r\n" +
               "\"103\",\"Keyboard\",\"Electronics\",\"75,00\",\"False\",\"05.01.2024 00:00:00\"\r\n" +
               "\"104\",\"Notebook\",\"Stationery\",\"3,99\",\"True\",\"20.01.2024 00:00:00\"\r\n" +
               "\"105\",\"Pen\",\"Stationery\",\"1,50\",\"True\",\"18.01.2024 00:00:00\"\r\n" +
               "\"106\",\"Desk\",\"Furniture\",\"299,99\",\"False\",\"01.12.2023 00:00:00\"\r\n";
    }
}