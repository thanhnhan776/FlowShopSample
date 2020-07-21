using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinCMax.Utils
{
    public enum DisplayTypes
    {
        Machine,
        Eligibility,
        ProcessingTime,
        LagTime,
        SetupTime
    }
    public static class DisplayUtils
    {
        public static string DisplayText(this int[][] array, DisplayTypes type = DisplayTypes.Machine)
        {
            var display = "";
            var rowText = "";
            var cellText = "";
            switch (type)
            {
                case DisplayTypes.Machine:
                    rowText = "Stage";
                    cellText = "Machines";
                    break;
                default:
                    break;
            }

            for (var i = 0; i < array.Length; ++i)
            {
                display += $"{rowText} {i + 1:D2}: {cellText}: " +
                           $"{string.Join(", ", array[i].Select(cell => cell.ToString("D2")))}\r\n";
            }

            return display;
        }

        public static string DisplayText(this int[][][] array, DisplayTypes type)
        {
            var display = "";
            var rowText = "";
            var colText = "";
            var cellText = "";
            switch (type)
            {
                case DisplayTypes.Eligibility:
                    rowText = "Stage";
                    colText = "Job";
                    cellText = "Machines";
                    break;
                case DisplayTypes.ProcessingTime:
                case DisplayTypes.LagTime:
                    rowText = "Stage";
                    colText = "Machine";
                    cellText = "Jobs";
                    break;
                default:
                    break;
            }

            for (var i = 0; i < array.Length; ++i)
            {
                display += $"{rowText} {i + 1:D2}:\r\n";
                for (var j = 0; j < array[i].Length; ++j)
                {
                    var txtCells = array[i][j].Length > 0
                    ? string.Join(", ", array[i][j].Select(cell => cell.ToString("D2")))
                    : " -";
                    display += $"\t{colText} {j + 1:D2}: {cellText}: {txtCells}\r\n";
                }
            }

            return display;
        }

        public static string DisplayText(this int[][][][] array, DisplayTypes type = DisplayTypes.SetupTime)
        {
            var display = "";
            var rowText = "";
            var colText = "";
            var cellText = "";
            var cellInnerItemText = "";
            switch (type)
            {
                case DisplayTypes.SetupTime:
                    rowText = "Stage";
                    colText = "Machine";
                    cellText = "Preceded job";
                    cellInnerItemText = "Succeeded jobs";
                    break;
                default:
                    break;
            }

            for (var i = 0; i < array.Length; ++i)
            {
                display += $"{rowText} {i + 1:D2}:\r\n";
                for (var j = 0; j < array[i].Length; ++j)
                {
                    display += $"\t{colText} {j + 1:D2}:\r\n";
                    for (var k = 0; k < array[i][j].Length; ++k)
                    {
                        var txtCellInnerTexts = array[i][j][k].Length > 0
                            ? string.Join(", ",
                                array[i][j][k].Select(cell =>
                                    cell != -1 ? cell.ToString("D2") : " _"))
                            : " -";
                        display += $"\t\t{cellText} {k + 1:D2}: {cellInnerItemText}: {txtCellInnerTexts}\r\n";
                    }
                }
            }

            return display;
        }

        public static string DisplayText(int cMax, int[] jobPermutation, int[][] jobAssignment)
        {
            var display = "";
            display += $"Cmax: {cMax}\r\n\r\n";
            display += $"Jobs processing order:\r\n" +
                           $"\t  {string.Join(", ", jobPermutation)}\r\n\r\n";
            display += $"Jobs assignment to machines each stage:\r\n";
            for (var i = 0; i < jobAssignment.Length; ++i)
            {
                display += $"Stage {i + 1:00}:   {string.Join(", ", jobAssignment[i])}\r\n";
            }

            return display;
        }
    }
}
