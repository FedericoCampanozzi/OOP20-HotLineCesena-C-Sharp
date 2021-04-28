using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using Micheli.enemy;
using Micheli.enemy.ai.strategy;
using Micheli.utils;

namespace Micheli.test.pathfindingTest
{
    /// <summary>
    /// Models a test class for Pathfinder.
    /// </summary>
    public class PathFinderTest
    {
        private const int dimensions = 5;
        private HashSet<Point2D> _walkable = new HashSet<Point2D>();
        private List<Point2D> _path;
        private Point2D _startingPos;
        private Point2D _endPos;

        [SetUp]
        public void SetUp()
        {
            this._startingPos = new Point2D(0, 0);
            this._endPos = new Point2D(dimensions - 1, dimensions - 1);

            for (int y = 0; y < dimensions; y++)
            {
                for (int x = 0; x < dimensions; x++)
                {
                    this._walkable.Add(new Point2D(x, y));
                }
            }
        }

        [Test]
        public void FindPathTest()
        {
            this._path = Pathfinder.FindPath(this._startingPos, this._endPos, dimensions, dimensions, this._walkable);

            // path should not be null
            Assert.IsNotNull(this._path);

            // path should have more than one element
            Assert.True(this._path.Count > 1);

            // path should lead in a diagonal line to the target
            Assert.IsTrue(this._path[0].Equals(new Point2D(1, 1)));
            this._path.Remove(this._path[0]);

            // path should lead in a diagonal line to the target
            Assert.IsTrue(this._path[0].Equals(new Point2D(2, 2)));
            this._path.Remove(this._path[0]);
        }
    }
}
