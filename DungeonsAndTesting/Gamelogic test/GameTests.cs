using Backend.Database;
using Backend.Database.Tables;
using Backend.GameLogic.Game;
using Backend.GameLogic.Player;
using DungeonsAndTesting.Gamelogic_test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndTesting.Gamelogic_test
{
    public class GameTests
    {
        private Game game;
        private IPlayer player; 
        private IDatabase database;

        public GameTests() 
        {
            player = new PlayerImpl();
            database = new TestDatabase();
            game = new Game(player, database);
        }

        [Fact]
        public void StartGameReturnsBoolandPlayer()
        {
           (bool, IPlayer) res = game.StartGame();
            Assert.True(res.Item1 && res.Item2 == player);
        }
    }
}
