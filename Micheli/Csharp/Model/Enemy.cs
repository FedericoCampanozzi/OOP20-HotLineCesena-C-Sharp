using System;
using System.Collections.Generic;
using Micheli.Model.Ai;
using Micheli.Utils;

namespace Micheli.Model
{
    /// <summary>
    /// Class that represent the generic enemy implementation.
    /// Partial implementation
    /// </summary>
    public class Enemy : IEnemy
    {
        private const double EnemyNormalSpeed = 1;

        private Point2D _position;
        private IInvetory _inventory;
        private double _rotation;
        private HashSet<Point2D> _wallSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class.
        /// </summary>
        /// <param name="pos">the starting pos</param>
        /// <param name="inv">the enemy's inventory</param>
        /// <param name="rotation">the starting rotation</param>
        /// <param name="type">the type of enemy</param>
        /// <param name="walkable">the collections of points that are walkable by the enemy</param>
        /// <param name="walls">the collections of points that impair the enemy's sight</param>
        public Enemy(Point2D pos, IInvetory inv, double rotation, EnemyType type, HashSet<Point2D> walkable, HashSet<Point2D> walls)
        {
            if (walkable == null)
            {
                throw new NullReferenceException();
            }

            this._position = pos;
            this._inventory = inv;
            this._rotation = rotation;
            this.GetEnemyType = type;
            this.GetWalkable = walkable;
            this._wallSet = walls;
            this.GetAI = new AI(this._position, this.GetEnemyType, this._rotation, this._wallSet);
        }

        public EnemyType GetEnemyType { get; }

        public IAI GetAI { get; }

        public bool Pursuit { get; set; }

        public HashSet<Point2D> GetWalkable { get; }

        public Point2D GetPosition
        {
            get => this._position;
        }

        public double GetRotation
        {
            get => this._rotation;

            set => this._rotation = value;
        }

        public void ExecuteMovement(Point2D direction)
        {
            var current = this._position;
            this._position = current.Add(direction.Multiply(EnemyNormalSpeed));
            this.GetAI.SetEnemyPos = this._position;
        }
    }
}
