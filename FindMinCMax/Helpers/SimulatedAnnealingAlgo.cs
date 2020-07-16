using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinCMax.Helpers
{
    public class SimulatedAnnealingAlgo
    {
        public int LoopCount { get; set; }
        public int NumOfJobs { get; set; }

        public int[] ResultJobsPermutation { get; set; }
        public int[][] ResultJobsAssignment { get; set; }
        public int ResultCmax { get; set; }

        public void StartSimulating()
        {
            // STEP 1: Init
            //var jobsPermutation = GetInitialJobsPermutation();
            var jobsPermutation = GetRandomInitialJobsPermutation();
            var jobs = new Neighbor(jobsPermutation);
            jobs.CalculateCmax();

            var result = jobs;
            var rand = new Random();
            var beta = rand.NextDouble();

            for (var k = 0; k < LoopCount; ++k)
            {
                // STEP 2: Evaluate nearby region
                var neighbor = GetBestNeighborOf(jobsPermutation);

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
            ResultJobsPermutation = result.JobsPermutation;
            ResultJobsAssignment = result.JobsAssignment;
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
            var neighbor = host.Select(cell => cell).ToArray();;
            var tmp = neighbor[swapIndex];
            neighbor[swapIndex] = neighbor[swapIndex + 1];
            neighbor[swapIndex + 1] = tmp;
            return neighbor;
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
            JobHelper.NumOfJobs = JobsPermutation.Length;
            JobHelper.X = JobsPermutation;
            JobHelper.GenerateJobAssignmentPermutation();

            JobsAssignment = JobHelper.resultJobAssignments;
            Cmax = JobHelper.resultCmax;

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
