using System;
using System.Collections.Generic;
using Micheli.enemy.ai.strategy;
using Micheli.utils;

namespace Micheli.enemy.ai
{
    /// <summary>
    /// Class that represent the generic AI implementation.
    /// </summary>
    public class AI : IAI
    {
        private const int FieldOfView = 90;
        private const int VisionRadius = 5;
        private const int Half = 2;
        private const double LookNorth = -90;
        private const double LookSouth = 90;
        private const double LookEast = 0;
        private const double LookEastNorth = -45;
        private const double LookEastSouth = 45;
        private const double LookWest = 180;
        private const double LookWestNorth = -135;
        private const double LookWestSouth = 135;

        private IMovementStrategy _strategy;
        private Point2D _current;
        private Point2D _nextMove;
        private double _rotation;

        /// <summary>
        /// Initializes a new instance of the <see cref="AI"/> class.
        /// </summary>
        /// <param name="pos">the starting enemy pos</param>
        /// <param name="type">the type of enemy</param>
        /// <param name="rotation">the starting rotation of the enemy</param>
        /// <param name="walls">the collections of points that impair the enemy's sight</param>
        public AI(Point2D pos, EnemyType type, double rotation, HashSet<Point2D> walls)
        {
            this._current = pos;
            this._strategy = this.GetStrategy(type);
            this._rotation = rotation;
            this.GetWallSet = walls;
        }

        public HashSet<Point2D> GetWallSet { get; }

        public Point2D SetEnemyPos
        {
            set => this._current = value;
        }

        public Point2D GetNextMove(Point2D target, bool pursuit, HashSet<Point2D> map)
        {
            this._nextMove = this._strategy.Move(this._current, target, pursuit, map);
            return this._nextMove;
        }

        public double GetRotation(Point2D target, bool pursuit)
        {
            this._rotation = !pursuit ? this.RotationToDirection() : this.RotationToTarget(target);
            return this._rotation;
        }

        public bool IsInPursuit(Point2D target, double noise)
        {
            return this.IsInArea(target, (int)noise) || this.IsShooting(target);
        }

        public bool IsShooting(Point2D target)
        {
            return this.IsInArea(target, VisionRadius) && this.InLineOfSight(target);
        }

        /// <summary>
        /// Gests the enemy movement strategy based on EnemyType
        /// </summary>
        /// <param name="type">the type of enemy</param>
        /// <returns>a new MovementStrategy</returns>
        private IMovementStrategy GetStrategy(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Idle:
                    return new Idle();
                case EnemyType.RandomMovement:
                    return new RandomMovement();
                case EnemyType.Patrolling:
                    return new Patrolling();
                default:
                    throw new NullReferenceException();
            }
        }

        private double ToDegrees(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        /// <summary>
        /// Returns the direction that the enemy should
        /// face based of his movement
        /// </summary>
        /// <returns>the new enemy rotation</returns>
        private double RotationToDirection()
        {
            if (this._nextMove.Equals(new Point2D(0, -1)))
            {
                return LookNorth;
            }
            else if (this._nextMove.Equals(new Point2D(-1, 0)))
            {
                return LookEast;
            }
            else if (this._nextMove.Equals(new Point2D(0, 1)))
            {
                return LookSouth;
            }
            else if (this._nextMove.Equals(new Point2D(1, 0)))
            {
                return LookWest;
            }
            else if (this._nextMove.Equals(new Point2D(-1, 1)))
            {
                return LookWestSouth;
            }
            else if (this._nextMove.Equals(new Point2D(1, 1)))
            {
                return LookEastSouth;
            }
            else if (this._nextMove.Equals(new Point2D(1, -1)))
            {
                return LookEastNorth;
            }
            else if (this._nextMove.Equals(new Point2D(-1, -1)))
            {
                return LookWestNorth;
            }
            else
            {
                return this._rotation;
            }
        }

        /// <summary>
        /// Returns the direction that the enemy should
        /// face based of his rotation to target
        /// </summary>
        /// <param name="target">the player position</param>
        /// <returns>the new enemy rotation</returns>
        private double RotationToTarget(Point2D target)
        {
            double distanceX = Math.Abs(target.X - this._current.Y);
            double distanceY = Math.Abs(target.X - this._current.Y);

            return this.ToDegrees(Math.Atan2(this._current.Y > target.Y ? -distanceY : distanceY, this._current.X > target.X ? -distanceX : distanceX));
        }

        /// <summary>
        /// Returns if the target is within a certain
        /// radius from the current enemy position
        /// </summary>
        /// <param name="target">the player position</param>
        /// <param name="radius">the radius of the area</param>
        /// <returns>if the target is within the radius</returns>
        private bool IsInArea(Point2D target, int radius)
        {
            return (((target.X - this._current.X) * (target.X - this._current.X))
                + ((target.Y - this._current.Y) * (target.Y - this._current.Y))) <= radius * radius;
        }

        /// <summary>
        /// Returns if the target is within the enemy field of
        /// view and if it's not obstructed by a wall
        /// </summary>
        /// <param name="target">the player position</param>
        /// <returns>if the target is in sight</returns>
        private bool InLineOfSight(Point2D target)
        {
            double negative45DegreesAngle = this._rotation - (FieldOfView / Half);
            double positive45DegreesAngle = this._rotation + (FieldOfView / Half);

            return this.RotationToTarget(target) >= negative45DegreesAngle
                    && this.RotationToTarget(target) <= positive45DegreesAngle
                    && !EnemyPhysicsUtils.IsWallInBetween(target, this._current, this.GetWallSet);
        }
    }
}
