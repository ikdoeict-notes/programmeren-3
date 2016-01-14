using System.Collections.Generic;
using System.Linq;
using DataEntities;
using LogicInterfaces;
using DataAccessInterfaces;
using DataAccessImplementation;
using System;

namespace LogicImplementation
{
    public class Ranking: IGameManipulations, IMatchManipulations, IPlayerManipulations, IRankingSource, ITeamManipulations
    {
        /// <summary>
        /// Connection to backend
        /// </summary>
        private IGameRankingDataAccess backend;
        public Ranking()
        {
            backend = new DataAccess();
        }

        public void AddOrUpdateGame(GameType game)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdatePlayer(PlayerType player)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdateSoloMatch(SoloMatch match)
        {
            throw new NotImplementedException();
        }

        public bool AddOrUpdateTeam(TeamType team)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdateTeamMatch(TeamMatch match)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetGameMatchesForPlayer(GameType game, PlayerType player)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetGameMatchesForTeam(GameType game, TeamType team)
        {
            throw new NotImplementedException();
        }

        public List<PlayerGameRankingType> GetGameRankings(GameType game, ParticipantTypes soloOrTeam, Ranks rank)
        {
            throw new NotImplementedException();
        }

        public List<PlayerGameRankingType> GetGameRankingsAll(GameType game, ParticipantTypes soloOrTeam)
        {
            throw new NotImplementedException();
        }

        public List<GameType> GetGames()
        {
            throw new NotImplementedException();
        }

        public List<GameType> GetGamesForPlayer(PlayerType player)
        {
            throw new NotImplementedException();
        }

        public List<GameType> GetGamesForTeam(TeamType team)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetMatches(GameType game, ParticipantTypes soloOrTeam, MatchCategories matchCategory)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetMatchesAll(GameType game)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetMatchesForPlayer(PlayerType player)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetMatchesForTeam(TeamType team)
        {
            throw new NotImplementedException();
        }

        public List<PlayerType> GetPlayers()
        {
            throw new NotImplementedException();
        }

        public List<PlayerType> GetPlayersForgame(GameType game)
        {
            throw new NotImplementedException();
        }

        public List<TeamType> GetTeams()
        {
            throw new NotImplementedException();
        }

        public List<TeamType> GetTeamsforGame(GameType game)
        {
            throw new NotImplementedException();
        }
    }
}
