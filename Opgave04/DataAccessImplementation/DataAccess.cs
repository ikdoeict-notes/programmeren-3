using System;
using System.Collections.Generic;
using DataEntities;
using DataAccessInterfaces;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DataAccessImplementation
{
    /// <summary>
    /// Saves and loads all data to / from disk
    /// </summary>
    public class DataAccess : IGameRankingDataAccess
    {
        private static List<GameType> games;
        
        /// <summary>
        /// Gets or sets Games
        /// </summary>
        public List<GameType> Games
        {
            get
            {
                return games;
            }
            set { games = value; }
        }
        private static List<MatchType> matchList;

        /// <summary>
        /// Gets or sets Matchlist
        /// </summary>
        public List<MatchType> MatchList
        {
            get
            {
                return matchList;
            }
            set { matchList = value; }
        }
        private static List<PlayerType> players;

        /// <summary>
        /// Gets or sets Players
        /// </summary>
        public List<PlayerType> Players
        {
            get
            {
                return players;
            }
            set { players = value; }
        }
        private static List<PlayerGameRankingType> rankingList;

        /// <summary>
        /// Gets or sets RankingList
        /// </summary>
        public List<PlayerGameRankingType> RankingList
        {
            get
            {
                return rankingList;
            }
            set { rankingList = value; }
        }
        private static List<TeamType> teams;

        /// <summary>
        /// Gets or sets Teams
        /// </summary>
        public List<TeamType> Teams
        {
            get
            {
                return teams;
            }
            set { teams = value; }
        }

        /// <summary>
        /// Constructor: loads all files
        /// </summary>
        public DataAccess()
        {
            ClearAllData();
            ReadAll();
        }

        /// <summary>
        /// Writes Games to disk
        /// </summary>
        public void SubmitGameListChanges()
        {
            var formatter = new BinaryFormatter();
            using (var file = File.OpenWrite("Games.bin"))
            {
                formatter.Serialize(file, games);
            }
        }

        /// <summary>
        /// Writes matches to disk
        /// </summary>
        public void SubmitmatchListChanges()
        {
            var formatter = new BinaryFormatter();
            using (var file = File.OpenWrite("MatchList.bin"))
            {
                formatter.Serialize(file, matchList);
            }
        }

        /// <summary>
        /// Writes players to disk
        /// </summary>
        public void SubmitPlayerListChanges()
        {
            var formatter = new BinaryFormatter();
            using (var file = File.OpenWrite("Players.bin"))
            {
                formatter.Serialize(file, players);
            }
        }

        /// <summary>
        /// Writes rankings to disk
        /// </summary>
        public void SubmitRankingListChanges()
        {
            var formatter = new BinaryFormatter();
            using (var file = File.OpenWrite("RankingList.bin"))
            {
                formatter.Serialize(file, rankingList);
            }
        }

        /// <summary>
        /// Writes teams disk
        /// </summary>
        public void SubmitTeamListChanges()
        {
            var formatter = new BinaryFormatter();
            using (var file = File.OpenWrite("Teams.bin"))
            {
                formatter.Serialize(file, teams);
            }
            SubmitPlayerListChanges();
        }

        /// <summary>
        /// Clears all data, doesn't remove files
        /// </summary>
        public void ClearAllData()
        {
            games = new List<GameType>();
            matchList = new List<MatchType>();
            players = new List<PlayerType>();
            rankingList = new List<PlayerGameRankingType>();
            teams = new List<TeamType>();
        }

        /// <summary>
        /// Reads all games from disk
        /// </summary>
        private void ReadGames()
        {
            var formatter = new BinaryFormatter();
            try
            {
                if (File.Exists("Games.bin"))
                {
                    using (var f = File.OpenRead("Games.bin"))
                    {
                        games = (List<GameType>)formatter.Deserialize(f);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Reads all players from disk
        /// </summary>
        private void ReadPlayers()
        {
            var formatter = new BinaryFormatter();
            try
            {
                if (File.Exists("Players.bin"))
                {
                    using (var f = File.OpenRead("Players.bin"))
                    {
                        players = (List<PlayerType>)formatter.Deserialize(f);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Reads all teams from disk
        /// </summary>
        private void ReadTeams()
        {
            var formatter = new BinaryFormatter();
            try
            {
                if (File.Exists("Teams.bin"))
                {
                    using (var f = File.OpenRead("Teams.bin"))
                    {
                        teams = (List<TeamType>)formatter.Deserialize(f);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Reads all matches from disk
        /// </summary>
        private void ReadMatches()
        {
            var formatter = new BinaryFormatter();
            try
            {
                if (File.Exists("MatchList.bin"))
                {
                    using (var f = File.OpenRead("MatchList.bin"))
                    {
                        matchList = (List<MatchType>)formatter.Deserialize(f);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Reads all rankings from disk
        /// </summary>
        private void ReadRankings()
        {
            var formatter = new BinaryFormatter();
            try
            {
                if (File.Exists("RankingList.bin"))
                {
                    using (var f = File.OpenRead("RankingList.bin"))
                    {
                        rankingList = (List<PlayerGameRankingType>)formatter.Deserialize(f);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Reads all files from disk
        /// </summary>
        private void ReadAll()
        {
            ReadGames();
            ReadMatches();
            ReadPlayers();
            ReadRankings();
            ReadTeams();
        }

    }
}