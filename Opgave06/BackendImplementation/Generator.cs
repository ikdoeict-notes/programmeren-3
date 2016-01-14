using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using BackendInterface;
using GlobalTools;
using System.Threading;

namespace BackendImplementation
{
    public class Generator : IGenerator
    {
        private enum Status { RUNNING, ABORT, CLOSE};
        private enum ReportStatus { STALLED, FINISHED}

        // generator status
        private Status _status;

        // password generator
        private PasswordGenerator _passGen;

        // password length
        private int _passLength;

        // queue length
        private int _queueLength;

        // moment of last progress update
        private DateTime _lastProgUpdate;

        // reference to password queue
        private ConcurrentQueue<string> _q; 

        public event Action GeneratorFinished;
        public event Action<ulong> ProgressChanged;
        public event Action Stalled;

        /// <summary>
        /// Aborts the generator
        /// </summary>
        public void Abort()
        {
            _status = Status.CLOSE;
        }

        /// <summary>
        /// Closes the generator
        /// </summary>
        public void Close()
        {
            _status = Status.CLOSE;
        }

        /// <summary>
        /// Returns the max number of passwords
        /// </summary>
        /// <returns> max number of passwords </returns>
        public ulong MaxCount()
        {
            if (_passGen == null) return 0;
            return _passGen.Count();
        }

        /// <summary>
        /// Keeps the queue filled
        /// </summary>
        private void MaintainQueue(IProgress<ulong> progress, IProgress<ReportStatus> status)
        {
            _status = Status.RUNNING;
            _lastProgUpdate = DateTime.Now;
            ulong passCount = 0;
            
            // keep queue filled
            foreach (string password in _passGen)
            {
                // wait if queue is filled
                while (_q.Count >= _queueLength)
                {
                    status.Report(ReportStatus.STALLED);
                    Thread.Sleep(5);
                    // die
                    if (_status == Status.CLOSE) return;
                }

                // die
                if (_status == Status.CLOSE) return;
                
                // add password to queue 
                _q.Enqueue(password);
                passCount++;

                // report?
                if ((DateTime.Now - _lastProgUpdate).Milliseconds > 50)
                {
                    _lastProgUpdate = DateTime.Now;
                    progress.Report(passCount);
                }
            }

            // all passwords generated
            status.Report(ReportStatus.FINISHED);
        }

        /// <summary>
        /// Starts the generator
        /// </summary>
        /// <param name="passWordLength"> password length </param>
        /// <param name="maxQueueLength"> max queue length </param>
        /// <returns></returns>
        public ConcurrentQueue<string> Start(int passWordLength, int maxQueueLength)
        {
            // pass args
            _passLength = passWordLength;
            _queueLength = maxQueueLength;
            
            // Args checks
            if (passWordLength < 1) throw new ArgumentException("Password length must be greater than 0.");
            if (maxQueueLength < 1) throw new ArgumentException("Queue length must be greater than 0.");

            // password generator
            _passGen = new PasswordGenerator(_passLength);

            // fill queue async
            _q = new ConcurrentQueue<string>();

            var progress = new Progress<ulong>((count) =>
            {
                if (ProgressChanged != null) ProgressChanged(count);
            });
            var status = new Progress<ReportStatus>((stat) =>
            {
                switch (stat)
                {
                    case ReportStatus.STALLED:
                        if (Stalled != null) Stalled();
                        break;
                    case ReportStatus.FINISHED:
                        if (GeneratorFinished != null) GeneratorFinished();
                        break;
                    default:
                        break;
                }
            });
            Task.Run(() => { MaintainQueue(progress, status); });
            return _q;
        }
    }
}
