using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMinCMax.Input;
using FindMinCMax.Utils;

namespace FindMinCMax.Helpers
{
    public class SimulatedAnnealingAlgo
    {
        private const int MAX_INT = 1000000000;
        private const double TOLERANCE = 0.000001d;

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
            var jobsPermutation = GetInitialJobsPermutationUsingSPT();
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

        private int[] GetInitialJobsPermutationUsingSPT()
        {
            var jobs = new List<AptJob>(NumOfJobs);

            for (var i = 0; i < NumOfJobs; ++i)
            {
                jobs.Add(new AptJob { JobName = i + 1, APT = CalculateAPT(i + 1) });
            }

            jobs.Sort((jobA, jobB) => Math.Abs(jobA.APT - jobB.APT) < TOLERANCE
                ? 0
                : jobA.APT > jobB.APT ? 1 : -1);

            return jobs.Select(job => job.JobName).ToArray();
        }

        /// <summary>
        /// Calculate average processing time for the first stage of job <code>jobName</code>
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns>APT of the job</returns>
        private double CalculateAPT(int jobName)
        {
            var jobPosition = jobName - 1;
            var stagePosition = 1 - 1; // stage 1, which has position zero in memory
            var eligibility = InputData.Eligibility;
            var processingTimes = InputData.ProcessingTimes;

            var totalProcessingTime = 0d;
            var numberOfMachines = eligibility[stagePosition][jobPosition].Length;

            if (numberOfMachines == 0)
            {
                return 0; // prioritize not fungible job
            }

            for (var l = 0; l < numberOfMachines; ++l)
            {
                var machinePosition = eligibility[stagePosition][jobPosition][l] - 1;
                totalProcessingTime += processingTimes[stagePosition][machinePosition][jobPosition];
            }

            return totalProcessingTime / numberOfMachines;
        }

        private Neighbor GetBestNeighborOf(int[] jobsPermutation)
        {
            var bestNeighbor = new Neighbor { Cmax = MAX_INT };
            for (var i = 0; i < jobsPermutation.Length - 1; ++i)
            {
                var neighborJobs = GetNeighborJobs(jobsPermutation, i);
                var neighbor = new Neighbor { JobsPermutation = neighborJobs };
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

    class AptJob
    {
        public int JobName { get; set; }
        public double APT { get; set; }
    }
}
