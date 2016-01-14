using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendInterface;
using GlobalTools;
using System.Threading;

namespace BackendImplementation
{
    public class Worker : IWorker
    {
        public event Action<string> CollisionFound;
        public event Action<ulong> ProgressChanged;
        public event Action Stalled;

        // alive while true
        private bool _keepAlive;

        // moment of last progress update
        private DateTime _lastProgUpdate;

        /// <summary>
        /// aborts the worker
        /// </summary>
        public void Abort()
        {
            _keepAlive = false;
        }

        /// <summary>
        /// Worker logic
        /// </summary>
        /// <param name="hash"> mysterious hash </param>
        /// <param name="buffer"> queue with passwords </param>
        /// <param name="progress"> progress trigger </param>
        /// <param name="collisionFound"> collision found trigger </param>
        private void Work(string hash, ConcurrentQueue<string> buffer, IProgress<ulong> progress, IProgress<string> collisionFound)
        {
            _lastProgUpdate = DateTime.Now;
            ulong passCount = 0;

            while (_keepAlive)
            {
                // sleep if buffer is empty
                while (buffer.Count <= 0)
                {
                    Console.WriteLine(buffer.Count);
                    if (Stalled != null ) Stalled();
                    Thread.Sleep(5);
                }

                // get password to check
                string pass;
                buffer.TryDequeue(out pass);
                if (pass == null)
                {
                    Thread.Sleep(50);
                    continue;
                }
                string curentHash = MD5Calculator.GetHash(pass);
                passCount++;

                // report progress ?
                if ((DateTime.Now - _lastProgUpdate).Milliseconds > 50)
                {
                    _lastProgUpdate = DateTime.Now;
                    progress.Report(passCount);
                    passCount = 0;
                }

                // right password found ?
                if (hash == curentHash)
                {
                    collisionFound.Report(pass);
                }
            }
        }

        /// <summary>
        /// Start the worker in a task
        /// </summary>
        /// <param name="hash"> mysterious hash </param>
        /// <param name="buffer"> password queue </param>
        public void GetCollisions(string hash, ConcurrentQueue<string> buffer)
        {
            _keepAlive = true;
            var progress = new Progress<ulong>((count) =>
            {
                if (ProgressChanged != null) ProgressChanged(count);
            });

            var collisionFound = new Progress<string>((pass) =>
            {
                if (CollisionFound != null) CollisionFound(pass);
            });

            Task.Run(() => { Work(hash, buffer, progress, collisionFound); });
        }
    }
}
