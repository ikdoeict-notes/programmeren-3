using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using BackendInterface;
using GlobalTools;
using System.Threading;

namespace BackendImplementation
{
    public class Worker : IWorker
    {
        private CancellationTokenSource cancelSource;
        private CancellationToken cancelToken;
        private bool finished;

        public Worker()
        {
            finished = false;
            cancelSource = new CancellationTokenSource();
            cancelToken = cancelSource.Token;
            Stalled += StalledEventHandler;
        }

        public bool Finished {
            set
            {
                finished = value;
            }
        }

        public event Action<string> CollisionFound;
        public event Action<ulong> ProgressChanged;
        public event Action Stalled;

        private void StalledEventHandler()
        {
            Thread.Sleep(5);
        }

        public void Abort()
        {
            cancelSource.Cancel();
        }

        private void CompareHashes(IProgress<ulong> progress, IProgress<string> collision, string hash, ConcurrentQueue<string> buffer)
        {
            string pwd;
            ulong processed = 0;
            DateTime time = DateTime.Now;
            while (!cancelToken.IsCancellationRequested)
            {
                if (!buffer.IsEmpty)
                {
                    if (buffer.TryDequeue(out pwd))
                    {
                        DateTime thisTime = DateTime.Now;
                        if ((thisTime - time).Milliseconds >= 50)
                        {
                            time = thisTime;
                            progress.Report(processed);
                            processed = 0;
                        }
                        processed++;
                        if (hash == MD5Calculator.GetHash(pwd))
                        {
                            collision.Report(pwd);
                            break;
                        }
                    }
                }
                else
                {
                    if (finished) break;
                    Stalled();
                }
            }
        }

        public void GetCollisions(string hash, ConcurrentQueue<string> buffer)
        {
            var progress = new Progress<ulong>((p) => { ProgressChanged(p); });
            var collision = new Progress<string>((s) => { CollisionFound(s); });
            Task job = new Task(() => { CompareHashes(progress, collision, hash, buffer); }, cancelToken);
            job.Start();
        }
    }
}
