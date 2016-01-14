using System;
using System.Collections.Generic;
using System.Linq;
using LogicInterface;
using BackendInterface;
using BackendImplementation;
using System.Collections.Concurrent;
using GlobalTools;

namespace LogicImplementation
{
    public class MD5CollisionCalculator : IMD5CollisionCalculator
    {
        // length of the queue
        private const int QUEUE_LENGTH_MAX = 10000;

        // password generator
        private IGenerator _generator;

        // pool with workers
        private List<IWorker> _workerPool;

        // number of workers
        private int _nrOfWorkerTasks;

        // queue with passwords
        private ConcurrentQueue<string> _jobs;

        // mysterious hash
        private string _challenge;

        // true if workers are running
        private bool _running;

        // number of failed passwords
        private ulong _passCount;

        // total number of passwords
        private ulong _nrPasswords;

        public event Action<string> CollisionFound;
        public event Action<decimal> ProgressChanged;

        /// <summary>
        /// Gets / Sets number of workers
        /// </summary>
        public int NrOfWorkerTasks
        {
            get
            {
                return _nrOfWorkerTasks;
            }

            set
            {
                if (value > 0)
                {
                    _nrOfWorkerTasks = value;
                }
                else
                {
                    _nrOfWorkerTasks = 0;
                }
                MaintainWorkers();
            }
        }

        public MD5CollisionCalculator()
        {
            _generator = new Generator();
            _workerPool = new List<IWorker>();
            _nrOfWorkerTasks = 0;
            _passCount = 0;
            _running = false;
        }

        /// <summary>
        /// Handler for CollisionFound, Aborts the calculation.
        /// </summary>
        /// <param name="pass"> password </param>
        private void CollisionFound_EventHandler(string pass)
        {
            if (CollisionFound != null) CollisionFound(pass);
            Abort();
        }

        /// <summary>
        /// Handler for ProgressChange
        /// </summary>
        /// <param name="nr"> number of failed passwords </param>
        private void ProgressChanged_EventHandler(ulong nr)
        {
            _passCount += nr;
            // convert to decimal
            ProgressChanged((decimal)_passCount / (decimal)_nrPasswords);
        }

        /// <summary>
        /// Aborts the current calculation (removes workers & resets generator)
        /// </summary>
        public void Abort()
        {
            if (_generator != null) _generator.Abort();
            while (_workerPool.Count > 0)
            {
                _workerPool.ElementAt(0).Abort();
                _workerPool.Remove(_workerPool.ElementAt(0));
            }
            _running = false;
        }

        /// <summary>
        /// Closes the calculator (removes workers & generator)
        /// </summary>
        public void Close()
        {
            if (_generator != null) _generator.Close();
            _generator = null;
            while (_workerPool.Count > 0)
            {
                _workerPool.ElementAt(0).Abort();
                _workerPool.Remove(_workerPool.ElementAt(0));
            }
            _running = false;
        }

        /// <summary>
        /// Starts the calculation
        /// </summary>
        /// <param name="hash"> mysterious hash </param>
        /// <param name="passwordLength"> password length </param>
        public void StartCalculatingMD5Collision(string hash, int passwordLength)
        {
            _passCount = 0;
            _nrPasswords = NrOffPasswords(passwordLength);
            _challenge = hash;
            if (_jobs != null)
            {
                // stop running calculations and restart
                Abort();
            }
            _running = true;
            _jobs = _generator.Start(passwordLength, QUEUE_LENGTH_MAX);
            MaintainWorkers();
        }

        /// <summary>
        /// Maintains the number of workers
        /// </summary>
        private void MaintainWorkers()
        {
            if (!_running) return;
            while (_workerPool.Count != _nrOfWorkerTasks)
            {
                if (_workerPool.Count < _nrOfWorkerTasks)
                {
                    // add a worker
                    Worker w = new Worker();
                    w.CollisionFound += CollisionFound_EventHandler;
                    w.ProgressChanged += ProgressChanged_EventHandler;
                    w.GetCollisions(_challenge, _jobs);
                    _workerPool.Add(w);
                }
                else
                {
                    // abort and remove worker
                    _workerPool.ElementAt(0).CollisionFound -= CollisionFound_EventHandler;
                    _workerPool.ElementAt(0).Abort();
                    _workerPool.Remove(_workerPool.ElementAt(0));
                }
            }
        }

        /// <summary>
        /// Calculates the number of passwords
        /// </summary>
        /// <param name="characters"> number of characters </param>
        /// <returns> number of passwords </returns>
        public ulong NrOffPasswords(int characters)
        {
            PasswordGenerator p = new PasswordGenerator(characters);
            ulong n = p.Count();
            return n;
        }

        /// <summary>
        /// Calculates the hash of a password
        /// </summary>
        /// <param name="password"> password </param>
        /// <returns> MD5 Hash </returns>
        public string GetMD5(string password)
        {
            return MD5Calculator.GetHash(password);
        }
    }
}
