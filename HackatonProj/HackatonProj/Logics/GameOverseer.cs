using HackatonProj.Data;
using HackatonProj.Data.Objects;
using HackatonProj.Data.Units;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace HackatonProj.Logics
{
    class GameOverseer
    {
        private const int baseSpawnTime = 2;
        private const float baseSmallestSpawnTime = 0.5f;
        private const int baseMinEnemiesQuantity = 5;
        private const int baseMaxEnemiesQuantity = 50;

        private float timeBetweenSpawns = baseSpawnTime;

        private int maxSpawnedEnemies = baseMinEnemiesQuantity;
        //Place for players
        private List<Player> _listOfPlayers = new List<Player>();
        //Place for enemies
        private List<IEnemy> _listOfEnemies = new List<IEnemy>();
        //Place for bullets
        private List<Bullet> _listOfBullets = new List<Bullet>();

        //kill counter... counts kills... when you kill someone it will increase... by one... it's incrementing by one 
        int _killCounter = 0;
        private const int killsAmount = 50; //Amount of kills required for ULA to spawn.
        private bool isUlaSpawned = false;

        //Increaments kill count by one
        void IncrementKillCount()
        {
            _killCounter++;
        }

        private void UpdateEntitiesMovement(Time lastFrameTime)
        {
            foreach (Player player in _listOfPlayers)
            {
                if(player.IsAlive)
                    player.Move(lastFrameTime);
            }

            foreach (IEnemy enemy in _listOfEnemies)
            {
                if(enemy.IsAlive)
                    enemy.Move(lastFrameTime);
            }

            foreach (Bullet bullet in _listOfBullets)
            {
                bullet.Move(lastFrameTime);
            }
        }
        

        void ChkCollisions()
        {
            foreach (var enemy in _listOfEnemies)
            {
                if (enemy.IsAlive)
                {
                    foreach (var bullet in _listOfBullets)
                    {
                        if (PhysicsEngine.CheckCollision(enemy, bullet))
                        {
                            enemy.ReceiveHit(bullet);
                            if (!enemy.IsAlive)
                            {
                                EnemyKilled();
                            }
                        }
                        else if (PhysicsEngine.CheckBorderCollision(enemy) == PhysicsEngine.borderCollision.Down)
                        {

                        }
                    }
                }
            }

            foreach (var player in _listOfPlayers)
            {
                if (player.IsAlive)
                {
                    foreach (var enemy in _listOfEnemies)
                    {
                        if (enemy.IsAlive && PhysicsEngine.CheckCollision(player, enemy))
                        {
                            player.ReceiveHit(enemy);
                        }
                    }
                }
            }
        }

        public void ModifyPlayerMoveState(Vector2i directionVector, Enums.players player)
        {
            if (_listOfPlayers[(int) player].IsAlive)
            {
                _listOfPlayers[(int) player].MultiplyVelocity(directionVector);
            }
        }
        public void ModifyPlayerShotState(bool isShooting, Enums.players player)
        {
            if (isShooting && _listOfPlayers[(int)player].IsAlive) //If the player fired a bullet, add it to listOfBullets
            {
                _listOfBullets.Add(_listOfPlayers[(int)player].Shoot());
            }
        }

        public void PerformGameLoop(Time lastFrameTime)
        {
            UpdateEntitiesMovement(lastFrameTime);
            ChkCollisions();

            if (_killCounter >= killsAmount && !isUlaSpawned)
            {
                SpawnULA();
            }
            else
            {
                ModifyWave();
                RespawnWave(lastFrameTime.AsSeconds());
            }
        }

        public void DrawEntities(Action<Drawable> DrawObj)
        {
            foreach (Bullet bullet in _listOfBullets)
            {
                DrawObj(bullet);
            }

            foreach (Player player in _listOfPlayers)
            {
                if(player.IsAlive)
                    DrawObj(player);
            }

            foreach (IEnemy enemy in _listOfEnemies)
            {
                if (enemy.IsAlive)
                    DrawObj(enemy);
            }
        }

        private void ModifyWave()
        {
            if (_listOfEnemies.Count < maxSpawnedEnemies)
            {
                Random randomGenerator = new Random();
                if (_killCounter % 3 == 0)
                {
                    switch (randomGenerator.Next(0, 1))
                    {
                        case 0:
                            _listOfEnemies.Add(new And());
                            break;
                        case 1:
                            _listOfEnemies.Add(new Or());
                            break;
                        default: throw new Exception("WTF !? in EnemyKilled() #1");
                    }
                }
                else if (_killCounter % 5 == 0)
                {
                    switch (randomGenerator.Next(0, 1))
                    {
                        case 0:
                            _listOfEnemies.Add(new Nand());
                            break;
                        case 1:
                            _listOfEnemies.Add(new Nor());
                            break;
                        default: throw new Exception("WTF !? in EnemyKilled() #2");
                    }
                }

                _listOfEnemies.Last().Launch(randomGenerator.Next(100));
            }
        }

        private void RespawnWave(float lastFrameTime)
        {
            Random random = new Random();
            foreach (var enemy in _listOfEnemies)
            {
                if (!enemy.IsAlive)
                {
                    enemy.Respawn(lastFrameTime, timeBetweenSpawns, random.Next(200));
                }
            }
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

        public void SpawnULA()
        {
            isUlaSpawned = true;
            for(int i = _listOfEnemies.Count; i >= 0; i--)
            {
                _listOfEnemies.RemoveAt(i);
            }

            _listOfEnemies.Add(new ULA());
            _listOfEnemies.Last().Launch(20);
        }

        public void EnemyKilled()
        {
            IncrementKillCount();
            if (maxSpawnedEnemies < baseMaxEnemiesQuantity)
            {
                maxSpawnedEnemies++;
            }

            if (timeBetweenSpawns < baseSmallestSpawnTime)
            {
                timeBetweenSpawns -= 0.05f;
            }
        }
    }
}
