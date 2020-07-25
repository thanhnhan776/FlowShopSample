using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMinCMax.Input;
using NPOI.SS.UserModel;

namespace FindMinCMax.Utils
{
    public static class DataProcessingUtils
    {
        public static int[][] ClonedInstance(this IEnumerable<int[]> array)
        {
            return array.Select(row => row.ClonedInstance()).ToArray();
        }

        public static int[] ClonedInstance(this IEnumerable<int> array)
        {
            return array.Select(cell => cell).ToArray();
        }

        public static int ToInt(this string value, int defaultValue = 0)
        {
            return int.TryParse(value, out var intValue) ? intValue : defaultValue;
        }

        public static int GetCellIntValue(this ISheet sheet, WorkbookCell cellIndex, int defaultValue = 0)
        {
            var cell = sheet.GetRow(cellIndex.RowIndex).GetCell(cellIndex.ColIndex);
            return cell.CellType != CellType.Blank
                ? (int) cell.NumericCellValue
                : defaultValue;
        }
    }
}
