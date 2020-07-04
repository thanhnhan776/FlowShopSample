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
        private int[] jobsPermutaion = { 2, 1, 3, 4, 5 };

        private int[][] jobAssignments =
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

        private int[][][] egilibility =
        {
            new[] {new[] {1, 2}, new[] {1, 2}, new int[] { }, new[] {2}, new[] {1, 2}},
            new[] {new[] {2}, new[] {1, 2}, new[] {1}, new int[] { }, new[] {1, 2}},
            new[] {new[] {1}, new int[]{}, new[] {1}, new[] {1}, new[] {1}}
        }; // E[i][j][k]: stage i, job j, machine k

        private int[][][] processingTime =
        {
            new[] {new[] {10, 6, 0, 0, 11}, new[] {15, 9, 0, 10, 14}},
            new[] {new[] {0, 11, 9, 0, 6}, new[] {8, 4, 0, 0, 12}},
            new[] {new[] {6, 0, 8, 6, 3}}
        }; // PT[i][l][j]: stage i, machine l, job j

        private int[][][] lagTime =
        {
            new []{new []{10, 2, 0, 0, -5}, new []{2, -2, 0, 1, -6} },
            new []{new []{0, 0, 3, 0, -3}, new []{4, 0, 0, 0, 8} }
        }; // lagTime[i][l][j]: stage i, machine l, job j

        // TODO: setup time

        private List<Job> Jobs;
        private List<Stage> Stages;

        public Utils()
        {
            const int jobsCount = 5;
            const int stagesCount = 3;
            InitJobs(jobsCount);
            InitStagesAndTheirMachines(stagesCount);
        }

        void InitJobs(int jobsCount)
        {
            Jobs = new List<Job>(jobsCount);
            for (var i = 0; i < jobsCount; ++i)
            {
                Jobs[i] = new Job { Id = i, CurrentTime = 0 };
            }
        }

        void InitStagesAndTheirMachines(int stagesCount)
        {
            Stages = new List<Stage>(stagesCount);
            for (var i = 0; i < stagesCount; ++i)
            {
                Stages[i] = new Stage {Id = i, Machines = new List<Machine>(machines[i].Length)};
            }

            for (var i = 0; i < stagesCount; ++i)
            {
                var machinesCount = Stages[i].Machines.Count;
                for (var l = 0; l < machinesCount; ++l)
                {
                    Stages[i].Machines[l] = new Machine {Id = l, AvailableTime = 0};
                }
            }
        }

        public int FindMin()
        {


            return 0;
        }
    }
}
