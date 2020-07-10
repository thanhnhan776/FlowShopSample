using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            var utils = new Utils();
            var cMax = utils.FindCMax();

            lblCMax.Text = cMax.ToString();

            JobHelper.NumOfJobs = 5;
            //JobHelper.GeneratePermutation();
            JobHelper.GenerateJobAssignmentPermutation();
        }
    }
}
