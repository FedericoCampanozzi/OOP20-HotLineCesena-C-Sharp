using System.Collections.Generic;
using Micheli.utils;

namespace Micheli.enemy
{
    /// <summary>
    /// Model a factory that generate enemies.
    /// </summary>
    public interface IEnemyFactory
    {
        /// <summary>
        /// Get an instance of a new Enemy.
        /// </summary>
        /// <param name="pos">the starting position</param>
        /// <param name="type">the enemy type</param>
        /// <param name="walkable">the collections of points that are walkable by the enemy</param>
        /// <param name="walls">the collections of points that impair the enemy's sight</param>
        /// <returns>the new Enemy</returns>
        Enemy GetEnemy(Point2D pos, EnemyType type, HashSet<Point2D> walkable, HashSet<Point2D> walls);
    }
}
