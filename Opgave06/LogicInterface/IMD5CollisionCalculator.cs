using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalTools;

namespace LogicInterface
{
    public interface IMD5CollisionCalculator
    {
        /// <summary>
        /// Nr of background worker tasks to be used (default = 1)
        /// </summary>
        int NrOfWorkerTasks { get; set; }

        void StartCalculatingMD5Collision(string hash, int passwordLength);

        /// <summary>
        /// Returns the maximum number of different combinations for x characters
        /// </summary>
        /// <param name="characters"> password length </param>
        /// <returns></returns>
        ulong NrOffPasswords(int characters);

        /// <summary>
        /// returns the MD5 hash of a password
        /// </summary>
        /// <param name="password"> password </param>
        /// <returns></returns>
        string GetMD5(string password);

        /// <summary>
        /// Abort current search for a collision
        /// </summary>
        void Abort();

        /// <summary>
        /// Close down all background tasks
        /// </summary>
        void Close();

        /// <summary>
        ///  report the progress for the current search through all combinations in percentage
        /// </summary>
        event Action<decimal> ProgressChanged;

        /// <summary>
        /// Signals the finding of a collision for the hash
        /// </summary>
        event Action<string> CollisionFound;
    }
}
