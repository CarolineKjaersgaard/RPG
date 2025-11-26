using Backend.GameLogic.Game;
using Backend.GameLogic.Player;
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

        public GameTests() 
        {
            player = new PlayerImpl();
            game = new Game(player);
        }

        [Fact]
        public void StartGameReturnsBoolandPlayer()
        {
           (bool, IPlayer) res = game.StartGame();
            Assert.True(res.Item1 && res.Item2 == player);
        }
    }
}
