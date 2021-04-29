using System.Collections.Generic;
using System.Linq;

namespace Micheli.utils
{
    /// <summary>
    /// Collection of static methods to check enemy physics.
    /// </summary>
    public static class EnemyPhysicsUtils
    {
        public const int MapDimension = 1;

        /// <summary>
        /// Returns if the position that wants to be reached
        /// is walkable by the enemy.
        /// </summary>
        /// <param name="current">the enemy position</param>
        /// <param name="next">the next move</param>
        /// <param name="map">the collections of points that are walkable by the enemy</param>
        /// <returns>if the next position is walkable</returns>
        public static bool IsMovementAllowed(Point2D current, Point2D next, HashSet<Point2D> map)
        {            
            return map.ToList().Exists(e => e.Equals(MathUtility.RoundedSumPoint2D(current, next)));
        }

        /// <summary>
        /// Returns if the field of view between the enemy
        /// and the target is obscured by a wall.
        /// </summary>
        /// <param name="current">the enemy position</param>
        /// <param name="target">the target position</param>
        /// <param name="walls">the collections of points that obscure the enemy vision</param>
        /// <returns>if the enemy has a clear line of sight</returns>
        public static bool IsWallInBetween(Point2D current, Point2D target, HashSet<Point2D> walls)
        {
            int x = (int)current.X;
            int y = (int)current.Y;

            int distanceX = x - (int)target.X;
            int distanceY = y - (int)target.Y;

            if (distanceX == 0 && distanceY == 0)
            {
                return false;
            }

            while ((distanceX > 0 ? x > target.X : x < target.X) || (distanceY > 0 ? y > target.Y : y < target.Y))
            {
                if (walls.ToList().Exists(e => e.Equals(new Point2D(x, y))))
                {
                    return true;
                }

                if (distanceX != 0)
                {
                    x = distanceX > 0 ? x - 1 : x + 1;
                }

                if (distanceY != 0)
                {
                    y = distanceY > 0 ? y - 1 : y + 1;
                }

            }
            return false;
        }
    }
}
