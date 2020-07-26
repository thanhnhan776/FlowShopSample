using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FindMinCMax.Entity;
using FindMinCMax.Input;
using FindMinCMax.Utils;

namespace FindMinCMax.Helpers
{
    public class JobHelper
    {
        public int NumOfJobs { get; set; } = 0;
        public int JobPermutationCount { get; set; }
        private bool[] IsAvailable { get; set; }

        /**
         * Job permutation
         */
        public int[] X { get; set; }

        private JobsProcessingUtils _utils;
        private int[][][] _eligibility;
        private int _numOfStages = 0;
        private bool[][][] IsMachineAvailable { get; set; }
        public int[][] JobAssignments { get; set; }
        private int JobAssignmentsCount { get; set; }

        public int ResultCmax = 1000000000;
        public int[] ResultJobPermutation;
        public int[][] ResultJobAssignments;
        public List<Neighbor> Results { get; set; } = new List<Neighbor>();

        public JobHelper()
        {
            LoadFromInputData();
        }

        public void LoadFromInputData()
        {
            NumOfJobs = InputData.NumOfJobs;
            _numOfStages = InputData.NumOfStages;
            _eligibility = InputData.Eligibility;

            _utils = new JobsProcessingUtils();
        }

        public void GeneratePermutation()
        {
            Init();
            PermuteJobs(0);
            //Console.WriteLine($@"Num of permutations: {NumOfPermutation}");
        }

        private void PermuteJobs(int i)
        {
            if (i == NumOfJobs)
            {
                ++JobPermutationCount;
                //PrintX();
                ProcessPermutationX();
            }
            else
            {
                for (var j = 0; j < NumOfJobs; ++j)
                {
                    if (IsAvailable[j])
                    {
                        X[i] = j + 1;
                        IsAvailable[j] = false;
                        PermuteJobs(i + 1);
                        IsAvailable[j] = true;
                    }
                }
            }
        }

        private void PrintX()
        {
            Console.Write($@"{JobPermutationCount}: ");
            for (var i = 0; i < NumOfJobs; ++i)
            {
                Console.Write($@"{X[i]} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Process a specific job flow, find the best machine assignment to this job flow
        /// </summary>
        public void ProcessPermutationX()
        {
            _utils.jobsPermutation = X;
            GenerateJobAssignmentPermutation();
        }

        private void Init()
        {
            IsAvailable = new bool[NumOfJobs];
            for (var i = 0; i < NumOfJobs; ++i)
            {
                IsAvailable[i] = true;
            }

            X = new int[NumOfJobs];
            JobPermutationCount = 0;
        }

        private void GenerateJobAssignmentPermutation()
        {
            InitJobAssignmentPermutation();
            PermuteAssignments(0, 0);
            Console.WriteLine(JobAssignmentsCount);
        }

        private void InitJobAssignmentPermutation()
        {
            JobAssignmentsCount = 0;
            IsMachineAvailable = new bool[_numOfStages][][];
            JobAssignments = new int[_numOfStages][];
            var maxNumOfJobs = InputData.NumOfJobs;
            for (var i = 0; i < _numOfStages; ++i)
            {
                IsMachineAvailable[i] = new bool[maxNumOfJobs][];
                JobAssignments[i] = new int[maxNumOfJobs];
                for (var j = 0; j < maxNumOfJobs; ++j)
                {
                    JobAssignments[i][j] = 0;
                    var maxNumOfMachines = InputData.MaxNumOfMachinesEachStage;
                    IsMachineAvailable[i][j] = new bool[maxNumOfMachines];
                    for (var l = 0; l < maxNumOfMachines; ++l)
                    {
                        IsMachineAvailable[i][j][l] = true;
                    }
                }
            }
        }

        private void PermuteAssignments(int i, int j)
        {
            if (i == _numOfStages - 1 && j == NumOfJobs)
            {
                ++JobAssignmentsCount;
                ProcessMachinesPermutation();
            }
            else if (j == NumOfJobs)
            {
                PermuteAssignments(i + 1, 0);
            }
            else
            {
                var jobPosition = X[j] - 1;
                var numOfMachines = _eligibility[i][jobPosition].Length;
                if (numOfMachines == 0)
                {
                    JobAssignments[i][j] = 0;
                    PermuteAssignments(i, j + 1);
                }
                else
                {
                    for (var machine = 0; machine < numOfMachines; ++machine)
                    {
                        if (IsMachineAvailable[i][jobPosition][machine])
                        {
                            IsMachineAvailable[i][jobPosition][machine] = false;
                            JobAssignments[i][j] = _eligibility[i][jobPosition][machine]; //machine + 1;
                            PermuteAssignments(i, j + 1);
                            IsMachineAvailable[i][jobPosition][machine] = true;
                        }
                    }
                }
            }
        }

        public void ProcessMachinesPermutation()
        {
            //PrintJobAssignments();
            _utils = new JobsProcessingUtils(X.Length)
            {
                jobsPermutation = X,
                jobAssignments = JobAssignments
            };
            var cMax = _utils.FindCMax();

            var jobs = new Neighbor
            {
                Cmax = cMax,
                JobsPermutation = X.ClonedInstance(),
                JobsAssignment = JobAssignments.ClonedInstance()
            };

            if (ResultCmax > cMax)
            {
                ResultCmax = cMax;
                ResultJobAssignments = JobAssignments.ClonedInstance();
                ResultJobPermutation = X.ClonedInstance();


                Results = new List<Neighbor>(); // clear list alternative results
            }
            else if (ResultCmax == cMax)
            {
                Results.Add(jobs); // add same job config for optimal Cmax
            }
        }

        private void PrintJobAssignments()
        {
            Console.WriteLine($@"Job assignment {JobAssignmentsCount}:");
            for (var i = 0; i < _numOfStages; ++i)
            {
                for (var j = 0; j < NumOfJobs; ++j)
                {
                    Console.Write($@"{JobAssignments[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}