using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FindMinCMax.Helpers;
using FindMinCMax.Input;
using FindMinCMax.Utils;

namespace FindMinCMax
{
    public partial class Form1 : Form
    {
        private int numOfStages = 3;
        private int numOfJobs = 5;
        private int[][] machines =
        {
            new[] {1, 2},
            new[] {1, 2},
            new[] {1}
        }; 
        private int[][][] eligibility =
        {
            new[] {new[] {1, 2}, new[] {1, 2}, new int[] { }, new[] {2}, new[] {1, 2}},
            new[] {new[] {2}, new[] {1, 2}, new[] {1}, new int[] { }, new[] {1, 2}},
            new[] {new[] {1}, new int[]{}, new[] {1}, new[] {1}, new[] {1}}
        };
        private int[][][] processingTimes =
        {
            new[] {new[] {10, 6, 0, 0, 11}, new[] {15, 9, 0, 10, 14}},
            new[] {new[] {0, 11, 9, 0, 6}, new[] {8, 4, 0, 0, 12}},
            new[] {new[] {6, 0, 8, 6, 3}}
        }; 
        private int[][][] lagTimes =
        {
            new []{new []{10, 2, 0, 0, -5}, new []{2, -2, 0, 1, -6} },
            new []{new []{0, 0, 3, 0, -3}, new []{-4, 0, 0, 0, 8} }
        };
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
        };
        public Form1()
        {
            InitializeComponent();
            InitInputData();
            InitDisplayInputData();
        }

        private void InitInputData()
        {
            InputData.NumOfStages = numOfStages;
            InputData.NumOfJobs = numOfJobs;
            InputData.Machines = machines;
            InputData.Eligibility = eligibility;
            InputData.ProcessingTimes = processingTimes;
            InputData.LagTimes = lagTimes;
            InputData.SetupTimes = setupTimes;
        }

        private void InitDisplayInputData()
        {
            txtNumOfStages.Text = numOfStages.ToString();
            txtNumOfJobs.Text = numOfJobs.ToString();
            txtMachines.Text = machines.DisplayText();
            txtEligibility.Text = eligibility.DisplayText(DisplayTypes.Eligibility);
            txtProcessingTime.Text = processingTimes.DisplayText(DisplayTypes.ProcessingTime);
            txtLagTime.Text = lagTimes.DisplayText(DisplayTypes.LagTime);
            txtSetupTime.Text = setupTimes.DisplayText();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            return;


            //Console.WriteLine($@"Result Cmax = {JobHelper.resultCmax}");
            //for (var i = 0; i < 5; ++i)
            //{
            //    Console.Write($@"{JobHelper.resultJobPermutation[i]} ");
            //}
            //Console.WriteLine();
            //for (var i = 0; i < 3; ++i)
            //{
            //    for (var j = 0; j < 5; ++j)
            //    {
            //        Console.Write($@"{JobHelper.resultJobAssignments[i][j]} ");
            //    }
            //    Console.WriteLine();
            //}

            //JobHelper.JobAssignments = new[]
            //{
            //    new []{1, 2, 2, 1, 0},
            //    new []{2, 1, 0, 1, 1},
            //    new []{1, 0, 1, 1, 1}
            //};
            //JobHelper.ProcessMachinesPermutation();
            //JobHelper.GenerateJobAssignmentPermutation();

            //Console.WriteLine(JobHelper.resultCmax);
            //PrintJobsPermutation(JobHelper.resultJobPermutation);
            //PrintJobAssignments(JobHelper.resultJobAssignments);
        }

        private static void PrintJobAssignments(int[][] jobsAssignment)
        {
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
            for (var i = 0; i < jobsPermutation.Length; ++i)
            {
                Console.Write($@"{i} ");
            }
            Console.WriteLine();
        }

        private void btnRunBruteForce_Click(object sender, EventArgs e)
        {
            EnableRunButtons(false);

            var jobHelper = new JobHelper();
            jobHelper.GeneratePermutation();
            var cMax = jobHelper.ResultCmax;
            var jobPermutation = jobHelper.ResultJobPermutation;
            var jobAssignment = jobHelper.ResultJobAssignments;
            txtResultBF.Text = DisplayUtils.DisplayText(cMax, jobPermutation, jobAssignment);

            EnableRunButtons();
        }

        private void EnableRunButtons(bool isEnabled = true)
        {
            btnRunSA.Enabled = isEnabled;
            btnRunBruteForce.Enabled = isEnabled;
        }

        private void btnRunSA_Click(object sender, EventArgs e)
        {
            EnableRunButtons(false);

            var sa = new SimulatedAnnealingAlgo
            {
                NumOfJobs = InputData.NumOfJobs, 
                LoopCount = 3
            };
            sa.StartSimulating();

            var initText = DisplayUtils.DisplayText(sa.InitJobs.Cmax, sa.InitJobs.JobsPermutation,
                sa.InitJobs.JobsAssignment);

            var cMax = sa.ResultCmax;
            var jobPermutation = sa.ResultJobPermutation;
            var jobAssignment = sa.ResultJobAssignment;
            var resultText = DisplayUtils.DisplayText(cMax, jobPermutation, jobAssignment);

            txtResultSA.Text = $"--- CHOSEN INIT JOBS ---\r\n{initText}\r\n\r\n" +
                                $"--- RESULT JOBS ---\r\n{resultText}";

            EnableRunButtons();
        }
    }
}
