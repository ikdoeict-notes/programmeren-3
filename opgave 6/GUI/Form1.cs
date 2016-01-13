using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicInterface;
using LogicImplementation;
using GlobalTools;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class Form1 : Form
    {
        private IMD5CollisionCalculator calc;

        public Form1()
        {
            InitializeComponent();
            calc = new MD5CollisionCalculator();
            calc.ProgressChanged += ProgressEventHandler;
            calc.CollisionFound += CollisionEventHandler;
        }

        private void workersUpDown_ValueChanged(object sender, EventArgs e)
        {
           calc.NrOfWorkerTasks = (int)workersUpDown.Value;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (hashTextbox.Text.Length == 32)
            {
                richTextBox1.Text += DateTime.Now.ToString("HH:mm:ss tt") + "- Started looking for collisions\n";
                startButton.Enabled = false;
                abortButton.Enabled = true;
                progressBar1.Value = 0;
                processedLabel.Text = "";
                calc.NrOfWorkerTasks = (int)workersUpDown.Value;
                calc.StartCalculatingMD5Collision(hashTextbox.Text, (int)pwdlengthUpDown.Value);
            }
            else
            {
                richTextBox1.Text += DateTime.Now.ToString("HH:mm:ss tt") + "- Invalid hash\n";
            }
        }

        private void hashButton_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(pwdTextbox.Text, @"^[A-Z ]+$"))
            {
                richTextBox1.Text += DateTime.Now.ToString("HH:mm:ss tt") + "- Invalid characters in password field\n";
            }
            else if (pwdTextbox.Text.Length != pwdlengthUpDown.Value)
            {
                richTextBox1.Text += DateTime.Now.ToString("HH:mm:ss tt") + "- The password's length is invalid\n";
            }
            else
            {
                hashTextbox.Text = MD5Calculator.GetHash(pwdTextbox.Text);
            }
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            calc.Abort();
            richTextBox1.Text += DateTime.Now.ToString("HH:mm:ss tt") + "- Stopped looking for collisions\n";
            startButton.Enabled = true;
            abortButton.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            calc.Close();
        }

        private void ProgressEventHandler(decimal progress)
        {
            progressBar1.Value = (int)Math.Round(((double)progress / Math.Pow(26, (double)pwdlengthUpDown.Value)) * 100);
            processedLabel.Text = Convert.ToString(progress);
        }

        private void CollisionEventHandler(string password)
        {
            calc.Abort();
            progressBar1.Value = 100;
            richTextBox1.Text += DateTime.Now.ToString("HH:mm:ss tt") + "- Collision found: " + password + "\n";
            startButton.Enabled = true;
            abortButton.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "====================LOG====================\n";
            richTextBox1.Text += DateTime.Now.ToString("HH:mm:ss tt") + "MD5 Collision Calculator started\n";
        }

        private void pwdlengthUpDown_ValueChanged(object sender, EventArgs e)
        {
            possibleLabel.Text = Convert.ToString((long)Math.Pow(26, (double)pwdlengthUpDown.Value));
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
    }
}
