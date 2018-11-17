using HackatonProj.Data;
using HackatonProj.Data.Objects;
using HackatonProj.Data.Units;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonProj.Logics
{
    class GameOverseer
    {
        //Place for players
        List<Player> _listOfPlayers = new List<Player>();
        //Place for enemies
        List<IEnemy> _listOfEnemies = new List<IEnemy>();
        //Place for bullets
        List<Bullet> _listOfBullets = new List<Bullet>();

        //kill counter... counts kills... when you kill someone it will increse... by one... it's incrementing by one 
        int _killCounter = 0;

        //Increaments kill count by one
        void IncrementKillCount()
        {
            _killCounter++;
        }

        private void ResetPlayersVelocities()
        {
            foreach (Player player in _listOfPlayers)
            {
                player.ResetVelocity();
            }
        }


        public void ModifyPlayerMoveShotState(Tuple<Vector2i, bool> movementAndShot, Enums.players player)
        {
            _listOfPlayers[(int)player].MultiplyVelocity(movementAndShot.Item1);

            if (movementAndShot.Item2) //If the player fired a bullet, add it to listOfBullets
            {
                _listOfBullets.Add(_listOfPlayers[(int)player].Shoot());
            }
        }
        public void PerformGameLoop(Time lastFrameTimeSeconds)
        {
             ResetPlayersVelocities();
        }

        //
        //Sets players & enemies
        public GameOverseer()
        {
            _listOfEnemies.Add(new And());
            _listOfEnemies.Add(new Or());
            _listOfEnemies.Add(new Nand());
            _listOfEnemies.Add(new Nor());

            Random randomGenerator = new Random();

            foreach (IEnemy enemy in _listOfEnemies)
            {
                enemy.Launch(randomGenerator.Next(100));
            }

            _listOfPlayers.Add(new Player("Owlosiony Czarodziej"));
            _listOfPlayers.Add(new Player("Sqrt(i)"));

            foreach(Player player in _listOfPlayers)
            {
                player.MoveTo(new Vector2f(WindowData.windowSize.X * (float)0.5, WindowData.windowSize.Y - 128));
            }
        }

        public void KillCountEnough()
        {
            for(int i = _listOfEnemies.Count; i >= 0; i--)
            {
                _listOfEnemies.RemoveAt(i);
            }

            _listOfEnemies.Add(new ULA());
            _listOfEnemies.Last().Launch(20);
        }

        public void EnemyKilled()
        {
            Random randomGenerator = new Random();

            IncrementKillCount();

            if(_killCounter % 3 == 0)
            {
                switch(randomGenerator.Next(0,1))
                {
                    case 0: _listOfEnemies.Add(new And()); break;
                    case 1: _listOfEnemies.Add(new Or()); break;
                    default: throw new Exception("WTF !? in EnemyKilled() #1");
                }
            }
            else
            if(_killCounter % 5 == 0)
            {
                switch (randomGenerator.Next(0, 1))
                {
                    case 0: _listOfEnemies.Add(new Nand()); break;
                    case 1: _listOfEnemies.Add(new Nor()); break;
                    default: throw new Exception("WTF !? in EnemyKilled() #2");
                }
            }
            _listOfEnemies.Last().Launch(randomGenerator.Next(100));
        }
    }
}
