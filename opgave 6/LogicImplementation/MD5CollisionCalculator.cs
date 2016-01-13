using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicInterface;
using BackendInterface;
using BackendImplementation;
using System.Collections.Concurrent;

namespace LogicImplementation
{
    public class MD5CollisionCalculator : IMD5CollisionCalculator
    {
        private bool running;
        private string hash;
        private ConcurrentQueue<string> queue;
        private Generator gen;
        private List<Worker> workers;
        private ulong processedPasswords;

        public MD5CollisionCalculator()
        {
            running = false;
            gen = new Generator();
            workers = new List<Worker>();
            gen.GeneratorFinished += GeneratorFinishedEventHandler;
        }

        public int NrOfWorkerTasks
        {
            get
            {
                return workers.Count;
            }
            set
            {
                if (value - NrOfWorkerTasks > 0)
                {
                    var worker = new Worker();
                    worker.CollisionFound += CollisionFoundEventHandler;
                    worker.ProgressChanged += ProgressChangedEventHandler;
                    if (running) worker.GetCollisions(hash, queue);
                    workers.Add(worker);
                }
                else
                {
                    workers.ElementAt(workers.Count - 1).Abort();
                    workers.RemoveAt(workers.Count - 1);
                }
            }
        }

        public event Action<string> CollisionFound;
        public event Action<decimal> ProgressChanged;

        private void GeneratorFinishedEventHandler()
        {
            Abort();
        }

        private void CollisionFoundEventHandler(string collidingPassword)
        {
            Abort();
            CollisionFound(collidingPassword);
        }

        private void ProgressChangedEventHandler(ulong progress)
        {
            processedPasswords += progress;
            ProgressChanged(processedPasswords);
        }

        public void Abort()
        {
            running = false;
            gen.Abort();
            foreach (var worker in workers)
            {
                worker.Abort();
            }

            // The Garbage Collector will deal with it
            workers = new List<Worker>();
        }

        public void Close()
        {
            Abort();
            gen.Close();
        }

        public void StartCalculatingMD5Collision(string hash, int passwordLength)
        {
            running = true;
            processedPasswords = 0;
            this.hash = hash;
            queue = gen.Start(passwordLength, 100000);
            foreach (var worker in workers)
            {
                worker.GetCollisions(hash, queue);
            }
        }
    }
}
