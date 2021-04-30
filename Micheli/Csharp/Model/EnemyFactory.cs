using System;
using System.Collections.Generic;
using Micheli.Utils;

namespace Micheli.Model
{
    /// <summary>
    /// Class that represent the generic factory implementation.
    /// </summary>
    public class EnemyFactory : IEnemyFactory
    {
        public Enemy GetEnemy(Point2D pos, EnemyType type, HashSet<Point2D> walkable, HashSet<Point2D> walls)
        {
            switch (type)
            {
                case EnemyType.Boss:
                    return new Enemy(pos, new NaiveInventory(), RandomRotation(), EnemyType.Patrolling, walkable, walls);
                default:
                    return new Enemy(pos, new NaiveInventory(), RandomRotation(), type, walkable, walls);
            }
        }

        /// <summary>
        /// Returns a random rotation for the enemy to face
        /// </summary>
        /// <returns>a random rotation</returns>
        private static double RandomRotation() => new Random().Next(360);
    }
}
