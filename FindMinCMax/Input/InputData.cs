using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinCMax.Input
{
    public static class InputData
    {
        public const int MaxNumOfMachinesEachStage = 10;

        public static int NumOfStages { get; set; } = 3;

        public static int NumOfJobs { get; set; } = 5;

        public static int[][] Machines { get; set; } =
        {
            new[] {1, 2},
            new[] {1, 2},
            new[] {1}
        }; // machines[i][l]: stage i, machine l

        public static int[][][] Eligibility { get; set; } =
        {
            new[] {new[] {1, 2}, new[] {1, 2}, new int[] { }, new[] {2}, new[] {1, 2}},
            new[] {new[] {2}, new[] {1, 2}, new[] {1}, new int[] { }, new[] {1, 2}},
            new[] {new[] {1}, new int[]{}, new[] {1}, new[] {1}, new[] {1}}
        }; // E[i][j][k]: stage i, job j, machine k

        public static int[][][] ProcessingTimes { get; set; } =
        {
            new[] {new[] {10, 6, 0, 0, 11}, new[] {15, 9, 0, 10, 14}},
            new[] {new[] {0, 11, 9, 0, 6}, new[] {8, 4, 0, 0, 12}},
            new[] {new[] {6, 0, 8, 6, 3}}
        }; // PT[i][l][j]: stage i, machine l, job j

        public static int[][][] LagTimes { get; set; } =
        {
            new []{new []{10, 2, 0, 0, -5}, new []{2, -2, 0, 1, -6} },
            new []{new []{0, 0, 3, 0, -3}, new []{-4, 0, 0, 0, 8} }
        }; // lagTime[i][l][j]: stage i, machine l, job j

        public static int[][][][] SetupTimes { get; set; } =
        {
            new []
            {
                new []
                {
                    new []{-1, 3, -1, -1, 4},
                    new []{4, -1, -1, -1, 1},
                    new []{-1, -1, -1, -1, -1},
                    new []{-1, -1, -1, -1, -1},
                    new []{6, -1, -1, -1, -1}
                },
                new []
                {
                    new []{-1, 6, -1, 8, 2},
                    new []{5, -1, -1, 6, 4},
                    new []{-1, -1, -1, -1, -1},
                    new [] {8, -1, -1, -1, 2},
                    new []{10, -1, -1, 4, -1}
                }
            },
            new []
            {
                new []
                {
                    new []{-1, -1, -1, -1, -1},
                    new []{-1, -1, 6, -1, 4},
                    new []{-1, 8, -1, -1, 5},
                    new []{-1, -1, -1, -1, -1},
                    new []{-1, -1, -1, -1, -1}
                },
                new []
                {
                    new []{-1, 6, -1, -1, 6},
                    new []{5, -1, -1, -1, 2},
                    new []{-1, -1, -1, -1, -1},
                    new []{-1, -1, -1, -1, -1},
                    new []{4, -1, -1, -1, -1}
                }
            },
            new []
            {
                new []
                {
                    new []{-1, -1, 6, 3, 9},
                    new []{-1, -1, -1, -1, -1},
                    new []{4, -1, -1, 1, 8},
                    new []{5, -1, -1, -1, 2},
                    new []{2, -1, -1, 6, -1 }
                }
            }
        }; // setupTimes[i][l][j][k]: stage i, machine l, job j precedes job k
    }
}
