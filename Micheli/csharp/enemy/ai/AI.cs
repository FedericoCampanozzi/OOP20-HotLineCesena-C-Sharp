using System;
using System.Collections.Generic;
using Micheli.enemy.ai.strategy;
using Micheli.utils;

namespace Micheli.enemy.ai
{
    /// <summary>
    /// Class that represent the generic AI implementation.
    /// </summary>
    class AI : IAI
    {
        private const int FIELD_OF_VIEW = 90;
        private const int VISION_RADIUS = 5;
        private const int HALF = 2;
        private const double LOOK_NORTH = -90;
        private const double LOOK_SOUTH = 90;
        private const double LOOK_EAST = 0;
        private const double LOOK_EAST_NORTH = -45;
        private const double LOOK_EAST_SOUTH = 45;
        private const double LOOK_WEST = 180;
        private const double LOOK_WEST_NORTH = -135;
        private const double LOOK_WEST_SOUTH = 135;

        private IMovementStrategy _strategy;
        private Point2D _current;
        private Point2D _nextMove;
        private double _rotation;

        public HashSet<Point2D> GetWallSet { get; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="pos">the starting enemy pos</param>
        /// <param name="type">the type of enemy</param>
        /// <param name="rotation">the starting rotation of the enemy</param>
        /// <param name="walls">the collections of points that impare the enemy's sight</param>
        public AI(Point2D pos, EnemyType type, double rotation,
            HashSet<Point2D> walls)
        {
            this._current = pos;
            this._strategy = this.GetStrategy(type);
            this._rotation = rotation;
            this.GetWallSet = walls;
        }

        /// <summary>
        /// Gests the enemy movement strategy based on EnemyType
        /// </summary>
        /// <param name="type">the type of enemy</param>
        /// <returns>a new MovementStrategy</returns>
        private IMovementStrategy GetStrategy(EnemyType type)
        {
            switch(type)
            {
                case EnemyType.IDLE:
                    return new Idle();
                case EnemyType.RANDOM_MOVEMENT:
                    return new RandomMovement();
                case EnemyType.PATROLLING:
                    return new Patrolling();
                default:
                    return null;
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
                return LOOK_NORTH;
            else if (this._nextMove.Equals(new Point2D(-1, 0)))
                return LOOK_EAST;
            else if (this._nextMove.Equals(new Point2D(0, 1)))
                return LOOK_SOUTH;
            else if (this._nextMove.Equals(new Point2D(1, 0)))
                return LOOK_WEST;
            else if (this._nextMove.Equals(new Point2D(-1, 1)))
                return LOOK_WEST_SOUTH;
            else if (this._nextMove.Equals(new Point2D(1, 1)))
                return LOOK_EAST_SOUTH;
            else if (this._nextMove.Equals(new Point2D(1, -1)))
                return LOOK_EAST_NORTH;
            else if (this._nextMove.Equals(new Point2D(-1, -1)))
                return LOOK_WEST_NORTH;
            else
                return this._rotation;
        }

        /// <summary>
        /// Returns the direction that the enemy should
        /// face based of his rotation to target
        /// </summary>
        /// <param name="target">the player position</param>
        /// <returns>the new enemy rotation</returns>
        private double RotationToTarget(Point2D target)
        {
            double distanceX, distanceY;

            distanceX = Math.Abs(target._x - this._current._y);
            distanceY = Math.Abs(target._x - this._current._y);

            return ToDegrees(Math.Atan2(this._current._y > target._y ? -distanceY : distanceY,
                    this._current._x > target._x ? -distanceX : distanceX));
        }

        /// <summary>
        /// Returns if the target is within a certain
        /// radius from the current enemy position
        /// </summary>
        /// <param name="target">the player position</param>
        /// <param name="radius">the radius of the area</param>
        /// <returns>if the target is withing the radius</returns>
        private bool IsInArea(Point2D target, int radius)
        {
            return ((target._x - this._current._x) * (target._x - this._current._x) 
                + (target._y - this._current._y * (target._y - this._current._y))) <= radius * radius;
        }

        /// <summary>
        /// Returns if the target is withing the enemy field of
        /// view and if it's not obstructed by a wall
        /// </summary>
        /// <param name="target">the player position</param>
        /// <returns></returns>
        private bool InLineOfSight(Point2D target)
        {
            double negative45DegreesAngle = this._rotation - (FIELD_OF_VIEW / HALF);
            double positive45DegreesAngle = this._rotation + (FIELD_OF_VIEW / HALF);

            return this.RotationToTarget(target) >= negative45DegreesAngle
                    && this.RotationToTarget(target) <= positive45DegreesAngle
                    && !EnemyPhysicsUtils.IsWallInBetween(target, this._current, this.GetWallSet);
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
            return this.IsInArea(target, VISION_RADIUS) && this.InLineOfSight(target);
        }

        public Point2D SetEnemyPos
        {
            set => this._current = value;
        }
    }
}
