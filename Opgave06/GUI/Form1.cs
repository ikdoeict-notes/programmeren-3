using System;
using System.Windows.Forms;
using LogicInterface;
using LogicImplementation;

namespace GUI
{
    public partial class Form1 : Form
    {
        // interface to logic
        private IMD5CollisionCalculator collisionCalc;

        // settings
        private const int PASS_LENGTH_MAX = 12;
        private const int PASS_LENGTH_MIN = 4;
        private const int WORKERS_NR_MAX = 20;
        private const int WORKERS_NR_MIN = 1;

        public Form1()
        {
            InitializeComponent();
            collisionCalc = new MD5CollisionCalculator();
            numUDPasslength.Maximum = PASS_LENGTH_MAX;
            numUDPasslength.Minimum = PASS_LENGTH_MIN;
            numUDnrWorkers.Maximum = WORKERS_NR_MAX;
            numUDnrWorkers.Minimum = WORKERS_NR_MIN;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // trigger event
            numUDPasslength_ValueChanged(null, null);
            btnStopWorkers.Enabled = false;
            pbProgress.Maximum = 100;
            pbProgress.Minimum = 0;
            pbProgress.Step = 1;
            lbProgress.Text = "";

            // subscribe to events
            collisionCalc.ProgressChanged += ProgressUpdate;
            collisionCalc.CollisionFound += CollisionFound_EventHandler;
        }

        /// <summary>
        /// Handels a CollisionFound event
        /// </summary>
        /// <param name="pass"> collision password </param>
        private void CollisionFound_EventHandler(string pass)
        {
            tbCollision.Text = pass;
            lbProgress.Text = "";
            pbProgress.Value = 0;
            gbSettings.Enabled = true;
            btnStartWorkers.Enabled = true;
            btnStopWorkers.Enabled = false;
        }

        /// <summary>
        /// Start the calculation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartWorkers_Click(object sender, EventArgs e)
        {
            if ((numUDPasslength.Value < PASS_LENGTH_MIN) || (numUDPasslength.Value > PASS_LENGTH_MAX))
            {
                MessageBox.Show("Ongeldige wachtwoord lengte geselecteerd!", "Error wachtwoord lengte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbHashResult.Text.Length != 32)
            {
                MessageBox.Show("Ongeldige wachtwoord hash!", "Error wachtwoord hash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tbCollision.Text = "";
            btnStartWorkers.Enabled = false;
            btnStopWorkers.Enabled = true;
            gbSettings.Enabled = false;
            collisionCalc.NrOfWorkerTasks = (int)numUDnrWorkers.Value;
            collisionCalc.StartCalculatingMD5Collision(tbHashResult.Text, (int)numUDPasslength.Value);
        }

        /// <summary>
        /// Stops the calculation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopWorkers_Click(object sender, EventArgs e)
        {
            collisionCalc.Abort();
            lbProgress.Text = "";
            pbProgress.Value = 0;
            gbSettings.Enabled = true;
            btnStartWorkers.Enabled = true;
            btnStopWorkers.Enabled = false;
            btnStartWorkers.Enabled = true;
            btnStopWorkers.Enabled = false;
        }

        /// <summary>
        /// Let the other layers know we are closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            collisionCalc.Close();
        }

        /// <summary>
        /// Handels number of workers change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDnrWorkers_ValueChanged(object sender, EventArgs e)
        {
            collisionCalc.NrOfWorkerTasks = (int)numUDnrWorkers.Value;
        }

        /// <summary>
        /// Handels a progress update
        /// </summary>
        /// <param name="p"> progress </param>
        private void ProgressUpdate(decimal p)
        {
            if (!btnStopWorkers.Enabled) return;
            if (p > 1.00m) return;
            pbProgress.Value = (int)(p * 100);
            lbProgress.Text = $"Status: {Decimal.Round((p * 100.0m), 6)} %";
        }

        /// <summary>
        /// Handles password length change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUDPasslength_ValueChanged(object sender, EventArgs e)
        {
            lbNrOfPass.Text = "Number of passwords: " + collisionCalc.NrOffPasswords((int)numUDPasslength.Value);
            tbPassword.MaxLength = (int)numUDPasslength.Value;
            if (tbPassword.Text.Length > numUDPasslength.Value)
            {
                tbPassword.Text = tbPassword.Text.Substring(0, (int)numUDPasslength.Value);
            }
        }

        /// <summary>
        /// Handles Textbox leave event for password (password to upper on leave-textbox)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPass_ToUpper(object sender, EventArgs e)
        {
            tbPassword.Text = tbPassword.Text.ToUpper();
        }

        /// <summary>
        /// Handels password to MD5 btn-click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPassToMD5_Click(object sender, EventArgs e)
        {
            tbHashResult.Text = collisionCalc.GetMD5(tbPassword.Text.ToUpper());
        }
    }
}
