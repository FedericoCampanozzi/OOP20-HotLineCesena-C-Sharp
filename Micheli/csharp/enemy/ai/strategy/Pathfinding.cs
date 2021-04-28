using System;
using System.Collections.Generic;
using System.Linq;
using Micheli.utils;

namespace Micheli.enemy.ai.strategy
{
    /// <summary>
    /// Class that implements A* algorithm.
    /// </summary>
    public class Pathfinder
    {
        /// <summary>
        /// Returns an ordered collections of positions, from the starting to the end
        /// position, by implementing a path finding algorithm.
        /// </summary>
        /// <param name="start">the starting position</param>
        /// <param name="end">the position that wants to be reached</param>
        /// <param name="width">the map width</param>
        /// <param name="height">the map height</param>
        /// <param name="map">the collections of points that are walkable by the enemy</param>
        /// <returns>an ordered collections of positions</returns>
        internal static List<Point2D> FindPath(Point2D start, Point2D end, int width, int height, HashSet<Point2D> map)
        {
            List<Node> toVisit = new List<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            Node[,] nodeMap = new Node[width, height];
            Node current;
            Node startNode = null;
            Node endNode = null;

            for (int y = 0; y <= height - 1; y++)
            {
                for(int x = 0; x <= width - 1; x++)
                {
                    int heuristic = Math.Abs(x - (int)end._x) + Math.Abs(y - (int)end._y);
                    Node node = new Node(0, heuristic, x, y);
                    nodeMap[x, y] = node;
                }
            }

            startNode = nodeMap[(int) start._x, (int) start._y];
            endNode = nodeMap[(int) end._x, (int) end._y];

            if(startNode.Equals(endNode))
            {
                return NoPathAviable(startNode);
            }

            toVisit.Add(startNode);

            do
            {
                current = toVisit[0];
                toVisit.Remove(current);
                visited.Add(current);

                if(current.Equals(endNode))
                {
                    return GetPath(current);
                }

                for (int y = (int) current.GetPosition._y; y < (int)current.GetPosition._y + 2; y++)
                {
                    for (int x = (int)current.GetPosition._x; x < (int)current.GetPosition._x + 2; x++)
                    {
                        if(map.ToList().Exists(e => e.Equals(new Point2D(x, y))))
                        {
                            Node neighbor = nodeMap[x, y];

                            if (visited.Contains(neighbor))
                            {
                                continue;
                            }

                            int calculatedCost = neighbor.Heuristic
                                + neighbor.MoveCost
                                + neighbor.TotalCost;

                            if(calculatedCost < neighbor.TotalCost || !toVisit.Contains(neighbor))
                            {
                                neighbor.TotalCost = calculatedCost;
                                neighbor.Parent = current;

                                if(!toVisit.Contains(neighbor))
                                {
                                    toVisit.Add(neighbor);
                                }
                            }
                        }
                    }
                }

            } while (toVisit.Count != 0);


            return NoPathAviable(startNode);
        }

        /// <summary>
        /// Returns a collections of points containing only
        /// the starting position.
        /// </summary>
        /// <param name="start">the starting node</param>
        /// <returns>a collections of points</returns>
        private static List<Point2D> NoPathAviable(Node start)
        {
            List<Point2D> path = new List<Point2D>();
            path.Add(start.GetPosition);

            return path;
        }

        /// <summary>
        /// Returns a collections of ordered points based on
        /// the order of the visited nodes.
        /// </summary>
        /// <param name="last">the last node visited</param>
        /// <returns>a collections of points</returns>
        private static List<Point2D> GetPath(Node last)
        {
            List<Point2D> path = new List<Point2D>();

            while(last.Parent != null)
            {
                path.Add(last.GetPosition);
                last = last.Parent;
            }

            path.Reverse();
            return path;
        }

        /// <summary>
        /// Models a Node.
        /// </summary>
        private class Node : IComparer<Node>
        {
            public readonly int MoveCost;
            public readonly int Heuristic;
            public int TotalCost { get; set; }
            public Node Parent { get; set; }

            private int _x;
            private int _y;

            /// <summary>
            /// Class constructor.
            /// </summary>
            /// <param name="moveCost">the cost to move to this node</param>
            /// <param name="heuristic">the cost based on the distance between
            /// this node and the end node</param>
            /// <param name="x">the x position</param>
            /// <param name="y">the y position</param>
            public Node(int moveCost, int heuristic, int x, int y)
            {
                this.MoveCost = moveCost;
                this.Heuristic = heuristic;
                this._x = x;
                this._y = y;
                Parent = null;
            }

            public int Compare(Node current, Node next)
            {
                return current.TotalCost.CompareTo(next.TotalCost);
            }

            /// <summary>
            /// Gets the Node's position.
            /// </summary>
            public Point2D GetPosition
            {
                get => new Point2D(this._x, this._y);
            }
        }
    }
}
