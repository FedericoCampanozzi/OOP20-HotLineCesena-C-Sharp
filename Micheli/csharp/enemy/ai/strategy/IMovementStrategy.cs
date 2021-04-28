using System.Collections.Generic;
using Micheli.utils;

namespace Micheli.enemy.ai.strategy
{
    /// <summary>
    /// Model the enemy movement pattern.
    /// </summary>
    public interface IMovementStrategy
    {
        /// <summary>
        /// Returns the next point for the enemy to move to.
        /// </summary>
        /// <param name="enemy">the enemy position</param>
        /// <param name="player">the player position</param>
        /// <param name="pursuit">the state in which the enemy is in</param>
        /// <param name="map">the collections of points that are walkable by the enemy</param>
        /// <returns>a new position to move to</returns>
        Point2D Move(Point2D enemy, Point2D player, bool pursuit, HashSet<Point2D> map);
    }
}
