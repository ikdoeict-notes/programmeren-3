using System;
using System.Collections.Generic;
using System.Linq;

namespace DataEntities
{
    /// <summary>
    /// Contains TeamMatch info
    /// </summary>
    [Serializable]
    public class TeamMatch : MatchType, IEquatable<TeamMatch>
    {
        /// <summary>
        /// Gets / sets scores
        /// </summary>
        public List<int> Scores { get; set; }

        /// <summary>
        /// Gets / sets teams
        /// </summary>
        public List<TeamType> Teams { get; set; }

        /// <summary>
        /// Creates a team match
        /// </summary>
        public TeamMatch() { }

        /// <summary>
        /// Creates a team match
        /// </summary>
        /// <param name="cat"> match category </param>
        /// <param name="game"> game </param>
        /// <param name="teams"> teams </param>
        /// <param name="scores"> scores </param>
        public TeamMatch(MatchCategories cat, GameType game, List<TeamType> teams, List<int> scores)
        {
            Category = cat;
            GameID = game;
            dateTime = DateTime.Now;
            Scores = scores;
            Teams = teams;
        }

        public static bool operator ==(TeamMatch a, TeamMatch b)
        {
            // experimental check
            if (a.dateTime != b.dateTime)
            {
                return false;
            }
            List<int> ta = new List<int>(a.Scores.ToArray());
            List<int> tb = new List<int>(b.Scores.ToArray());
            ta.Sort();
            tb.Sort();

            if (ta.SequenceEqual(tb))
            {
                foreach (TeamType t in a.Teams)
                {
                    if (!b.Teams.Contains(t))
                    {
                        // wrong team found
                        return false;
                    }
                }
                return true;
            }
            return false;
            //return ((a.Scores == b.Scores) && (a.Teams == b.Teams));
        }

        public static bool operator !=(TeamMatch a, TeamMatch b)
        {
            return !(a == b);
        }

        public bool Equals(TeamMatch other)
        {
            return (this == other);
        }

        public override bool Equals(object other)
        {
            if (!(other is TeamMatch))
            {
                return false;
            }
            else
            {
                return (this.Equals((TeamMatch)other));
            }
        }

        /// <summary>
        /// String representation of object
        /// </summary>
        /// <returns> String representation of object </returns>
        public override string ToString()
        {
            return $"\n--Team Match Info:\n{dateTime.ToString()} - {Category.ToString()} - {GameID.ToString()} \n--Teams:\n{string.Join("\n", Teams)} \n--Scores:\n{string.Join("\n", Scores)}";
        }
    }
}
