using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMinCMax.Utils;

namespace FindMinCMax.Helpers
{
    public class SimulatedAnnealingAlgo
    {
        public int LoopCount { get; set; }
        public int NumOfJobs { get; set; }

        public Neighbor InitJobs { get; set; }

        public int[] ResultJobPermutation { get; set; }
        public int[][] ResultJobAssignment { get; set; }
        public int ResultCmax { get; set; }

        private JobHelper _jobHelper;

        public SimulatedAnnealingAlgo()
        {
            _jobHelper = new JobHelper();
        }

        public void StartSimulating()
        {
            // STEP 1: Init
            //var jobsPermutation = GetInitialJobsPermutation();
            var jobsPermutation = GetRandomInitialJobsPermutation();
            var jobs = new Neighbor(jobsPermutation);
            jobs.CalculateCmax();
            InitJobs = new Neighbor
            {
                Cmax = jobs.Cmax,
                JobsPermutation = jobs.JobsPermutation.ClonedInstance(),
                JobsAssignment = jobs.JobsAssignment
            };

            //Console.WriteLine($@"INITIAL JOBS: Cmax={jobs.Cmax}");
            //PrintJobsPermutation(jobsPermutation);
            //PrintJobAssignments(jobs.JobsAssignment);

            var result = jobs;
            var rand = new Random();
            var beta = rand.NextDouble();

            for (var k = 0; k < LoopCount; ++k)
            {
                // STEP 2: Evaluate nearby region of previous best pick
                var neighbor = GetBestNeighborOf(jobs.JobsPermutation);

                if (neighbor.Cmax < result.Cmax)
                {
                    // G(Sc) < (G(S0)
                    result = neighbor;
                    jobs = neighbor;
                } 
                else if (neighbor.Cmax < jobs.Cmax)
                {
                    // G(S0) < G(Sc) < G(Sk)
                    jobs = neighbor;
                }
                else
                {
                    // G(Sc) >= G(Sk)
                    var u = rand.NextDouble(); // random (1, 0)
                    var p = CalculateP(jobs.Cmax, neighbor.Cmax, beta);
                    if (u <= p)
                    {
                        jobs = neighbor;
                    }
                }

                // STEP 3: beta(k+1)
                beta = beta * beta;
            }

            ResultCmax = result.Cmax;
            ResultJobPermutation = result.JobsPermutation;
            ResultJobAssignment = result.JobsAssignment;
        }

        private int[] GetInitialJobsPermutation()
        {
            var jp = new int[NumOfJobs];
            for (var i = 0; i < NumOfJobs; ++i)
            {
                jp[i] = i + 1;
            }

            return jp;
        }

        private int[] GetRandomInitialJobsPermutation()
        {
            var rand = new Random();
            var isSelected = new bool[NumOfJobs];
            var jobsPermutation = new int[NumOfJobs];
            for (var i = 0; i < NumOfJobs; ++i)
            {
                isSelected[i] = false;
            }

            for (var i = 0; i < NumOfJobs; ++i)
            {
                var randIndex = rand.Next() % NumOfJobs;
                while (isSelected[randIndex])
                {
                    randIndex = rand.Next() % NumOfJobs;
                }

                isSelected[randIndex] = true;
                jobsPermutation[i] = randIndex + 1;
            }

            return jobsPermutation;
        }

        private Neighbor GetBestNeighborOf(int[] jobsPermutation)
        {
            var bestNeighbor = new Neighbor {Cmax = 1000000000};
            for (var i = 0; i < jobsPermutation.Length - 1; ++i)
            {
                var neighborJobs = GetNeighborJobs(jobsPermutation, i);
                var neighbor = new Neighbor {JobsPermutation = neighborJobs};
                neighbor.CalculateCmax();

                if (neighbor.Cmax < bestNeighbor.Cmax)
                {
                    bestNeighbor = neighbor;
                }
            }
            return bestNeighbor;
        }

        private double CalculateP(int cmaxK, int cmaxC, double beta)
        {
            return Math.Exp((cmaxK - cmaxC) / beta);
        }

        private int[] GetNeighborJobs(int[] host, int swapIndex)
        {
            var neighbor = host.ClonedInstance();
            var tmp = neighbor[swapIndex];
            neighbor[swapIndex] = neighbor[swapIndex + 1];
            neighbor[swapIndex + 1] = tmp;
            return neighbor;
        }

        private static void PrintJobAssignments(int[][] jobsAssignment)
        {
            Console.WriteLine(@"=> Job assignment: ");
            for (var i = 0; i < 3; ++i)
            {
                for (var j = 0; j < 5; ++j)
                {
                    Console.Write($@"{jobsAssignment[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintJobsPermutation(int[] jobsPermutation)
        {
            Console.WriteLine(@"=> Job permutation: ");
            for (var i = 0; i < jobsPermutation.Length; ++i)
            {
                Console.Write($@"{jobsPermutation[i]} ");
            }
            Console.WriteLine();
        }
    }

    public class Neighbor
    {
        public int[] JobsPermutation { get; set; }
        public int[][] JobsAssignment { get; set; }
        public int Cmax { get; set; }

        public Neighbor()
        {
            
        }

        public Neighbor(int[] jobsPermutation)
        {
            JobsPermutation = jobsPermutation;
        }

        public void CalculateCmax()
        {
            var jobHelper = new JobHelper
            {
                NumOfJobs = JobsPermutation.Length, 
                X = JobsPermutation
            };
            jobHelper.GenerateJobAssignmentPermutation();

            JobsAssignment = jobHelper.ResultJobAssignments.ClonedInstance();
            Cmax = jobHelper.ResultCmax;

            //Console.WriteLine(@"===> SA Cmax: " + Cmax);
            //for (var i = 0; i < 3; ++i)
            //{
            //    for (var j = 0; j < 5; ++j)
            //    {
            //        Console.Write($@"{JobsAssignment[i][j]} ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
