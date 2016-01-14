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
    /// Contains all match logic
    /// </summary>
    public class MatchLogic : IMatchManipulations
    {
        // connection to backend
        private IGameRankingDataAccess backend;

        /// <summary>
        /// Creates a MatchLogic object
        /// </summary>
        public MatchLogic()
        {
            backend = new DataAccess();
        }

        /// <summary>
        /// Adds or updates a SoloMatch
        /// </summary>
        /// <param name="match"> SoloMatch </param>
        public void AddOrUpdateSoloMatch(SoloMatch match)
        {
            if (backend.MatchList.Contains(match))
            {
                backend.MatchList.Remove(match);
            }
            backend.MatchList.Add(match);
            backend.SubmitmatchListChanges();
            UpdateScores();
            UpdateRankings();
        }

        /// <summary>
        /// Adds or updates a TeamMatch
        /// </summary>
        /// <param name="match"> TeamMatch </param>
        public void AddOrUpdateTeamMatch(TeamMatch match)
        {
            if (backend.MatchList.Contains(match))
            {
                backend.MatchList.Remove(match);
            }
            backend.MatchList.Add(match);
            backend.SubmitmatchListChanges();
            UpdateScores();
            UpdateRankings();

        }

        /// <summary>
        /// Updates all ranking scores
        /// </summary>
        private void UpdateScores()
        {
            
            backend.RankingList.Clear();
            backend.SubmitRankingListChanges();
            // update points
            foreach (MatchType match in backend.MatchList)
            {
                if (match is SoloMatch)
                {
                    SoloMatch soloMatch = (SoloMatch)match;
                    if (soloMatch.Players.Count < 1) continue;
                    int maxPoints = soloMatch.Players.Count + 1;
                    List<int> uniquePoints = GenerateUniqueOrdered(soloMatch.Scores);
                    for (int i = 0; i < uniquePoints.Count; i++)
                    {
                        if (i >= (uniquePoints.Count - 1))
                        {
                            maxPoints = 0;
                            // no point for player
                            for (int j = 0; j < soloMatch.Players.Count; j++)
                            {
                                if (uniquePoints[i] == soloMatch.Scores[j])
                                {
                                    AddPoints(soloMatch.GameID, soloMatch.Players[j], soloMatch.Category, maxPoints);
                                }
                            }
                        }
                        else if (i == 0)
                        {
                            // max points
                            for (int j = 0; j < soloMatch.Players.Count; j++)
                            {
                                if (uniquePoints[i] == soloMatch.Scores[j])
                                {
                                    AddPoints(soloMatch.GameID, soloMatch.Players[j], soloMatch.Category, maxPoints);
                                }
                            }
                            maxPoints -= 2;
                        }
                        else
                        {
                            for (int j = 0; j < soloMatch.Players.Count; j++)
                            {
                                if (uniquePoints[i] == soloMatch.Scores[j])
                                {
                                    AddPoints(soloMatch.GameID, soloMatch.Players[j], soloMatch.Category, maxPoints);
                                }
                            }
                            maxPoints--;
                        }
                    }
                }
                else if (match is TeamMatch)
                {
                    TeamMatch teamMatch = (TeamMatch)match;
                    if (teamMatch.Teams.Count < 1) continue;
                    int maxPoints = teamMatch.Teams.Count + 1;
                    List<int> uniquePoints = GenerateUniqueOrdered(teamMatch.Scores);
                    for (int i = 0; i < uniquePoints.Count; i++)
                    {
                        if (i >= (uniquePoints.Count - 1))
                        {
                            maxPoints = 0;
                            // no point for player
                            for (int j = 0; j < teamMatch.Teams.Count; j++)
                            {
                                if (uniquePoints[i] == teamMatch.Scores[j])
                                {
                                    foreach (PlayerType player in teamMatch.Teams[j].Members)
                                    {
                                        AddPoints(teamMatch.GameID, player, teamMatch.Category, maxPoints);
                                    }
                                }
                            }
                        }
                        else if (i == 0)
                        {
                            // max points
                            for (int j = 0; j < teamMatch.Teams.Count; j++)
                            {
                                if (uniquePoints[i] == teamMatch.Scores[j])
                                {
                                    foreach (PlayerType player in teamMatch.Teams[j].Members)
                                    {
                                        AddPoints(teamMatch.GameID, player, teamMatch.Category, maxPoints);
                                    }
                                }
                            }
                            maxPoints -= 2;
                        }
                        else
                        {
                            for (int j = 0; j < teamMatch.Teams.Count; j++)
                            {
                                if (uniquePoints[i] == teamMatch.Scores[j])
                                {
                                    foreach (PlayerType player in teamMatch.Teams[j].Members)
                                    {
                                        AddPoints(teamMatch.GameID, player, teamMatch.Category, maxPoints);
                                    }
                                }
                            }
                            maxPoints--;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates all rankings (NEEDS VALID SCORES!)
        /// </summary>
        private void UpdateRankings()
        {
            IPlayerManipulations pm = new PlayerLogic();
            // update rankings
            for (int i = 0; i < backend.RankingList.Count; i++)
            {
                PlayerGameRankingType r = backend.RankingList[i];
                if (pm.GetGameMatchesForPlayer(r.Game, r.Player).Count < 4)
                {
                    // player is unranked
                    backend.RankingList[i] = new PlayerGameRankingType(backend.RankingList[i].Game, backend.RankingList[i].Player, backend.RankingList[i].Points, Ranks.Unranked);
                    continue;
                }
                else
                {
                    // get the scores for the game
                    List<int> scoresInGame = new List<int>();
                    foreach (PlayerGameRankingType g in backend.RankingList)
                    {
                        if (g.Game == r.Game)
                        {
                            scoresInGame.Add(g.Points);
                        }
                    }
                    // calculate percentile 
                    int percentile = CalculatePercentile(scoresInGame, r.Points);
                    // update ranking
                    if (percentile < 10)
                    {
                        backend.RankingList[i] = new PlayerGameRankingType(backend.RankingList[i].Game, backend.RankingList[i].Player, backend.RankingList[i].Points, Ranks.Novice);
                    }
                    else if (percentile >= 10 && percentile < 50)
                    {
                        backend.RankingList[i] = new PlayerGameRankingType(backend.RankingList[i].Game, backend.RankingList[i].Player, backend.RankingList[i].Points, Ranks.Competent);
                    }
                    else if (percentile >= 50 && percentile < 85)
                    {
                        backend.RankingList[i] = new PlayerGameRankingType(backend.RankingList[i].Game, backend.RankingList[i].Player, backend.RankingList[i].Points, Ranks.Advanced);
                    }
                    else
                    {
                        backend.RankingList[i] = new PlayerGameRankingType(backend.RankingList[i].Game, backend.RankingList[i].Player, backend.RankingList[i].Points, Ranks.Elite);
                    }
                }
            }
            backend.SubmitRankingListChanges();
        }

        /// <summary>
        /// Returns the percentile of a value in a list
        /// </summary>
        /// <param name="list"> list with values </param>
        /// <param name="value"> value </param>
        /// <returns> percentile </returns>
        private int CalculatePercentile(List<int> list, int value)
        {
            list.Sort();
            int index = list.IndexOf(value);
            if (index < 0)
            {
                return 0;
            }
            return (int)(((double)index + 1.0) / (double)list.Count * 100.0);
        }

        /// <summary>
        /// Will add points to a ranking of a player, score will be multiplied by MatchCategory
        /// </summary>
        /// <param name="game"> game </param>
        /// <param name="player"> player </param>
        /// <param name="cat"> match category </param>
        /// <param name="score"> score </param>
        private void AddPoints(GameType game, PlayerType player, MatchCategories cat, int score)
        {
            int realScore = 0;
            switch (cat)
            {
                case MatchCategories.Training:
                    realScore = score;
                    break;
                case MatchCategories.Competition:
                    realScore = score * 2;
                    break;
                case MatchCategories.Tournament:
                    realScore = score * 3;
                    break;
                default:
                    break;
            }
            PlayerGameRankingType r = new PlayerGameRankingType(game, player, realScore);
            if (backend.RankingList.Contains(r))
            {
                backend.RankingList[backend.RankingList.IndexOf(r)] = new PlayerGameRankingType(game, player, realScore + backend.RankingList[backend.RankingList.IndexOf(r)].Points);
            }
            else
            {
                backend.RankingList.Add(new PlayerGameRankingType(game, player, realScore));
            }
            backend.SubmitRankingListChanges();
        }

        /// <summary>
        /// Sorts a list and removes duplicates (high to low)
        /// </summary>
        /// <param name="list"> list to sort </param>
        /// <returns> sorted list </returns>
        private List<int> GenerateUniqueOrdered(List<int> list)
        {
            List<int> result = new List<int>(list);
            result.Sort();
            result.Reverse();
            result = result.Distinct().ToList();
            return result;
        }

        /// <summary>
        /// Returns all filtered matches
        /// </summary>
        /// <param name="game"> game </param>
        /// <param name="soloOrTeam"> participant type </param>
        /// <param name="matchCategory"> match category </param>
        /// <returns> filtered matches </returns>
        public List<MatchType> GetMatches(GameType game, ParticipantTypes soloOrTeam, MatchCategories matchCategory)
        {
            List<MatchType> matches = new List<MatchType>();
            foreach (MatchType m in backend.MatchList)
            {
                if (m.GameID == game && m.Category == matchCategory)
                {
                    if ((soloOrTeam == ParticipantTypes.Solo) && (m is TeamMatch))
                    {
                        continue;
                    }
                    if ((soloOrTeam == ParticipantTypes.Team) && (m is SoloMatch))
                    {
                        continue;
                    }
                    if (!matches.Contains(m))
                    {
                        matches.Add(m);
                    }
                }
            }
            return matches;
        }


        /// <summary>
        /// Returns all filtered matches
        /// </summary>
        /// <param name="game"> game </param>
        /// <returns> filtered matches </returns>
        public List<MatchType> GetMatchesAll(GameType game)
        {
            List<MatchType> matches = new List<MatchType>();
            foreach (MatchType m in backend.MatchList)
            {
                if (m.GameID == game)
                {
                    if (!matches.Contains(m))
                    {
                        matches.Add(m);
                    }
                }
            }
            return matches;
        }

    }
}
