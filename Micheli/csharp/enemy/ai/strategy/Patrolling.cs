using System.Collections.Generic;
using Micheli.utils;

namespace Micheli.enemy.ai.strategy
{
    /// <summary>
    /// Class that represent the Patrolling enemy type MovementStrategy implementation.
    /// </summary>
    public class Patrolling : IMovementStrategy
    {
        private Stack<Point2D> _movementStack = new Stack<Point2D>();
        private List<Point2D> _pathfindingList = new List<Point2D>();
        private Point2D _nextMove;

        /// <summary>
        /// Initializes a new instance of the <see cref="Patrolling"/> class.
        /// </summary>
        public Patrolling()
        {
            this.FillStack();
            this._nextMove = this.NewMove();
        }

        public Point2D Move(Point2D enemy, Point2D player, bool pursuit, HashSet<Point2D> map)
        {
            return !pursuit ? this.NormalMovement(enemy, map) : this.PursuitMovement(enemy, player, map);
        }

        /// <summary>
        /// Fills the stack once it's empty.
        /// </summary>
        private void FillStack()
        {
            this._movementStack.Push(new Point2D(-1, 0));
            this._movementStack.Push(new Point2D(0, 1));
            this._movementStack.Push(new Point2D(1, 0));
            this._movementStack.Push(new Point2D(0, -1));
        }

        /// <summary>
        /// Returns a new position to move to.
        /// </summary>
        /// <returns>a new position</returns>
        private Point2D NewMove()
        {
            return this._movementStack.Pop();
        }

        /// <summary>
        /// Returns a new position to move to, following
        /// a clockwise pattern.
        /// </summary>
        /// <param name="pos">the current position</param>
        /// <param name="map">the collections of points that are walkable by the enemy</param>
        /// <returns>a new position</returns>
        private Point2D NormalMovement(Point2D pos, HashSet<Point2D> map)
        {
            this._pathfindingList = new List<Point2D>();

            if (this._movementStack.Count == 0)
            {
                this.FillStack();
            }

            if (!EnemyPhysicsUtils.IsMovementAllowed(pos, this._nextMove, map))
            {
                this._nextMove = this.NewMove();
            }

            return EnemyPhysicsUtils.IsMovementAllowed(pos, this._nextMove, map) ? this._nextMove : new Point2D(0, 0);
        }

        /// <summary>
        /// Returns a new position to move to, the enemy.
        /// Will always move towards the player position.
        /// </summary>
        /// <param name="start">the enemy starting position</param>
        /// <param name="end">the position that wants to be reached</param>
        /// <param name="map">the collections of points that are walkable by the enemy</param>
        /// <returns>a new position</returns>
        private Point2D PursuitMovement(Point2D start, Point2D end, HashSet<Point2D> map)
        {
            Point2D retval = null;

            if (this._pathfindingList.Count == 0
                || !this._pathfindingList[this._pathfindingList.Count - 1].Equals(end))
            {
                this._pathfindingList = Pathfinder.FindPath(start, end, EnemyPhysicsUtils.MapDimension, EnemyPhysicsUtils.MapDimension, map);
            }

            if (this._pathfindingList.Count != 0 && start.Equals(this._pathfindingList[0]))
            {
                retval = new Point2D(this._pathfindingList[0].X - start.X, this._pathfindingList[0].Y - start.Y);
            }

            return retval != null && EnemyPhysicsUtils.IsMovementAllowed(start, retval, map) ? retval : new Point2D(0, 0);
        }
    }
}
