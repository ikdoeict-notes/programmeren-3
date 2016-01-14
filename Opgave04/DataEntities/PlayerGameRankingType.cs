using System;

namespace DataEntities
{
    /// <summary>
    /// Contains ranking info
    /// </summary>
    [Serializable]
    public struct PlayerGameRankingType : IComparable<PlayerGameRankingType>, IEquatable<PlayerGameRankingType>
    {
        private int points;

        /// <summary>
        /// Gets / sets a game
        /// </summary>
        public GameType Game { get; set; }

        /// <summary>
        /// Gets / sets player
        /// </summary>
        public PlayerType Player { get; set; }
        
        /// <summary>
        /// Gets / Sets points
        /// </summary>
        public int Points {
            get { return points; }
            set { points = value; }
        }

        /// <summary>
        /// Gets / sets ranking
        /// </summary>
        public Ranks Ranking { get; set; }

        /// <summary>
        /// Creates a ranking
        /// </summary>
        /// <param name="game"> game </param>
        /// <param name="player"> player </param>
        /// <param name="points"> points </param>
        public PlayerGameRankingType(GameType game, PlayerType player, int points)
        {
            Game = game;
            Player = player;
            this.points = points;
            Ranking = Ranks.Unranked;
        }

        /// <summary>
        /// Creates a ranking
        /// </summary>
        /// <param name="game"> game </param>
        /// <param name="player"> player </param>
        /// <param name="points"> points </param>
        /// <param name="rank"> rank </param>
        public PlayerGameRankingType(GameType game, PlayerType player, int points, Ranks rank)
        {
            Game = game;
            Player = player;
            this.points = points;
            Ranking = rank;
        }

        public int CompareTo(PlayerGameRankingType other)
        {
            if (Game != other.Game)
            {
                throw new System.ArgumentException("Not the same game!");
            }
            if (Points > other.Points)
            {
                return -1;
            }
            else if (Points == other.Points)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static bool operator ==(PlayerGameRankingType a, PlayerGameRankingType b)
        {
            return ((a.Game == b.Game) && (a.Player == b.Player));
        }

        public static bool operator !=(PlayerGameRankingType a, PlayerGameRankingType b)
        {
            return !(a == b);
        }

        public bool Equals(PlayerGameRankingType other)
        {
            return (this == other);
        }

        public override bool Equals(object other)
        {
            if (!(other is PlayerGameRankingType))
            {
                return false;
            }
            else
            {
                return (this.Equals((PlayerGameRankingType)other));
            }
        }

        /// <summary>
        /// String representation of object
        /// </summary>
        /// <returns> String representation of object </returns>
        public override string ToString()
        {
            return $"{Game.Name} - {Player.Name} - {Points} - {Ranking.ToString()}";
        }
    }
}
