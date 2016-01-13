namespace CS_ExamenStuff
{
    public partial class sTTForm : Form
    {
        IStringStuff stuff = new StringStuff();
        private void decodeButton_Click(object sender, EventArgs e)
        {
            stuff.PctChangedEvent += updateProgress;
            stuff.doStuff("This is an example with parameters");
        }

        private void updateProgress(decimal x)
        {
            progressBar1.Value = (int)(Math.Ceiling(x));
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (stuff.cancelSource != null)
            {
                stuff.cancelSource.Cancel();
            }
        }
    }
}

namespace LogicImplementation
{
    public class StringStuff: IStringStuff
    {
        private CancellationToken cancelToken;
        public CancellationTokenSource cancelSource { get; set; }
        public event Action<decimal> PctChangedEvent;

        public void doStuff(string exampleString)
        {
            cancelSource = new CancellationTokenSource();
            cancelToken = cancelSource.Token;

            var decRep = new Progress<decimal>((decCount) =>
            {
                if (PctChangedEvent != null) PctChangedEvent(decCount);
            });
            Task.Run(() => { doStuffTask(exampleString, decRep, cancelToken); });
        }

        public void doStuffTask(string exampleString, IProgress<decimal> decRep, CancellationToken token)
        {
            int twenty = 20;
            string whatever = "";
            for (int i = 0; i < twenty; i++)
            {
                if (!token.IsCancellationRequested)
                {
                    whatever += exampleString;
                    decRep.Report((Math.Ceiling((decimal)(i + 1) * 100 / twenty)));
                }
            }
        } // public void doStuffTask
    } // public class StringStuff
} // namespace LogicImplementation
