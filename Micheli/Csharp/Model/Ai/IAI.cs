using System.Collections.Generic;
using Micheli.Utils;

namespace Micheli.Model.Ai
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
        /// Gets the collections of points that impair the enemy's sight.
        /// </summary>
        HashSet<Point2D> GetWallSet { get; }

        /// <summary>
        /// Returns the next position that the enemy will move to.
        /// </summary>
        /// <param name="target">the player position</param>
        /// <param name="pursuit">the state in which the enemy is in</param>
        /// <param name="map">the collections of points that are walkable by the enemy</param>
        /// <returns>the next point that the enemy will move to</returns>
        Point2D GetNextMove(Point2D target, bool pursuit, HashSet<Point2D> map);

        /// <summary>
        /// Returns the new rotation that the enemy will face.
        /// </summary>
        /// <param name="target">the player position</param>
        /// <param name="pursuit">the state in which the enemy is in</param>
        /// <returns>the value of rotation that the enemy should face</returns>
        double GetRotation(Point2D target, bool pursuit);

        /// <summary>
        /// Returns if the enemy is chasing the target or not.
        /// </summary>
        /// <param name="target">the player position</param>
        /// <param name="noise">the radius of the noise emitted by the player</param>
        /// <returns>the state in which the enemy will be in</returns>
        bool IsInPursuit(Point2D target, double noise);

        /// <summary>
        /// Returns if the enemy is shooting the target or not.
        /// </summary>
        /// <param name="target">the player position</param>
        /// <returns>the state in which the enemy will be in</returns>
        bool IsShooting(Point2D target);
    }
}
