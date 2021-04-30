using System.Collections.Generic;
using Micheli.Utils;

namespace Micheli.Model.Ai.Strategy
{
    /// <summary>
    /// Class that represent the Idle enemy type MovementStrategy implementation.
    /// </summary>
    public class Idle : IMovementStrategy
    {
        public Point2D Move(Point2D enemy, Point2D player, bool pursuit, HashSet<Point2D> map)
        {
            return new Point2D(0, 0);
        }
    }
}
