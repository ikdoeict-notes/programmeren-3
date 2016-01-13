using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using BackendInterface;
using GlobalTools;
using System.Threading;

namespace BackendImplementation
{
    public class Generator : IGenerator
    {
        private PasswordGenerator pwdGen;
        private ConcurrentQueue<string> queue;
        private CancellationTokenSource cancelSource;
        private CancellationToken cancelToken;
        private bool running;

        public Generator()
        {
            cancelSource = new CancellationTokenSource();
            cancelToken = cancelSource.Token;
            Stalled += StalledEventHandler;
            running = false;
        }

        public event Action GeneratorFinished;
        public event Action<ulong> ProgressChanged;
        public event Action Stalled;

        private void StalledEventHandler()
        {
            Thread.Sleep(5);
        }

        public void Abort()
        {
            running = false;
        }

        public void Close()
        {
            cancelSource.Cancel();
        }

        public ulong MaxCount()
        {
            if (pwdGen == null)
            {
                return 0;
            }
            else
            {
                return pwdGen.Count();
            }
        }

        private void GeneratePasswords(int maxQueueLength)
        {
            //DateTime time = DateTime.Now;
            ulong generated = 0;
            foreach (var pwd in pwdGen)
            {
                /*DateTime thisTime = DateTime.Now;
                if ((thisTime - time).Milliseconds >= 50)
                {
                    time = thisTime;
                    ProgressChanged(generated);
                }*/
                while (queue.Count() == maxQueueLength) 
                {
                    if (cancelToken.IsCancellationRequested || !running) break;
                    Stalled();
                }
                if (cancelToken.IsCancellationRequested || !running) break;
                queue.Enqueue(pwd);
                generated++;
            }

            GeneratorFinished();
        }

        public ConcurrentQueue<string> Start(int passWordLength, int maxQueueLength)
        {
            running = true;
            queue = new ConcurrentQueue<string>();
            pwdGen = new PasswordGenerator(passWordLength);
            Task job = new Task(() => { GeneratePasswords(maxQueueLength); }, cancelToken);
            job.Start();
            return queue;
        }
    }
}
