using System.Collections.Generic;
using Micheli.utils;

namespace Micheli.enemy.ai
{
    /// <summary>
    /// Model the AI that will control the enemy.
    /// </summary>
    public interface IAI
    {
        /// <summary>
        /// Sets the enemy position.
        /// </summary>
        Point2D SetEnemyPos { set; }

        /// <summary>
        /// Returns the next position that the enemy will move to.
        /// </summary>
        /// <param name="target">the player position</param>
        /// <param name="pursuit">the state in which the enemy is in</param>
        /// <param name="map">the collections of points that are walkable by the enemy</param>
        /// <returns></returns>
        Point2D GetNextMove(Point2D target, bool pursuit, HashSet<Point2D> map);

        /// <summary>
        /// Returns the new rotation that the enemy will face.
        /// </summary>
        /// <param name="target">the player position</param>
        /// <param name="pursuit">the state in which the enemy is in</param>
        /// <returns></returns>
        double GetRotation(Point2D target, bool pursuit);

        /// <summary>
        /// Returns if the enemy is chasing the target or not.
        /// </summary>
        /// <param name="target">the player position</param>
        /// <param name="noise">the radius of the noise emitted by the player</param>
        /// <returns></returns>
        bool IsInPursuit(Point2D target, double noise);

        /// <summary>
        /// Returns if the enemy is shooting the target or not.
        /// </summary>
        /// <param name="target">the player position</param>
        /// <returns></returns>
        bool IsShooting(Point2D target);

        /// <summary>
        /// Gets the collections of points that impare the enemy's sight.
        /// </summary>
        HashSet<Point2D> GetWallSet { get; }
    }
}
