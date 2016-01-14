using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicImplementation;
using LogicInterfaces;
using DataEntities;

namespace ConsoleUI
{
    /// <summary>
    /// Tests the Solution
    /// </summary>
    class Program
    {
        // Main entry point
        static void Main(string[] args)
        {
            Program p = new Program();
            AddGames();
            AddPlayers();
            AddSoloMatch();
            AddTeamMatch();
        }

        static void Wait()
        {
            Console.WriteLine("\nEnter to continue...");
            Console.ReadKey();
        }

        static void AddGames()
        {
            IGameManipulations gameLogic = new GameLogic();
            // add games
            Console.WriteLine("-> adding games...");
            Console.WriteLine("\t\t#Method AddOrUpdateGame()");
            gameLogic.AddOrUpdateGame(new GameType("GTA 5", ParticipantTypes.All));
            gameLogic.AddOrUpdateGame(new GameType("World of Warcraft", ParticipantTypes.Solo));
            gameLogic.AddOrUpdateGame(new GameType("Rome 2", ParticipantTypes.Team));
            // print games
            Console.WriteLine("\t\t#Method GameType.ToString()");
            Console.WriteLine("------- Games -------");
            foreach (GameType g in gameLogic.GetGames())
            {
                Console.WriteLine("  " + g.ToString());
            }
            Console.WriteLine("------- @@@@@ -------\n\n");
            // wait for user
            Wait();
        }

        static void AddPlayers()
        {
            IPlayerManipulations playerLogic = new PlayerLogic();
            // add players
            Console.WriteLine("-> adding players...");
            Console.WriteLine("\t\t#Method AddOrUpdatePlayer()");
            playerLogic.AddOrUpdatePlayer(new PlayerType("Jonas@mail.com", "Jonas", "Jonas_tag"));
            playerLogic.AddOrUpdatePlayer(new PlayerType("Lien@mail.com", "Lien", "Lien_tag"));
            playerLogic.AddOrUpdatePlayer(new PlayerType("Bart@mail.com", "Bart", "Bart_tag"));
            playerLogic.AddOrUpdatePlayer(new PlayerType("Yana@mail.com", "Yana", "Yana_tag"));
            // print players
            Console.WriteLine("\t\t#Method PlayerType.ToString()");
            Console.WriteLine("------- Players -------");
            foreach (PlayerType p in playerLogic.GetPlayers())
            {
                Console.WriteLine("  " + p.ToString());
            }
            Console.WriteLine("------- @@@@@ -------\n\n");
            // wait for user
            Wait();
        }

        static void AddSoloMatch()
        {
            IPlayerManipulations playerLogic = new PlayerLogic();
            IGameManipulations gameLogic = new GameLogic();
            IMatchManipulations matchLogic = new MatchLogic();
            IRankingSource rankingLogic = new RankingLogic();

            // add match between 2 players
            List<PlayerType> players = playerLogic.GetPlayers();
            List<GameType> games = gameLogic.GetGames();
            Console.WriteLine("-> adding match (Solo)...");
            Console.WriteLine("\t\t#Method AddOrUpdateSoloMatch()");
            matchLogic.AddOrUpdateSoloMatch(new SoloMatch(new List<PlayerType> { players[0], players[2] }, new List<int> { 2500, 2300 }, MatchCategories.Competition, games[0]));
            // print match
            Console.WriteLine("\t\t#Method GetMatches()");
            Console.WriteLine("\t\t#Method SoloMatch.ToString()");
            Console.WriteLine("------- First Match -------");
            SoloMatch solo = (SoloMatch)matchLogic.GetMatches(games[0], ParticipantTypes.Solo, MatchCategories.Competition)[0];
            Console.WriteLine(solo.ToString());
            Console.WriteLine("------- @@@@@ -------\n\n");

            // print ranking
            Console.WriteLine("\t\t#Method GetGameRankingsAll()");
            Console.WriteLine("------- Ranking Game -------");
            foreach (PlayerGameRankingType g in rankingLogic.GetGameRankingsAll(games[0], ParticipantTypes.All))
            {
                Console.WriteLine(g.ToString());
            }
            Console.WriteLine("------- @@@@@ -------\n\n");
            // wait for user
            Wait();
        }

        static void AddTeamMatch()
        {
            IPlayerManipulations playerLogic = new PlayerLogic();
            IGameManipulations gameLogic = new GameLogic();
            ITeamManipulations teamLogic = new TeamLogic();
            IMatchManipulations matchLogic = new MatchLogic();
            IRankingSource rankingLogic = new RankingLogic();

            List<PlayerType> players = playerLogic.GetPlayers();
            List<GameType> games = gameLogic.GetGames();
            // add team
            Console.WriteLine("-> adding teams...");
            Console.WriteLine("\t\t#Method AddOrUpdateTeam()");
            teamLogic.AddOrUpdateTeam(new TeamType("FirstTeam", new List<PlayerType> { players[0] }));
            teamLogic.AddOrUpdateTeam(new TeamType("SecondTeam", new List<PlayerType> { players[2] }));

            // print teams
            Console.WriteLine("\t\t#Method TeamType.ToString()");
            Console.WriteLine("------- Teams Game -------");
            foreach (TeamType t in teamLogic.GetTeams())
            {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("------- @@@@@ -------\n\n");
            // wait for user
            Wait();

            // add match between 2 teams
            Console.WriteLine("-> adding team match...");
            Console.WriteLine("\t\t#Method GetTeams()");
            List<TeamType> teams = teamLogic.GetTeams();
            Console.WriteLine("\t\t#Method AddOrUpdateTeamMatch()");
            matchLogic.AddOrUpdateTeamMatch(new TeamMatch(MatchCategories.Competition, games[0], new List<TeamType> { teams[0], teams[1] }, new List<int> { 200, 3000 }));
            // print match
            Console.WriteLine("\t\t#Method GetMatchesForTeam()");
            Console.WriteLine("------- First Team Match -------");
            TeamMatch team = (TeamMatch)teamLogic.GetMatchesForTeam(teams[0])[0];
            Console.WriteLine(team.ToString());
            Console.WriteLine("------- @@@@@ -------\n\n");


            // print ranking
            Console.WriteLine("\t\t#Method GetGameRankingsAll()");
            Console.WriteLine("------- Ranking Game -------");
            foreach (PlayerGameRankingType g in rankingLogic.GetGameRankingsAll(games[0], ParticipantTypes.All))
            {
                Console.WriteLine(g.ToString());
            }
            Console.WriteLine("------- @@@@@ -------\n\n");
            // wait for user
            Wait();
        }
    }
}
