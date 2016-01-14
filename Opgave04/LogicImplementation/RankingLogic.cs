using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;
using LogicInterfaces;
using DataAccessInterfaces;
using DataAccessImplementation;

namespace LogicImplementation
{
    /// <summary>
    /// Contains all ranking logic
    /// </summary>
    public class RankingLogic : IRankingSource
    {
        // connection to backend
        private IGameRankingDataAccess backend;

        /// <summary>
        /// Creates a RankingLogic object
        /// </summary>
        public RankingLogic()
        {
            backend = new DataAccess();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="soloOrTeam"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        public List<PlayerGameRankingType> GetGameRankings(GameType game, ParticipantTypes soloOrTeam, Ranks rank)
        {
            List<PlayerGameRankingType> rankings = new List<PlayerGameRankingType>();
            foreach (PlayerGameRankingType r in backend.RankingList)
            {
                if ((r.Game == game) && (r.Ranking == rank) && (!rankings.Contains(r)))
                {
                    rankings.Add(r);
                }
            }
            return rankings;
        }

        public List<PlayerGameRankingType> GetGameRankingsAll(GameType game, ParticipantTypes soloOrTeam)
        {
            List<PlayerGameRankingType> rankings = new List<PlayerGameRankingType>();
            foreach (PlayerGameRankingType r in backend.RankingList)
            {
                if ((r.Game == game) && (!rankings.Contains(r)))
                {
                    rankings.Add(r);
                }
            }
            return rankings;
        }
    }
}
