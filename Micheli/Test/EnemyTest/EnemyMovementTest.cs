using System.Collections.Generic;
using Micheli.Model;
using Micheli.Utils;
using NUnit.Framework;

namespace Micheli.Test.EnemyTest
{
    /// <summary>
    /// Models a test class for Enemy movements.
    /// </summary>
    public class EnemyMovementTest
    {
        private HashSet<Point2D> _walkable = new HashSet<Point2D>();
        private HashSet<Point2D> _walls = new HashSet<Point2D>();
        private IEnemy _enemyIdle;
        private IEnemy _enemyPatrolling;
        private Point2D _target = new Point2D(2, 0);

        [SetUp]
        public void SetUp()
        {
            for (int y = 0; y <= EnemyPhysicsUtils.MapDimension; y++)
            {
                for (int x = 0; x <= EnemyPhysicsUtils.MapDimension; x++)
                {
                    this._walkable.Add(new Point2D(x, y));
                }
            }

            this._enemyIdle = new EnemyFactory().GetEnemy(new Point2D(0, 0), EnemyType.Idle, this._walkable, this._walls);
            this._enemyPatrolling = new EnemyFactory().GetEnemy(new Point2D(0, 0), EnemyType.Patrolling, this._walkable, this._walls);
        }

        [Test]
        public void EnemyIdle()
        {
            this._enemyIdle.ExecuteMovement(this._enemyIdle.GetAI.GetNextMove(this._target, false, this._enemyIdle.GetWalkable));

            // enemy remains stationary
            Assert.True(this._enemyIdle.GetPosition.Equals(new Point2D(0, 0)));
        }

        [Test]
        public void EnemyMoveTest()
        {
            Assert.IsNotNull(this._enemyPatrolling.GetAI);

            // moves clockwise
            this._enemyPatrolling.ExecuteMovement(
                this._enemyPatrolling.GetAI.GetNextMove(
                    this._target,
                    false, 
                    this._enemyPatrolling.GetWalkable));

            Assert.True(this._enemyPatrolling.GetPosition.Equals(new Point2D(1, 0)));

            // moves clockwise
            this._enemyPatrolling.ExecuteMovement(this._enemyPatrolling.GetAI.GetNextMove(this._target, false, this._enemyPatrolling.GetWalkable));
            Assert.True(this._enemyPatrolling.GetPosition.Equals(new Point2D(1, 1)));

            // moves clockwise
            this._enemyPatrolling.ExecuteMovement(this._enemyPatrolling.GetAI.GetNextMove(this._target, false, this._enemyPatrolling.GetWalkable));
            Assert.True(this._enemyPatrolling.GetPosition.Equals(new Point2D(0, 1)));

            // moves clockwise
            this._enemyPatrolling.ExecuteMovement(this._enemyPatrolling.GetAI.GetNextMove(this._target, false, this._enemyPatrolling.GetWalkable));
            Assert.True(this._enemyPatrolling.GetPosition.Equals(new Point2D(0, 0)));
        }
    }
}
