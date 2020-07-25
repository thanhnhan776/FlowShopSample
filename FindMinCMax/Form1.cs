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
        private int[][] machines;
        private int[][][] eligibility;
        private int[][][] processingTimes;
        private int[][][] lagTimes;
        private int[][][][] setupTimes;
        public Form1()
        {
            InitializeComponent();
            InitInputData();
            InitDisplayInputData();
        }

        private void InitInputData()
        {
            numOfStages = InputData.NumOfStages;
            numOfJobs = InputData.NumOfJobs;
            machines = InputData.Machines;
            eligibility = InputData.Eligibility;
            processingTimes = InputData.ProcessingTimes;
            lagTimes = InputData.LagTimes;
            setupTimes = InputData.SetupTimes;
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
           
            // update UI
            //Application.DoEvents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

            var displayResultText = DisplayUtils.DisplayText(cMax, jobPermutation, jobAssignment);
            var displayAlternativeResultText = $"\r\n--- ALTERNATIVE RESULTS --- Found {jobHelper.Results.Count} ---\r\n";
            for (var i = 0; i < jobHelper.Results.Count; ++i)
            {
                var result = jobHelper.Results[i];
                displayAlternativeResultText += $"\r\n=== ({i + 1}) ===\r\n" + result.DisplayText();
            }


            txtResultBF.Text = displayResultText + displayAlternativeResultText;

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

        private void btnLoadFileInput_Click(object sender, EventArgs e)
        {
            btnLoadFileInput.Text = @"Loading...";
            btnLoadFileInput.Enabled = false;
            txtFileInput.ReadOnly = true;

            var errorMessage = FileInput.LoadInputData();
            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InitInputData();
                InitDisplayInputData();
                MessageBox.Show($@"Load data from file {txtFileInput.Text} successfully!", @"Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnLoadFileInput.Text = @"Load";
            btnLoadFileInput.Enabled = true;
            txtFileInput.ReadOnly = false;
        }
    }
}
