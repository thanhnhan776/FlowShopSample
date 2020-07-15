using System;
using FindMinCMax.Entity;

namespace FindMinCMax.Helpers
{
    public class JobHelper
    {
        public static int NumOfJobs { get; set; } = 0;
        public static int NumOfPermutation { get; set; }
        private static bool[] IsAvailable { get; set; }
        public static int[] X { get; set; }

        private static Utils utils = new Utils();
        private static int[][][] Eligibility = utils.eligibility;
        private static int NumOfStages = Eligibility.Length;
        private static bool[][][] IsMachineAvailable { get; set; }
        public static int[][] JobAssignments { get; set; }
        private static int JobAssignmentsCount { get; set; }

        public static int resultCmax = 1000000000;
        public static int[] resultJobPermutation;
        public static int[][] resultJobAssignments;

        public static void GeneratePermutation()
        {
            Init();
            PermuteJobs(0);
            //Console.WriteLine($@"Num of permutations: {NumOfPermutation}");
        }

        private static void PermuteJobs(int i)
        {
            if (i == NumOfJobs)
            {
                ++NumOfPermutation;
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

        private static void PrintX()
        {
            Console.Write($@"{NumOfPermutation}: ");
            for (var i = 0; i < NumOfJobs; ++i)
            {
                Console.Write($@"{X[i]} ");
            }
            Console.WriteLine();
        }

        private static void ProcessPermutationX()
        {
            utils.jobsPermutation = X;
            GenerateJobAssignmentPermutation();
        }

        private static void Init()
        {
            IsAvailable = new bool[NumOfJobs];
            for (var i = 0; i < NumOfJobs; ++i)
            {
                IsAvailable[i] = true;
            }

            X = new int[NumOfJobs];
            NumOfPermutation = 0;
        }

        public  static void GenerateJobAssignmentPermutation()
        {
            InitJobAssignmentPermutation();
            PermuteAssignments(0, 0);
        }

        private static void InitJobAssignmentPermutation()
        {
            JobAssignmentsCount = 0;
            IsMachineAvailable = new bool[NumOfStages][][];
            JobAssignments = new int[NumOfStages][];
            for (var i = 0; i < NumOfStages; ++i)
            {
                IsMachineAvailable[i] = new bool[NumOfJobs][];
                JobAssignments[i] = new int[NumOfJobs];
                for (var j = 0; j < NumOfJobs; ++j)
                {
                    JobAssignments[i][j] = 0;
                    var numOfMachines = Eligibility[i][j].Length;
                    IsMachineAvailable[i][j] = new bool[numOfMachines];
                    for (var l = 0; l < numOfMachines; ++l)
                    {
                        IsMachineAvailable[i][j][l] = true;
                    }
                }
            }
        }

        private static void PermuteAssignments(int i, int j)
        {
            if (i == NumOfStages - 1 && j == NumOfJobs)
            {
                ++JobAssignmentsCount;
                ProcessMachinesPermutation();
            } else if (j == NumOfJobs)
            {
                PermuteAssignments(i+1, 0);
            }
            else
            {
                var jobPosition = X[j] - 1;
                var numOfMachines = Eligibility[i][jobPosition].Length;
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
                            JobAssignments[i][j] = Eligibility[i][jobPosition][machine]; //machine + 1;
                            PermuteAssignments(i, j + 1);
                            IsMachineAvailable[i][jobPosition][machine] = true;
                        }
                    }
                }
            }
        }

        public static void ProcessMachinesPermutation()
        {
            //PrintJobAssignments();
            utils = new Utils
            {
                jobsPermutation = X, 
                jobAssignments = JobAssignments
            };
            var cMax = utils.FindCMax();

            resultCmax = Math.Min(resultCmax, cMax);
            if (resultCmax == cMax)
            {
                resultJobAssignments = JobAssignments;
                resultJobPermutation = X;
            }

            PrintX();
            PrintJobAssignments();
            //Console.WriteLine($@"Job assignment No. {JobAssignmentsCount}");
            Console.WriteLine($@"===> Cmax = {cMax}");
            Console.WriteLine();
        }

        private static void PrintJobAssignments()
        {
            Console.WriteLine($@"Job assignment {JobAssignmentsCount}:");
            for (var i = 0; i < NumOfStages; ++i)
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