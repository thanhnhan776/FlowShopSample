using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMinCMax.Entity;

namespace FindMinCMax
{
    class Utils
    {
        private const int V = 1000000000;

        public int[] jobsPermutation { get; set; } = { 2, 1, 3, 4, 5 };

        public int[][] jobAssignments =
        {
            new[]  {2, 1, 0, 2, 1},
            new[] {1, 2, 1, 0, 2},
            new[] {0, 1, 1, 1, 1}
        }; // row: stages, column position: corresponding to job permutation, cell: assigned machine to a job at a stage

        private int[][] machines =
        {
            new[] {1, 2},
            new[] {1, 2},
            new[] {1}
        }; // machines[i][l]: stage i, machine l

        public int[][][] eligibility =
        {
            new[] {new[] {1, 2}, new[] {1, 2}, new int[] { }, new[] {2}, new[] {1, 2}},
            new[] {new[] {2}, new[] {1, 2}, new[] {1}, new int[] { }, new[] {1, 2}},
            new[] {new[] {1}, new int[]{}, new[] {1}, new[] {1}, new[] {1}}
        }; // E[i][j][k]: stage i, job j, machine k

        private int[][][] processingTimes =
        {
            new[] {new[] {10, 6, 0, 0, 11}, new[] {15, 9, 0, 10, 14}},
            new[] {new[] {0, 11, 9, 0, 6}, new[] {8, 4, 0, 0, 12}},
            new[] {new[] {6, 0, 8, 6, 3}}
        }; // PT[i][l][j]: stage i, machine l, job j

        private int[][][] lagTimes =
        {
            new []{new []{10, 2, 0, 0, -5}, new []{2, -2, 0, 1, -6} },
            new []{new []{0, 0, 3, 0, -3}, new []{-4, 0, 0, 0, 8} }
        }; // lagTime[i][l][j]: stage i, machine l, job j

        // TODO: setup time

        private int[][][][] setupTimes =
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
                    new []{-1, -1 -1, -1, -1}
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

        private List<Job> Jobs;
        private List<Stage> Stages;

        private const int JobsCount = 5;
        private const int StagesCount = 3;

        public Utils()
        {

            InitJobs(JobsCount);
            InitStagesAndTheirMachines(StagesCount);
        }

        void InitJobs(int jobsCount)
        {
            Jobs = new List<Job>(jobsCount);
            for (var i = 0; i < jobsCount; ++i)
            {
                Jobs.Add(new Job { Id = i, CurrentTime = 0 });
            }
        }

        void InitStagesAndTheirMachines(int stagesCount)
        {
            Stages = new List<Stage>(stagesCount);
            for (var i = 0; i < stagesCount; ++i)
            {
                Stages.Add(new Stage { Id = i, Machines = new List<Machine>(machines[i].Length) });
            }

            for (var i = 0; i < stagesCount; ++i)
            {
                var machinesCount = machines[i].Length;
                for (var l = 0; l < machinesCount; ++l)
                {
                    Stages[i].Machines.Add(new Machine { Id = l, AvailableTime = 0, CurrentJobPosition = -1 });
                }
            }
        }

        public int FindCMax()
        {
            var cMax = 0;
            for (var k = 0; k < JobsCount; ++k)
            {
                // find total processing time of job k
                var jobId = jobsPermutation[k];
                var jobPosition = jobId - 1;
                for (var i = 0; i < StagesCount; ++i)
                {
                    // 1. BEFORE PROCESSING
                    var machineId = jobAssignments[i][k];
                    if (machineId == 0)
                    {
                        continue;
                    }
                    var machinePosition = machineId - 1;
                    var processingTime = processingTimes[i][machinePosition][jobPosition];

                    var setupTime = 0;
                    var previousJobPosition = Stages[i].Machines[machinePosition].CurrentJobPosition;
                    if (previousJobPosition >= 0)
                    {
                        setupTime = Math.Max(setupTimes[i][machinePosition][previousJobPosition][jobPosition], 0);
                    }

                    var lagTime = 0;
                    if (i > 0)
                    {
                        // not the first stage
                        var previousMachinePosition = jobAssignments[i - 1][k] - 1;
                        lagTime = previousMachinePosition >= 0 
                                    ? lagTimes[i - 1][previousMachinePosition][jobPosition]
                                    : 0;
                    }

                    var headTime = Math.Max(Jobs[jobPosition].CurrentTime + lagTime,
                        Stages[i].Machines[machinePosition].AvailableTime);

                    var offerAddedBySetupTime = Math.Min(0,
                        headTime - setupTime - Stages[i].Machines[machinePosition].AvailableTime);


                    // --- END OF BEFORE PROCESSING

                    // 2. WHILE PROCESSING

                    var timeTaken = headTime + processingTime - offerAddedBySetupTime;

                    Console.WriteLine(
                        $@"Stage {i + 1}, Machine {machinePosition + 1}, Job {jobPosition + 1}, CurrentTime {Jobs[jobPosition].CurrentTime + lagTime}, HeadTime {headTime}, SetupOffer {offerAddedBySetupTime}  -> TimeTaken {timeTaken}");

                    Jobs[jobPosition].CurrentTime = timeTaken;
                    Stages[i].Machines[machinePosition].AvailableTime = timeTaken;

                    

                    // --- END OF WHILE PROCESSING

                    // 3. AFTER PROCESSING

                    Stages[i].Machines[machinePosition].CurrentJobPosition = jobPosition;

                    // --- END OF WHILE PROCESSING
                }

                //Console.WriteLine($@"Job {jobPosition}: Cmax: {Jobs[jobPosition].CurrentTime}");
                cMax = Math.Max(cMax, Jobs[jobPosition].CurrentTime);
            }

            return cMax;
        }
    }
}
