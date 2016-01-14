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
    /// Contains all Team logic
    /// </summary>
    public class TeamLogic : ITeamManipulations
    {
        // connection to backend
        private IGameRankingDataAccess backend;

        /// <summary>
        /// Creates a TeamLogic object
        /// </summary>
        public TeamLogic()
        {
            backend = new DataAccess();
        }

        /// <summary>
        /// Adds or updates a team
        /// </summary>
        /// <param name="team"> team </param>
        /// <returns> false if update is impossible </returns>
        public bool AddOrUpdateTeam(TeamType team)
        {
            if (!(team is TeamType))
            {
                throw new System.InvalidOperationException("Invalid team");
            }
            foreach (MatchType m in backend.MatchList)
            {
                if (!(m is TeamMatch))
                {
                    continue;
                }
                TeamMatch t = (TeamMatch)m;
                if (t.Teams.Contains(team))
                {
                    // already played a match => no update
                    return false;
                }
            }
            if (backend.Teams.Contains(team))
            {
                backend.Teams.Remove(team);
            }
            backend.Teams.Add(team);
            backend.SubmitTeamListChanges();
            return true;
        }

        /// <summary>
        /// Returns all filtered matches for a team
        /// </summary>
        /// <param name="game"> game </param>
        /// <param name="team"> team </param>
        /// <returns> filtered matches for a team </returns>
        public List<MatchType> GetGameMatchesForTeam(GameType game, TeamType team)
        {
            List<MatchType> matches = new List<MatchType>();
            foreach (TeamMatch t in backend.MatchList)
            {
                if (t.GameID == game && t.Teams.Contains(team))
                {
                    if (!matches.Contains(t))
                    {
                        matches.Add(t);
                    }
                }
            }
            return matches;
        }

        /// <summary>
        /// Returns all games for a team
        /// </summary>
        /// <param name="team"> team </param>
        /// <returns> all games for a team </returns>
        public List<GameType> GetGamesForTeam(TeamType team)
        {
            List<GameType> games = new List<GameType>();
            foreach (MatchType match in backend.MatchList)
            {
                if (match is TeamMatch)
                {
                    TeamMatch teamMatch = (TeamMatch)match;
                    foreach (TeamType t in teamMatch.Teams)
                    {
                        if (t == team)
                        {
                            if (!games.Contains(teamMatch.GameID))
                            {
                                games.Add(teamMatch.GameID);
                            }
                        }
                    }
                }
            }
            return games;
        }


        /// <summary>
        /// Returns all matches for a team
        /// </summary>
        /// <param name="team"> team </param>
        /// <returns> all matches for a team </returns>
        public List<MatchType> GetMatchesForTeam(TeamType team)
        {
            List<MatchType> matches = new List<MatchType>();
            foreach (MatchType m in backend.MatchList)
            {
                if (!(m is TeamMatch))
                {
                    continue;
                }
                TeamMatch t = (TeamMatch)m;
                if (t.Teams.Contains(team))
                {
                    if (!matches.Contains(t))
                    {
                        matches.Add(t);
                    }
                }
            }
            return matches;
        }

        /// <summary>
        /// Returns all teams
        /// </summary>
        /// <returns> all teams </returns>
        public List<TeamType> GetTeams()
        {
            return backend.Teams;
        }

        /// <summary>
        /// Returns all teams for a game
        /// </summary>
        /// <param name="game"> game </param>
        /// <returns> all teams for a game </returns>
        public List<TeamType> GetTeamsforGame(GameType game)
        {
            List<TeamType> teams = new List<TeamType>();
            foreach (MatchType match in backend.MatchList)
            {
                if (match is TeamMatch)
                {
                    TeamMatch teamMatch = (TeamMatch)match;
                    if (teamMatch.GameID == game)
                    {
                        foreach (TeamType t in teamMatch.Teams)
                        {
                            if (!teams.Contains(t))
                            {
                                teams.Add(t);
                            }
                        }
                    }
                }
            }
            return teams;
        }
    }
}
