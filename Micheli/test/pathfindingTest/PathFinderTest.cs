using System.Collections.Generic;
using Micheli.enemy.ai.strategy;
using Micheli.utils;
using NUnit.Framework;

namespace Micheli.test.pathfindingTest
{
    /// <summary>
    /// Models a test class for Pathfinder.
    /// </summary>
    public class PathFinderTest
    {
        private const int Dimensions = 5;
        private HashSet<Point2D> _walkable = new HashSet<Point2D>();
        private List<Point2D> _path;
        private Point2D _startingPos;
        private Point2D _endPos;

        [SetUp]
        public void SetUp()
        {
            this._startingPos = new Point2D(0, 0);
            this._endPos = new Point2D(Dimensions - 1, Dimensions - 1);

            for (int y = 0; y < Dimensions; y++)
            {
                for (int x = 0; x < Dimensions; x++)
                {
                    this._walkable.Add(new Point2D(x, y));
                }
            }
        }

        [Test]
        public void FindPathTest()
        {
            this._path = Pathfinder.FindPath(this._startingPos, this._endPos, Dimensions, Dimensions, this._walkable);

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
