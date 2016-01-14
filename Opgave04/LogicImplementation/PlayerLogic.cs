using DataAccessImplementation;
using DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;
using LogicInterfaces;

namespace LogicImplementation
{
    /// <summary>
    /// Contains player logic
    /// </summary>
    public class PlayerLogic : IPlayerManipulations
    {
        // connection to backend
        private IGameRankingDataAccess backend;

        /// <summary>
        /// Creates a PlayerLogic object
        /// </summary>
        public PlayerLogic()
        {
            backend = new DataAccess();
        }

        /// <summary>
        /// Adds or updates a player
        /// </summary>
        /// <param name="player"> player </param>
        public void AddOrUpdatePlayer(PlayerType player)
        {
            if (player == null)
            {
                throw new System.InvalidOperationException("Player is null");
            }
            if (backend.Players.Contains(player))
            {
                backend.Players.Remove(player);
            }
            backend.Players.Add(player);
            backend.SubmitPlayerListChanges();
        }

        /// <summary>
        /// Returns filtered matches for a player
        /// </summary>
        /// <param name="game"> game </param>
        /// <param name="player"> player </param>
        /// <returns> filtered matches for a player </returns>
        public List<MatchType> GetGameMatchesForPlayer(GameType game, PlayerType player)
        {
            List<MatchType> matches = new List<MatchType>();

            foreach (MatchType m in backend.MatchList)
            {
                if (m is SoloMatch)
                {
                    SoloMatch solo = (SoloMatch)m;
                    if (solo.Players.Contains(player) && solo.GameID == game)
                    {
                        // protect against duplicates
                        if (!matches.Contains(m))
                        {
                            matches.Add(m);
                        }
                    }
                }
                else if (m is TeamMatch)
                {
                    TeamMatch teamMatch = (TeamMatch)m;
                    foreach (TeamType t in teamMatch.Teams)
                    {
                        if (t.Members.Contains(player) && teamMatch.GameID == game)
                        {
                            // protect against duplicates
                            if (!matches.Contains(m))
                            {
                                matches.Add(m);
                            }
                        }
                    }
                }
                else
                {
                    throw new System.InvalidOperationException("Invalid Match in MatchList!");
                }
            }
            return matches;
        }

        /// <summary>
        /// Returns all games for a player
        /// </summary>
        /// <param name="player"> player </param>
        /// <returns> all games for a player </returns>
        public List<GameType> GetGamesForPlayer(PlayerType player)
        {
            List<GameType> games = new List<GameType>();
            foreach (MatchType match in GetMatchesForPlayer(player))
            {
                if (!games.Contains(match.GameID))
                {
                    games.Add(match.GameID);
                }
            }
            return games;
        }

        /// <summary>
        /// Returns all matches for a player
        /// </summary>
        /// <param name="player"> player </param>
        /// <returns> all matches for a player </returns>
        public List<MatchType> GetMatchesForPlayer(PlayerType player)
        {
            
            List<MatchType> matches = new List<MatchType>();

            foreach (MatchType t in backend.MatchList)
            {
                if (t is TeamMatch)
                {
                    TeamMatch matchTeam = (TeamMatch)t;
                    foreach (TeamType tt in matchTeam.Teams)
                    {
                        if (tt.Members.Contains(player))
                        {
                            if (!matches.Contains(t))
                            {
                                matches.Add(t);
                            }
                        }
                    }
                }
                else if (t is SoloMatch)
                {
                    SoloMatch matchSolo = (SoloMatch)t;
                    if (matchSolo.Players.Contains(player))
                    {
                        if (!matches.Contains(t))
                        {
                            matches.Add(t);
                        }
                    }
                }
            }
            return matches;
        }

        /// <summary>
        /// Returns all players
        /// </summary>
        /// <returns> all players </returns>
        public List<PlayerType> GetPlayers()
        {
            return backend.Players;
        }

        public List<PlayerType> GetPlayersForgame(GameType game)
        {
            List<PlayerType> players = new List<PlayerType>();
            foreach (MatchType match in backend.MatchList)
            {
                if (match is SoloMatch)
                {
                    SoloMatch soloM = (SoloMatch)match;
                    if (match.GameID == game)
                    {
                        foreach (PlayerType p in soloM.Players)
                        {
                            if (!players.Contains(p))
                            {
                                players.Add(p);
                            }
                        }
                    }
                }
                else if (match is TeamMatch)
                {
                    TeamMatch teamM = (TeamMatch)match;
                    if (match.GameID == game)
                    {
                        foreach (TeamType t in teamM.Teams)
                        {
                            foreach (PlayerType p in t.Members)
                            {
                                if (!players.Contains(p))
                                {
                                    players.Add(p);
                                }
                            }
                        }
                    }
                }
            }
            return players;
        }
    }
}
