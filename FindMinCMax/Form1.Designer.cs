namespace FindMinCMax
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumOfStages = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainerInput = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNumOfJobs = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMachines = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtEligibility = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtProcessingTime = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtLagTime = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtSetupTime = new System.Windows.Forms.TextBox();
            this.splitContainerApp = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainerOutput = new System.Windows.Forms.SplitContainer();
            this.splitContainerOutputTop = new System.Windows.Forms.SplitContainer();
            this.btnRunBruteForce = new System.Windows.Forms.Button();
            this.txtResultBF = new System.Windows.Forms.TextBox();
            this.splitContainerOutputBottom = new System.Windows.Forms.SplitContainer();
            this.btnRunSA = new System.Windows.Forms.Button();
            this.txtResultSA = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInput)).BeginInit();
            this.splitContainerInput.Panel1.SuspendLayout();
            this.splitContainerInput.Panel2.SuspendLayout();
            this.splitContainerInput.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerApp)).BeginInit();
            this.splitContainerApp.Panel1.SuspendLayout();
            this.splitContainerApp.Panel2.SuspendLayout();
            this.splitContainerApp.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutput)).BeginInit();
            this.splitContainerOutput.Panel1.SuspendLayout();
            this.splitContainerOutput.Panel2.SuspendLayout();
            this.splitContainerOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutputTop)).BeginInit();
            this.splitContainerOutputTop.Panel1.SuspendLayout();
            this.splitContainerOutputTop.Panel2.SuspendLayout();
            this.splitContainerOutputTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutputBottom)).BeginInit();
            this.splitContainerOutputBottom.Panel1.SuspendLayout();
            this.splitContainerOutputBottom.Panel2.SuspendLayout();
            this.splitContainerOutputBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of stages";
            // 
            // txtNumOfStages
            // 
            this.txtNumOfStages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumOfStages.Location = new System.Drawing.Point(0, 0);
            this.txtNumOfStages.Name = "txtNumOfStages";
            this.txtNumOfStages.ReadOnly = true;
            this.txtNumOfStages.Size = new System.Drawing.Size(327, 20);
            this.txtNumOfStages.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainerInput);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 565);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // splitContainerInput
            // 
            this.splitContainerInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerInput.Location = new System.Drawing.Point(3, 16);
            this.splitContainerInput.Name = "splitContainerInput";
            this.splitContainerInput.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerInput.Panel1
            // 
            this.splitContainerInput.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainerInput.Panel2
            // 
            this.splitContainerInput.Panel2.Controls.Add(this.tabControl1);
            this.splitContainerInput.Size = new System.Drawing.Size(452, 546);
            this.splitContainerInput.SplitterDistance = 61;
            this.splitContainerInput.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.42857F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.57143F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(452, 61);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 24);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(113, 25);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of jobs";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtNumOfStages);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(122, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 24);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtNumOfJobs);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(122, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 25);
            this.panel4.TabIndex = 3;
            // 
            // txtNumOfJobs
            // 
            this.txtNumOfJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumOfJobs.Location = new System.Drawing.Point(0, 0);
            this.txtNumOfJobs.Name = "txtNumOfJobs";
            this.txtNumOfJobs.ReadOnly = true;
            this.txtNumOfJobs.Size = new System.Drawing.Size(327, 20);
            this.txtNumOfJobs.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(452, 481);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMachines);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(444, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Machines in stages";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMachines
            // 
            this.txtMachines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMachines.Location = new System.Drawing.Point(3, 3);
            this.txtMachines.Multiline = true;
            this.txtMachines.Name = "txtMachines";
            this.txtMachines.ReadOnly = true;
            this.txtMachines.Size = new System.Drawing.Size(438, 449);
            this.txtMachines.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtEligibility);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(440, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Eligibility";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtEligibility
            // 
            this.txtEligibility.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEligibility.Location = new System.Drawing.Point(3, 3);
            this.txtEligibility.Multiline = true;
            this.txtEligibility.Name = "txtEligibility";
            this.txtEligibility.ReadOnly = true;
            this.txtEligibility.Size = new System.Drawing.Size(434, 382);
            this.txtEligibility.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtProcessingTime);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(440, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Processing time";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtProcessingTime
            // 
            this.txtProcessingTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProcessingTime.Location = new System.Drawing.Point(3, 3);
            this.txtProcessingTime.Multiline = true;
            this.txtProcessingTime.Name = "txtProcessingTime";
            this.txtProcessingTime.ReadOnly = true;
            this.txtProcessingTime.Size = new System.Drawing.Size(434, 382);
            this.txtProcessingTime.TabIndex = 8;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtLagTime);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(440, 388);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Lag time";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtLagTime
            // 
            this.txtLagTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLagTime.Location = new System.Drawing.Point(3, 3);
            this.txtLagTime.Multiline = true;
            this.txtLagTime.Name = "txtLagTime";
            this.txtLagTime.ReadOnly = true;
            this.txtLagTime.Size = new System.Drawing.Size(434, 382);
            this.txtLagTime.TabIndex = 9;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtSetupTime);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(440, 388);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Setup time";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtSetupTime
            // 
            this.txtSetupTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSetupTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetupTime.Location = new System.Drawing.Point(3, 3);
            this.txtSetupTime.Multiline = true;
            this.txtSetupTime.Name = "txtSetupTime";
            this.txtSetupTime.ReadOnly = true;
            this.txtSetupTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSetupTime.Size = new System.Drawing.Size(434, 382);
            this.txtSetupTime.TabIndex = 10;
            // 
            // splitContainerApp
            // 
            this.splitContainerApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerApp.Location = new System.Drawing.Point(0, 0);
            this.splitContainerApp.Name = "splitContainerApp";
            // 
            // splitContainerApp.Panel1
            // 
            this.splitContainerApp.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerApp.Panel2
            // 
            this.splitContainerApp.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerApp.Size = new System.Drawing.Size(912, 565);
            this.splitContainerApp.SplitterDistance = 458;
            this.splitContainerApp.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainerOutput);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 565);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // splitContainerOutput
            // 
            this.splitContainerOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOutput.Location = new System.Drawing.Point(3, 16);
            this.splitContainerOutput.Name = "splitContainerOutput";
            this.splitContainerOutput.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerOutput.Panel1
            // 
            this.splitContainerOutput.Panel1.Controls.Add(this.splitContainerOutputTop);
            // 
            // splitContainerOutput.Panel2
            // 
            this.splitContainerOutput.Panel2.Controls.Add(this.splitContainerOutputBottom);
            this.splitContainerOutput.Size = new System.Drawing.Size(444, 546);
            this.splitContainerOutput.SplitterDistance = 216;
            this.splitContainerOutput.TabIndex = 0;
            // 
            // splitContainerOutputTop
            // 
            this.splitContainerOutputTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOutputTop.Location = new System.Drawing.Point(0, 0);
            this.splitContainerOutputTop.Name = "splitContainerOutputTop";
            // 
            // splitContainerOutputTop.Panel1
            // 
            this.splitContainerOutputTop.Panel1.Controls.Add(this.btnRunBruteForce);
            // 
            // splitContainerOutputTop.Panel2
            // 
            this.splitContainerOutputTop.Panel2.Controls.Add(this.txtResultBF);
            this.splitContainerOutputTop.Size = new System.Drawing.Size(444, 216);
            this.splitContainerOutputTop.SplitterDistance = 72;
            this.splitContainerOutputTop.TabIndex = 0;
            // 
            // btnRunBruteForce
            // 
            this.btnRunBruteForce.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRunBruteForce.Location = new System.Drawing.Point(0, 0);
            this.btnRunBruteForce.Name = "btnRunBruteForce";
            this.btnRunBruteForce.Size = new System.Drawing.Size(72, 52);
            this.btnRunBruteForce.TabIndex = 0;
            this.btnRunBruteForce.Text = "Run all cases";
            this.btnRunBruteForce.UseVisualStyleBackColor = true;
            this.btnRunBruteForce.Click += new System.EventHandler(this.btnRunBruteForce_Click);
            // 
            // txtResultBF
            // 
            this.txtResultBF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultBF.Location = new System.Drawing.Point(5, 5);
            this.txtResultBF.Multiline = true;
            this.txtResultBF.Name = "txtResultBF";
            this.txtResultBF.ReadOnly = true;
            this.txtResultBF.Size = new System.Drawing.Size(358, 206);
            this.txtResultBF.TabIndex = 0;
            // 
            // splitContainerOutputBottom
            // 
            this.splitContainerOutputBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOutputBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerOutputBottom.Name = "splitContainerOutputBottom";
            // 
            // splitContainerOutputBottom.Panel1
            // 
            this.splitContainerOutputBottom.Panel1.Controls.Add(this.btnRunSA);
            // 
            // splitContainerOutputBottom.Panel2
            // 
            this.splitContainerOutputBottom.Panel2.Controls.Add(this.txtResultSA);
            this.splitContainerOutputBottom.Size = new System.Drawing.Size(444, 326);
            this.splitContainerOutputBottom.SplitterDistance = 72;
            this.splitContainerOutputBottom.TabIndex = 0;
            // 
            // btnRunSA
            // 
            this.btnRunSA.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRunSA.Location = new System.Drawing.Point(0, 0);
            this.btnRunSA.Name = "btnRunSA";
            this.btnRunSA.Size = new System.Drawing.Size(72, 80);
            this.btnRunSA.TabIndex = 1;
            this.btnRunSA.Text = "Run Simulated Annealing algorithm";
            this.btnRunSA.UseVisualStyleBackColor = true;
            this.btnRunSA.Click += new System.EventHandler(this.btnRunSA_Click);
            // 
            // txtResultSA
            // 
            this.txtResultSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultSA.Location = new System.Drawing.Point(10, 10);
            this.txtResultSA.Multiline = true;
            this.txtResultSA.Name = "txtResultSA";
            this.txtResultSA.ReadOnly = true;
            this.txtResultSA.Size = new System.Drawing.Size(348, 306);
            this.txtResultSA.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 565);
            this.Controls.Add(this.splitContainerApp);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flow-shop Scheduling";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainerInput.Panel1.ResumeLayout(false);
            this.splitContainerInput.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInput)).EndInit();
            this.splitContainerInput.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.splitContainerApp.Panel1.ResumeLayout(false);
            this.splitContainerApp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerApp)).EndInit();
            this.splitContainerApp.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainerOutput.Panel1.ResumeLayout(false);
            this.splitContainerOutput.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutput)).EndInit();
            this.splitContainerOutput.ResumeLayout(false);
            this.splitContainerOutputTop.Panel1.ResumeLayout(false);
            this.splitContainerOutputTop.Panel2.ResumeLayout(false);
            this.splitContainerOutputTop.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutputTop)).EndInit();
            this.splitContainerOutputTop.ResumeLayout(false);
            this.splitContainerOutputBottom.Panel1.ResumeLayout(false);
            this.splitContainerOutputBottom.Panel2.ResumeLayout(false);
            this.splitContainerOutputBottom.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutputBottom)).EndInit();
            this.splitContainerOutputBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumOfStages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainerApp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNumOfJobs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMachines;
        private System.Windows.Forms.TextBox txtEligibility;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtProcessingTime;
        private System.Windows.Forms.TextBox txtLagTime;
        private System.Windows.Forms.TextBox txtSetupTime;
        private System.Windows.Forms.SplitContainer splitContainerInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainerOutput;
        private System.Windows.Forms.SplitContainer splitContainerOutputBottom;
        private System.Windows.Forms.SplitContainer splitContainerOutputTop;
        private System.Windows.Forms.Button btnRunBruteForce;
        private System.Windows.Forms.Button btnRunSA;
        private System.Windows.Forms.TextBox txtResultBF;
        private System.Windows.Forms.TextBox txtResultSA;
    }
}

