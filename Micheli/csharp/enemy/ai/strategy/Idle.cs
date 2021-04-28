﻿using System.Collections.Generic;
using Micheli.utils;

namespace Micheli.enemy.ai.strategy
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
