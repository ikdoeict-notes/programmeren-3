using System;
using System.Collections.Generic;

namespace DataEntities
{
    /// <summary>
    /// Contains TeamType info
    /// </summary>
    [Serializable]
    public class TeamType : IEquatable<TeamType>
    {
        /// <summary>
        /// Gets / sets members 
        /// </summary>
        public List<PlayerType> Members { get; set; }

        /// <summary>
        /// Gets / sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates a TeamType
        /// </summary>
        public TeamType() { }

        /// <summary>
        /// Creates a TeamType
        /// </summary>
        /// <param name="Name"> name </param>
        /// <param name="Members"> members </param>
        public TeamType(string Name, List<PlayerType> Members)
        {
            this.Name = Name;
            this.Members = Members;
        }

        public static bool operator ==(TeamType a, TeamType b)
        {
            if ((a is TeamType) && (b is TeamType))
            {
                return (a.Name == b.Name);
            }
            return false;
        }

        public static bool operator !=(TeamType a, TeamType b)
        {
            return !(a == b);
        }

        public bool Equals(TeamType other)
        {
            return (this == other);
        }

        public override bool Equals(object other)
        {
            if (!(other is TeamType))
            {
                return false;
            }
            else
            {
                return (this.Equals((TeamType)other));
            }
        }

        /// <summary>
        /// String representation of object
        /// </summary>
        /// <returns> String representation of object </returns>
        public override string ToString()
        {
            return $"name:{Name} - Members:\n{string.Join("\n", Members)}";
        }
    }
}
