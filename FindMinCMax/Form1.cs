using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindMinCMax.Entity;
using FindMinCMax.Helpers;

namespace FindMinCMax
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var utils = new Utils();
            //var cMax = utils.FindCMax();

            //lblCMax.Text = cMax.ToString();

            JobHelper.NumOfJobs = 5;
            //JobHelper.GeneratePermutation();

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

            JobHelper.X = new[] { 1, 2 ,4, 5, 3 };
            JobHelper.JobAssignments = new[]
            {
                new []{1, 2, 2, 1, 0},
                new []{2, 1, 0, 1, 1},
                new []{1, 0, 1, 1, 1}
            };
            JobHelper.ProcessMachinesPermutation();
        }
    }
}
