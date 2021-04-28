using System;
using System.Collections.Generic;
using NUnit.Framework;
using Micheli.enemy;
using Micheli.utils;

namespace Micheli.test.enemyTest
{
    /// <summary>
    /// Models a test class for EnemyFactory.
    /// </summary>
    public class EnemyFactoryTest
    {
        private HashSet<Point2D> _walkable = new HashSet<Point2D>();
        private HashSet<Point2D> _walls = new HashSet<Point2D>();
        private IEnemy _enemyIdle;
        private IEnemy _enemyRandomMovement;
        private IEnemy _enemyPatrolling;
        private IEnemy _enemyBoss;

        [SetUp]
        public void SetUp()
        {
            this._enemyIdle = new EnemyFactory().GetEnemy(new Point2D(0, 0), EnemyType.IDLE, this._walkable, this._walls);
            this._enemyRandomMovement = new EnemyFactory().GetEnemy(new Point2D(0, 0), EnemyType.RANDOM_MOVEMENT, this._walkable, this._walls);
            this._enemyPatrolling = new EnemyFactory().GetEnemy(new Point2D(0, 0), EnemyType.PATROLLING, this._walkable, this._walls);
            this._enemyBoss = new EnemyFactory().GetEnemy(new Point2D(0, 0), EnemyType.BOSS, this._walkable, this._walls);
        }

        [Test]
        public void EnemyCreationTest()
        {
            // Checks if the Enemy Idle has been correctly instantiated
            Assert.IsNotNull(this._enemyIdle);
            Assert.True(this._enemyIdle.GetPosition.Equals(new Point2D(0, 0)));
            Assert.AreEqual(EnemyType.IDLE, this._enemyIdle.GetEnemyType);

            // Checks if the Enemy Random_Movement has been correctly instantiated
            Assert.IsNotNull(this._enemyRandomMovement);
            Assert.True(this._enemyRandomMovement.GetPosition.Equals(new Point2D(0, 0)));
            Assert.AreEqual(EnemyType.RANDOM_MOVEMENT, this._enemyRandomMovement.GetEnemyType);

            // Checks if the Enemy Patrolling has been correctly instantiated
            Assert.IsNotNull(this._enemyPatrolling);
            Assert.True(this._enemyPatrolling.GetPosition.Equals(new Point2D(0, 0)));
            Assert.AreEqual(EnemyType.PATROLLING, this._enemyPatrolling.GetEnemyType);

            // Checks if the Enemy Boss has been correctly instantiated
            Assert.IsNotNull(this._enemyBoss);
            Assert.True(this._enemyBoss.GetPosition.Equals(new Point2D(0, 0)));
            Assert.AreEqual(EnemyType.PATROLLING, this._enemyBoss.GetEnemyType);
        }
    }
}
