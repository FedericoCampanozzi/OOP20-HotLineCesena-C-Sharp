using System;
using System.Collections.Generic;
using NUnit.Framework;
using Micheli.enemy;
using Micheli.utils;

namespace Micheli.test.enemyTest
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
            for (int y = 0; y <= EnemyPhysicsUtils.MAP_DIMENSION; y++)
            {
                for (int x = 0; x <= EnemyPhysicsUtils.MAP_DIMENSION; x++)
                {
                    this._walkable.Add(new Point2D(x, y));
                }
            }

            this._enemyIdle = new EnemyFactory().GetEnemy(new Point2D(0, 0), EnemyType.IDLE, this._walkable, this._walls);
            this._enemyPatrolling = new EnemyFactory().GetEnemy(new Point2D(0, 0), EnemyType.PATROLLING, this._walkable, this._walls);
        }

        [Test]
        public void EnemyIdle()
        {
            this._enemyIdle.executeMovement(_enemyIdle.GetAI.GetNextMove(_target, false, _enemyIdle.GetWalkable));

            // enemy remains stationary
            Assert.True(this._enemyIdle.GetPosition.Equals(new Point2D(0, 0)));
        }

        [Test]
        public void EnemyMoveTest()
        {
            Assert.IsNotNull(this._enemyPatrolling.GetAI);

            // moves clockwise

            this._enemyPatrolling.executeMovement(_enemyPatrolling.GetAI.GetNextMove(_target, false, _enemyPatrolling.GetWalkable));
            Assert.True(this._enemyPatrolling.GetPosition.Equals(new Point2D(1, 0)));

            // moves clockwise

            this._enemyPatrolling.executeMovement(_enemyPatrolling.GetAI.GetNextMove(_target, false, _enemyPatrolling.GetWalkable));
            Assert.True(this._enemyPatrolling.GetPosition.Equals(new Point2D(1, 1)));

            // moves clockwise

            this._enemyPatrolling.executeMovement(_enemyPatrolling.GetAI.GetNextMove(_target, false, _enemyPatrolling.GetWalkable));
            Assert.True(this._enemyPatrolling.GetPosition.Equals(new Point2D(0, 1)));

            // moves clockwise

            this._enemyPatrolling.executeMovement(_enemyPatrolling.GetAI.GetNextMove(_target, false, _enemyPatrolling.GetWalkable));
            Assert.True(this._enemyPatrolling.GetPosition.Equals(new Point2D(0, 0)));
        }
    }
}
