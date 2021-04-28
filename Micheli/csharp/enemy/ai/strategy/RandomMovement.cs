using System;
using System.Collections.Generic;
using Micheli.utils;

namespace Micheli.enemy.ai.strategy
{
    /// <summary>
    /// Class that represent the Random_Movement enemy type MovementStrategy implementation.
    /// </summary>
    public class RandomMovement : IMovementStrategy
    {
        private Point2D _nextMove;

        public Point2D Move(Point2D enemy, Point2D player, bool pursuit, HashSet<Point2D> map)
        {
            var pick = new Random();
            this._nextMove = this.GetRandomDirection(pick.Next(1, 5));

            return EnemyPhysicsUtils.IsMovementAllowed(enemy, this._nextMove, map)
                ? this._nextMove : new Point2D(0, 0);
        }

        private Point2D GetRandomDirection(int rnd)
        {
            switch (rnd)
            {
                case 1:
                    return new Point2D(0, -1);
                case 2:
                    return new Point2D(1, 0);
                case 3:
                    return new Point2D(-1, 0);
                case 4:
                    return new Point2D(0, 1);
                default:
                    return new Point2D(0, 0);
            }
        }
    }
}
