namespace GUI
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
            this.numUDPasslength = new System.Windows.Forms.NumericUpDown();
            this.lbNrOfPass = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbHashResult = new System.Windows.Forms.TextBox();
            this.btnPassToMD5 = new System.Windows.Forms.Button();
            this.numUDnrWorkers = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartWorkers = new System.Windows.Forms.Button();
            this.btnStopWorkers = new System.Windows.Forms.Button();
            this.lbProgressBar = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.tbCollision = new System.Windows.Forms.TextBox();
            this.lbCollision = new System.Windows.Forms.Label();
            this.lbProgress = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPasslength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDnrWorkers)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password length:";
            // 
            // numUDPasslength
            // 
            this.numUDPasslength.Location = new System.Drawing.Point(100, 14);
            this.numUDPasslength.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numUDPasslength.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUDPasslength.Name = "numUDPasslength";
            this.numUDPasslength.Size = new System.Drawing.Size(43, 20);
            this.numUDPasslength.TabIndex = 1;
            this.numUDPasslength.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUDPasslength.ValueChanged += new System.EventHandler(this.numUDPasslength_ValueChanged);
            // 
            // lbNrOfPass
            // 
            this.lbNrOfPass.AutoSize = true;
            this.lbNrOfPass.Location = new System.Drawing.Point(6, 48);
            this.lbNrOfPass.Name = "lbNrOfPass";
            this.lbNrOfPass.Size = new System.Drawing.Size(112, 13);
            this.lbNrOfPass.TabIndex = 2;
            this.lbNrOfPass.Text = "Number of passwords:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "MD5 Hash:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(76, 73);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(213, 20);
            this.tbPassword.TabIndex = 5;
            this.tbPassword.Leave += new System.EventHandler(this.tbPass_ToUpper);
            // 
            // tbHashResult
            // 
            this.tbHashResult.Location = new System.Drawing.Point(76, 99);
            this.tbHashResult.Name = "tbHashResult";
            this.tbHashResult.Size = new System.Drawing.Size(213, 20);
            this.tbHashResult.TabIndex = 6;
            // 
            // btnPassToMD5
            // 
            this.btnPassToMD5.Location = new System.Drawing.Point(9, 125);
            this.btnPassToMD5.Name = "btnPassToMD5";
            this.btnPassToMD5.Size = new System.Drawing.Size(75, 23);
            this.btnPassToMD5.TabIndex = 7;
            this.btnPassToMD5.Text = "Calculate";
            this.btnPassToMD5.UseVisualStyleBackColor = true;
            this.btnPassToMD5.Click += new System.EventHandler(this.btnPassToMD5_Click);
            // 
            // numUDnrWorkers
            // 
            this.numUDnrWorkers.Location = new System.Drawing.Point(126, 189);
            this.numUDnrWorkers.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUDnrWorkers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDnrWorkers.Name = "numUDnrWorkers";
            this.numUDnrWorkers.Size = new System.Drawing.Size(56, 20);
            this.numUDnrWorkers.TabIndex = 9;
            this.numUDnrWorkers.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUDnrWorkers.ValueChanged += new System.EventHandler(this.numUDnrWorkers_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Background workers:";
            // 
            // btnStartWorkers
            // 
            this.btnStartWorkers.Location = new System.Drawing.Point(16, 220);
            this.btnStartWorkers.Name = "btnStartWorkers";
            this.btnStartWorkers.Size = new System.Drawing.Size(75, 23);
            this.btnStartWorkers.TabIndex = 10;
            this.btnStartWorkers.Text = "Start";
            this.btnStartWorkers.UseVisualStyleBackColor = true;
            this.btnStartWorkers.Click += new System.EventHandler(this.btnStartWorkers_Click);
            // 
            // btnStopWorkers
            // 
            this.btnStopWorkers.Location = new System.Drawing.Point(97, 220);
            this.btnStopWorkers.Name = "btnStopWorkers";
            this.btnStopWorkers.Size = new System.Drawing.Size(75, 23);
            this.btnStopWorkers.TabIndex = 11;
            this.btnStopWorkers.Text = "Abort";
            this.btnStopWorkers.UseVisualStyleBackColor = true;
            this.btnStopWorkers.Click += new System.EventHandler(this.btnStopWorkers_Click);
            // 
            // lbProgressBar
            // 
            this.lbProgressBar.AutoSize = true;
            this.lbProgressBar.Location = new System.Drawing.Point(13, 315);
            this.lbProgressBar.Name = "lbProgressBar";
            this.lbProgressBar.Size = new System.Drawing.Size(51, 13);
            this.lbProgressBar.TabIndex = 12;
            this.lbProgressBar.Text = "Progress:";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(16, 331);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(289, 23);
            this.pbProgress.TabIndex = 13;
            // 
            // tbCollision
            // 
            this.tbCollision.Location = new System.Drawing.Point(16, 283);
            this.tbCollision.Name = "tbCollision";
            this.tbCollision.Size = new System.Drawing.Size(289, 20);
            this.tbCollision.TabIndex = 14;
            // 
            // lbCollision
            // 
            this.lbCollision.AutoSize = true;
            this.lbCollision.Location = new System.Drawing.Point(13, 267);
            this.lbCollision.Name = "lbCollision";
            this.lbCollision.Size = new System.Drawing.Size(45, 13);
            this.lbCollision.TabIndex = 15;
            this.lbCollision.Text = "Collision";
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(13, 357);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(59, 13);
            this.lbProgress.TabIndex = 16;
            this.lbProgress.Text = "<progress>";
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.numUDPasslength);
            this.gbSettings.Controls.Add(this.lbNrOfPass);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.tbPassword);
            this.gbSettings.Controls.Add(this.tbHashResult);
            this.gbSettings.Controls.Add(this.btnPassToMD5);
            this.gbSettings.Location = new System.Drawing.Point(16, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(300, 164);
            this.gbSettings.TabIndex = 17;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 382);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.lbCollision);
            this.Controls.Add(this.tbCollision);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lbProgressBar);
            this.Controls.Add(this.btnStopWorkers);
            this.Controls.Add(this.btnStartWorkers);
            this.Controls.Add(this.numUDnrWorkers);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(347, 421);
            this.MinimumSize = new System.Drawing.Size(347, 421);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MD5 Hash tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Close);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUDPasslength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDnrWorkers)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUDPasslength;
        private System.Windows.Forms.Label lbNrOfPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbHashResult;
        private System.Windows.Forms.Button btnPassToMD5;
        private System.Windows.Forms.NumericUpDown numUDnrWorkers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStartWorkers;
        private System.Windows.Forms.Button btnStopWorkers;
        private System.Windows.Forms.Label lbProgressBar;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.TextBox tbCollision;
        private System.Windows.Forms.Label lbCollision;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.GroupBox gbSettings;
    }
}

