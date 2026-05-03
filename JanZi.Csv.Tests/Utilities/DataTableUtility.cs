using System.Data;

namespace JanZi.Csv.Tests.Utilities;

public static class DataTableUtility
{
    public static bool AreEqual(DataTable left, DataTable right)
    {
        if (left == null && right == null)
        {
            return true;
        }
    
        if (left == null || right == null || 
            left.Rows.Count != right.Rows.Count || 
            left.Columns.Count != right.Columns.Count)
        {
            return false;
        }
    
        int rowsToCompare = Math.Min(left.Rows.Count, right.Rows.Count);
        int colsToCompare = Math.Min(left.Columns.Count, right.Columns.Count);
    
        for (int i = 0; i < rowsToCompare; i++)
        {
            for (int j = 0; j < colsToCompare; j++)
            {
                string leftValue = left.Rows[i][j]?.ToString() ?? string.Empty;
                string rightValue = right.Rows[i][j]?.ToString() ?? string.Empty;
            
                if (leftValue != rightValue)
                {
                    return false;
                }
            }
        }

        return true;
    }
}