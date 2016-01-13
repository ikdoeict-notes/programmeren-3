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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pwdlengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.pwdamountLabel = new System.Windows.Forms.Label();
            this.pwdTextbox = new System.Windows.Forms.TextBox();
            this.hashTextbox = new System.Windows.Forms.TextBox();
            this.workersUpDown = new System.Windows.Forms.NumericUpDown();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.workerLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.hashButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.possibleLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.processedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pwdlengthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workersUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pwdlengthUpDown
            // 
            resources.ApplyResources(this.pwdlengthUpDown, "pwdlengthUpDown");
            this.pwdlengthUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.pwdlengthUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.pwdlengthUpDown.Name = "pwdlengthUpDown";
            this.pwdlengthUpDown.ReadOnly = true;
            this.pwdlengthUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.pwdlengthUpDown.ValueChanged += new System.EventHandler(this.pwdlengthUpDown_ValueChanged);
            // 
            // pwdamountLabel
            // 
            resources.ApplyResources(this.pwdamountLabel, "pwdamountLabel");
            this.pwdamountLabel.Name = "pwdamountLabel";
            // 
            // pwdTextbox
            // 
            resources.ApplyResources(this.pwdTextbox, "pwdTextbox");
            this.pwdTextbox.Name = "pwdTextbox";
            // 
            // hashTextbox
            // 
            resources.ApplyResources(this.hashTextbox, "hashTextbox");
            this.hashTextbox.Name = "hashTextbox";
            // 
            // workersUpDown
            // 
            resources.ApplyResources(this.workersUpDown, "workersUpDown");
            this.workersUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.workersUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.workersUpDown.Name = "workersUpDown";
            this.workersUpDown.ReadOnly = true;
            this.workersUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.workersUpDown.ValueChanged += new System.EventHandler(this.workersUpDown_ValueChanged);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // workerLabel
            // 
            resources.ApplyResources(this.workerLabel, "workerLabel");
            this.workerLabel.Name = "workerLabel";
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // abortButton
            // 
            resources.ApplyResources(this.abortButton, "abortButton");
            this.abortButton.Name = "abortButton";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // hashButton
            // 
            resources.ApplyResources(this.hashButton, "hashButton");
            this.hashButton.Name = "hashButton";
            this.hashButton.UseVisualStyleBackColor = true;
            this.hashButton.Click += new System.EventHandler(this.hashButton_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // possibleLabel
            // 
            resources.ApplyResources(this.possibleLabel, "possibleLabel");
            this.possibleLabel.Name = "possibleLabel";
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // processedLabel
            // 
            resources.ApplyResources(this.processedLabel, "processedLabel");
            this.processedLabel.Name = "processedLabel";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.processedLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.possibleLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hashButton);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.workerLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.workersUpDown);
            this.Controls.Add(this.hashTextbox);
            this.Controls.Add(this.pwdTextbox);
            this.Controls.Add(this.pwdamountLabel);
            this.Controls.Add(this.pwdlengthUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pwdlengthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workersUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown pwdlengthUpDown;
        private System.Windows.Forms.Label pwdamountLabel;
        private System.Windows.Forms.TextBox pwdTextbox;
        private System.Windows.Forms.TextBox hashTextbox;
        private System.Windows.Forms.NumericUpDown workersUpDown;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label workerLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.Button hashButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label possibleLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label processedLabel;
    }
}

