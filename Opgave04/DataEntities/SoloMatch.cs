using System;
using System.Collections.Generic;
using System.Linq;

namespace DataEntities
{
    /// <summary>
    /// Contains SoloMatch info
    /// </summary>
    [Serializable]
    public class SoloMatch : MatchType, IEquatable<SoloMatch>
    {
        /// <summary>
        /// Gets / sets players
        /// </summary>
        public List<PlayerType> Players { get; set; }

        /// <summary>
        /// Gets / sets scores
        /// </summary>
        public List<int> Scores { get; set; }

        /// <summary>
        /// Creates a solo match
        /// </summary>
        public SoloMatch() { }

        public SoloMatch(List<PlayerType> Players, List<int> scores, MatchCategories cat, GameType game)
        {
            this.Players = Players;
            Scores = scores;
            Category = cat;
            dateTime = DateTime.Now;
            GameID = game;
        }

        public static bool operator ==(SoloMatch a, SoloMatch b)
        {
            if (a.dateTime != b.dateTime)
            {
                return false;
            }
            if ((a is SoloMatch) && (b is SoloMatch))
            {
                if ((a.Scores.Count == b.Scores.Count) &&(a.Players.Count == b.Players.Count))
                {
                    foreach (PlayerType pl in a.Players)
                    {
                        if (!b.Players.Contains(pl))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(SoloMatch a, SoloMatch b)
        {
            return !(a == b);
        }

        public bool Equals(SoloMatch other)
        {
            return (this == other);
        }

        public override bool Equals(object other)
        {
            if (!(other is SoloMatch))
            {
                return false;
            }
            else
            {
                return (this.Equals((SoloMatch)other));
            }
        }

        /// <summary>
        /// String representation of object
        /// </summary>
        /// <returns> String representation of object </returns>
        public override string ToString()
        {
            return $"\n--Solo Match Info:\n{dateTime.ToString()} - {Category.ToString()} - {GameID.ToString()} \n--Players:\n{string.Join("\n", Players)} \n--Scores:\n{string.Join("\n", Scores)}";
        }
    }
}
