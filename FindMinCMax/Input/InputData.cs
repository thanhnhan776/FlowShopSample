using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindMinCMax.Utils;

namespace FindMinCMax.Input
{
    public static class InputData
    {
        public static int MaxNumOfMachinesEachStage = 10;

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

        public static int[][][][] EligibilityGroups { get; set; }
        // EligibilityGroups[i][j][g][l]: stage i, job j, group g, machine l

        public static int[][][] GroupOfMachine { get; set; }

        public static void UpdateMaxNumOfMachinesEachStage()
        {
            var num = Machines.Select(machine => machine.Length).Concat(new[] { 0 }).Max();

            MaxNumOfMachinesEachStage = num;
        }

        /// <summary>
        /// Group eligibility table so that a job in each stage
        /// will have a group of assignable machines,
        /// each group contain machines with the same processing time, lag time and setup time
        /// </summary>
        public static void GroupMachineAssignment()
        {
            EligibilityGroups = new int[NumOfStages][][][];
            for (var i = 0; i < NumOfStages; ++i)
            {
                EligibilityGroups[i] = new int[NumOfJobs][][];
                for (var j = 0; j < NumOfJobs; ++j)
                {
                    var numOfMachines = Eligibility[i][j].Length;
                    var groups = new List<List<int>>();
                    for (var l = 0; l < numOfMachines; ++l)
                    {
                        var machinePosition = Eligibility[i][j][l] - 1;
                        if (groups.Count == 0)
                        {
                            var group = new List<int>(new []{machinePosition});
                            groups.Add(group);
                        }
                        else
                        {
                            // check if this machine belong to any group
                            var isNewGroup = true;
                            foreach (var group in groups)
                            {
                                var gMachinePosition = group[0];
                                if (IsSameMachineGroup(
                                    gMachinePosition, 
                                    machinePosition, 
                                    i, 
                                    j,
                                    i == NumOfStages - 1))
                                {
                                    isNewGroup = false;
                                    group.Add(machinePosition);
                                    break;
                                }
                            }

                            if (isNewGroup)
                            {
                                var group = new List<int>(new[] {machinePosition});
                                groups.Add(group);
                            }
                        }
                    }

                    EligibilityGroups[i][j] = groups.To2DArray();
                }
            }
            MapToGroupOfMachine();
        }

        private static void MapToGroupOfMachine()
        {
            GroupOfMachine = new int[NumOfStages][][];
            for (var i = 0; i < NumOfStages; ++i)
            {
                GroupOfMachine[i] = new int[NumOfJobs][];
                for (var j = 0; j < NumOfJobs; ++j)
                {
                    var groupsCount = EligibilityGroups[i][j].Length;
                    GroupOfMachine[i][j] = new int[MaxNumOfMachinesEachStage];
                    for (var g = 0; g < groupsCount; ++g)
                    {
                        var machinesGroupCount = EligibilityGroups[i][j][g].Length;
                        for (var l = 0; l < machinesGroupCount; ++l)
                        {
                            var machinePosition = EligibilityGroups[i][j][g][l];
                            GroupOfMachine[i][j][machinePosition] = g;
                        }
                    }
                }
            }
        }

        private static bool IsSameMachineGroup(int machinePosition1, int machinePosition2, 
            int stage, int job, bool isLastStage)
        {
            var isSameProcessingTimes = ProcessingTimes[stage][machinePosition1][job] ==
                                        ProcessingTimes[stage][machinePosition2][job];
            var isSameLagTimes = isLastStage 
                                 || LagTimes[stage][machinePosition1][job] == LagTimes[stage][machinePosition2][job];
            return isSameProcessingTimes && isSameLagTimes;
        }
    }

}
