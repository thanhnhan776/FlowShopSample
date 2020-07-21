using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
