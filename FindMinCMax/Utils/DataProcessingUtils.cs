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
        public static int[] ClonedInstance(this IEnumerable<int> array)
        {
            return array.Select(cell => cell).ToArray();
        }
        public static int[][] ClonedInstance(this IEnumerable<IEnumerable<int>> array)
        {
            return array.Select(row => row.ClonedInstance()).ToArray();
        }

        public static int[][][] ClonedInstance(this IEnumerable<IEnumerable<IEnumerable<int>>> array)
        {
            return array.Select(row => row.ClonedInstance()).ToArray();
        }

        public static int[][][][] ClonedInstance(this IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> array)
        {
            return array.Select(row => row.ClonedInstance()).ToArray();
        }

        public static int ToInt(this string value, int defaultValue = 0)
        {
            return int.TryParse(value, out var intValue) ? intValue : defaultValue;
        }

        public static int GetCellIntValue(this ISheet sheet, WorkbookCell cellIndex, int defaultValue = 0)
        {
            var cell = sheet.GetRow(cellIndex.RowIndex).GetCell(cellIndex.ColIndex);
            return cell != null && cell.CellType != CellType.Blank
                ? (int) cell.NumericCellValue
                : defaultValue;
        }

        public static int GetCellIntValue(this ISheet sheet, int rowIndex, int colIndex, int defaultValue = 0)
        {
            var cell = new WorkbookCell { RowIndex = rowIndex, ColIndex = colIndex };
            return GetCellIntValue(sheet, cell, defaultValue);
        }

        public static int[][] To2DArray(this List<List<int>> lists)
        {
            var listsCount = lists.Count;
            var array = new int[listsCount][];
            for (var i = 0; i < listsCount; ++i)
            {
                array[i] = lists[i].ToArray();
            }

            return array;
        }
    }
}
