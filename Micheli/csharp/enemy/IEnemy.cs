using System.Collections.Generic;
using Micheli.enemy.ai;
using Micheli.utils;

namespace Micheli.enemy
{
    /// <summary>
    /// Models the Enemy entity.
    /// </summary>
    public interface IEnemy
    {
        /// <summary>
        /// Gets the current position of the enemy.
        /// </summary>
        Point2D GetPosition { get; }

        /// <summary>
        /// Gets the current rotation of the enemy.
        /// </summary>
        double GetRotation { get; set; }

        /// <summary>
        /// Moves the enemy to the indicated direction.
        /// </summary>
        /// <param name="direction">the point to move to</param>
        void executeMovement(Point2D direction);

        /// <summary>
        /// Gets the AI of the enemy.
        /// </summary>
        IAI GetAI { get; }

        /// <summary>
        /// Gets the type of the enemy.
        /// </summary>
        EnemyType GetEnemyType { get; }

        /// <summary>
        /// Gest or Sets if the enemy is chasing the target.
        /// </summary>
        bool Pursuit { get; set; }

        /// <summary>
        /// Gets the collections of points that are walkable by the enemy.
        /// </summary>
        HashSet<Point2D> GetWalkable { get; }
    }
}
