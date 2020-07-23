using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMinCMax.Entity;
using FindMinCMax.Input;

namespace FindMinCMax
{
    class JobsProcessingUtils
    {
        private const int V = 1000000000;

        public int[] jobsPermutation { get; set; } = { 2, 1, 3, 4, 5 };

        public int[][] jobAssignments =
        {
            new[]  {2, 1, 0, 2, 1},
            new[] {1, 2, 1, 0, 2},
            new[] {0, 1, 1, 1, 1}
        }; // row: stages, column position: corresponding to job permutation, cell: assigned machine to a job at a stage

        private int[][] _machines;
        private int[][][] _eligibility;
        private int[][][] _processingTimes;
        private int[][][] _lagTimes;
        private int[][][][] _setupTimes;

        private List<Job> Jobs;
        private List<Stage> Stages;

        private int _numOfJobs;
        private int _numOfStages;

        public JobsProcessingUtils()
        {
            InitInputData();
            InitJobs(InputData.NumOfJobs);
            InitStagesAndTheirMachines(_numOfStages);
        }

        public JobsProcessingUtils(int numOfJobs)
        {
            InitInputData();
            _numOfJobs = numOfJobs;

            InitJobs(InputData.NumOfJobs);
            InitStagesAndTheirMachines(_numOfStages);
        }

        private void InitInputData()
        {
            _numOfStages = InputData.NumOfStages;
            _numOfJobs = InputData.NumOfJobs;
            _machines = InputData.Machines;
            _eligibility = InputData.Eligibility;
            _processingTimes = InputData.ProcessingTimes;
            _lagTimes = InputData.LagTimes;
            _setupTimes = InputData.SetupTimes;
        }

        private void InitJobs(int jobsCount)
        {
            Jobs = new List<Job>(jobsCount);
            for (var i = 0; i < jobsCount; ++i)
            {
                Jobs.Add(new Job { Id = i, CurrentTime = 0 });
            }
        }

        private void InitStagesAndTheirMachines(int stagesCount)
        {
            Stages = new List<Stage>(stagesCount);
            for (var i = 0; i < stagesCount; ++i)
            {
                Stages.Add(new Stage { Id = i, Machines = new List<Machine>(_machines[i].Length) });
            }

            for (var i = 0; i < stagesCount; ++i)
            {
                var machinesCount = _machines[i].Length;
                for (var l = 0; l < machinesCount; ++l)
                {
                    Stages[i].Machines.Add(new Machine { Id = l, AvailableTime = 0, CurrentJobPosition = -1 });
                }
            }
        }

        public int FindCMax()
        {
            var cMax = 0;
            for (var k = 0; k < _numOfJobs; ++k)
            {
                // find total processing time of job k
                var jobId = jobsPermutation[k];
                var jobPosition = jobId - 1;
                for (var i = 0; i < _numOfStages; ++i)
                {
                    // 1. BEFORE PROCESSING
                    var machineId = jobAssignments[i][k];
                    if (machineId == 0)
                    {
                        continue;
                    }
                    var machinePosition = machineId - 1;
                    var processingTime = _processingTimes[i][machinePosition][jobPosition];

                    var setupTime = 0;
                    var previousJobPosition = Stages[i].Machines[machinePosition].CurrentJobPosition;
                    if (previousJobPosition >= 0)
                    {
                        setupTime = Math.Max(_setupTimes[i][machinePosition][previousJobPosition][jobPosition], 0);
                    }

                    var lagTime = 0;
                    if (i > 0)
                    {
                        // not the first stage
                        var previousMachinePosition = jobAssignments[i - 1][k] - 1;
                        lagTime = previousMachinePosition >= 0
                                    ? _lagTimes[i - 1][previousMachinePosition][jobPosition]
                                    : 0;
                    }

                    var headTime = Math.Max(Jobs[jobPosition].CurrentTime + lagTime,
                        Stages[i].Machines[machinePosition].AvailableTime);

                    var offerAddedBySetupTime = Math.Min(0,
                        headTime - setupTime - Stages[i].Machines[machinePosition].AvailableTime);


                    // --- END OF BEFORE PROCESSING

                    // 2. WHILE PROCESSING

                    var timeTaken = headTime + processingTime - offerAddedBySetupTime;

                    //Console.WriteLine(
                    //    $@"Stage {i + 1}, Machine {machinePosition + 1}, Job {jobPosition + 1}, CurrentTime {Jobs[jobPosition].CurrentTime + lagTime}, HeadTime {headTime}, SetupOffer {offerAddedBySetupTime}  -> TimeTaken {timeTaken}");

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
