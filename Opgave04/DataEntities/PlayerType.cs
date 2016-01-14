using System;

namespace DataEntities
{
    /// <summary>
    /// Contains player info
    /// </summary>
    [Serializable]
    public struct PlayerType : IEquatable<PlayerType>
    {
        /// <summary>
        /// Gets / sets mail
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Gets / sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets / sets tag
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Creates a player
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="name"></param>
        /// <param name="tag"></param>
        public PlayerType(string mail, string name, string tag)
        {
            Mail = mail;
            Name = name;
            Tag = tag;
        }

        public static bool operator ==(PlayerType a, PlayerType b)
        {
            return ((a.Mail == b.Mail)&&(a.Name == b.Name)); 
        }

        public static bool operator !=(PlayerType a, PlayerType b)
        {
            return !(a== b);
        }
        
        public bool Equals(PlayerType other)
        {
            return (this == other);
        }

        public override bool Equals(object other)
        {
            if (!(other is PlayerType))
            {
                return false;
            }
            else
            {
                return (this.Equals((PlayerType)other));
            }
        }

        /// <summary>
        /// String representation of object
        /// </summary>
        /// <returns> String representation of object </returns>
        public override string ToString()
        {
            return $"{this.Name} - {this.Mail} - {this.Tag}";
        }
       
    }

}
