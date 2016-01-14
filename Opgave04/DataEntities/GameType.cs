using System;

namespace DataEntities
{
    /// <summary>
    /// Contains game info
    /// </summary>
    [Serializable]
    public struct GameType : IEquatable<GameType>
    {
        /// <summary>
        /// Game name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Game participant type
        /// </summary>
        public ParticipantTypes ParticipantType { get; set; }

        /// <summary>
        /// Creates a game
        /// </summary>
        /// <param name="name"> name of the game </param>
        /// <param name="partType"> participant type </param>
        public GameType(string name, ParticipantTypes partType)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new System.ArgumentException("Name cannot be 'null' or empty!");
            }
            Name = name;
            ParticipantType = partType;
        }

        /// <summary>
        /// Checks equality
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> true if equal </returns>
        public static bool operator ==(GameType a, GameType b)
        {
            return (a.Name == b.Name);
            // ## test fix 
            ///return ((a.Name == b.Name) && (a.ParticipantType == b.ParticipantType));
        }

        public static bool operator !=(GameType a, GameType b)
        {
            return !(a == b);
        }

        public bool Equals(GameType other)
        {
            return (this == other);
        }

        public override bool Equals(object other)
        {
            if (!(other is GameType))
            {
                return false;
            }
            else
            {
                return (this.Equals((GameType)other));
            }
        }

        /// <summary>
        /// String representation of object
        /// </summary>
        /// <returns> String representation of object </returns>
        public override string ToString()
        {
            return $"{Name} - {ParticipantType.ToString()}";
        }
    }
}
