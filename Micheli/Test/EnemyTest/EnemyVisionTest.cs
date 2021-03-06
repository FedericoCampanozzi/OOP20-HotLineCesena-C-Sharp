using System.Collections.Generic;
using Micheli.Model;
using Micheli.Utils;
using NUnit.Framework;

namespace Micheli.Test.EnemyTest
{
    /// <summary>
    /// Models a test class for Enemy vision.
    /// </summary>
    public class EnemyVisionTest
    {
        private HashSet<Point2D> _walkable = new HashSet<Point2D>();
        private HashSet<Point2D> _walls = new HashSet<Point2D>();
        private IEnemy _enemy;
        private Point2D _target;

        [SetUp]
        public void SetUp()
        {
            this._enemy = new Enemy(new Point2D(0, 0), new NaiveInventory(), 0, EnemyType.Idle, this._walkable, this._walls);
        }

        [Test]
        public void VisionTest()
        {
            // clear line of sight and target in range
            this._target = new Point2D(2, 0);
            Assert.True(this._enemy.GetAI.IsShooting(this._target));

            // clear line of sight and target in range
            this._target = new Point2D(2, 2);
            Assert.True(this._enemy.GetAI.IsShooting(this._target));

            // clear line of sight but no target in range
            this._target = new Point2D(-2, -2);
            Assert.False(this._enemy.GetAI.IsShooting(this._target));

            this._walls = new HashSet<Point2D>() { new Point2D(1, 0) };
            this._enemy = new Enemy(new Point2D(0, 0), new NaiveInventory(), 0, EnemyType.Idle, this._walkable, this._walls);
            this._target = new Point2D(2, 0);

            // line of target obscured target not visible
            Assert.False(this._enemy.GetAI.IsShooting(this._target));
        }
    }
}
