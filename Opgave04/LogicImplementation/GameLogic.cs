using DataAccessImplementation;
using DataAccessInterfaces;
using LogicInterfaces;
using System.Collections.Generic;
using DataEntities;

namespace LogicImplementation
{
    /// <summary>
    /// Contains all logic for games
    /// </summary>
    public class GameLogic : IGameManipulations
    {
        // connection to backend
        private IGameRankingDataAccess backend;

        /// <summary>
        /// Creates a GameLogic object
        /// </summary>
        public GameLogic()
        {
            backend = new DataAccess();
        }

        /// <summary>
        /// Adds or updates a game
        /// </summary>
        /// <param name="game"> game </param>
        public void AddOrUpdateGame(GameType game)
        {
            if (game == null)
            {
                throw new System.InvalidOperationException("Game is null");
            }
            if (backend.Games.Contains(game))
            {
                backend.Games.Remove(game);
            }
            backend.Games.Add(game);
            backend.SubmitGameListChanges();
        }

        /// <summary>
        /// returns all the games
        /// </summary>
        /// <returns></returns>
        public List<GameType> GetGames()
        {
            return backend.Games;
        }
    }
}
