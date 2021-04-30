using System.Collections.Generic;
using System.Linq;
using Main.Commons;

namespace Main.Model.Entities.Actors.player
{
    /// <summary>
    ///     Only partially implemented.
    /// </summary>
    public sealed class Player : AbstractActor, IPlayer
    {
        const double DefaultNoiseLevel = 0.0;
        readonly IDictionary<ActorStatus, double> _noiseMap;
        readonly IEnumerable<IEntity> _obstaclesOnMap;

        public Player(IPoint2D position, double width, double height, double angle, double speed,
            double maxHealth, IDictionary<ActorStatus, double> noiseMap, IEnumerable<IEntity> obstacles)
            : base(position, width, height, angle, speed, maxHealth)
        {
            (_noiseMap, _obstaclesOnMap) = (Objects.RequireNonNull(noiseMap), Objects.RequireNonNull(obstacles));
        }

        public double NoiseRadius => _noiseMap.ContainsKey(Status) ? _noiseMap[Status] : DefaultNoiseLevel;

        public void Use()
        {
            // Not implemented.
        }

        /// <remark>
        ///     Partial collision detection.
        /// </remark>
        protected override void ExecuteMovement(IPoint2D direction)
        {
            if (IsAlive())
            {
                IPoint2D newPosition = Position.Add(direction.Multiply(Speed));
                if (!HasCollided(newPosition, _obstaclesOnMap))
                {
                    Position = newPosition;
                    Status = ActorStatus.Moving;
                }
            }
        }

        bool HasCollided(IPoint2D newPos, IEnumerable<IEntity> entities)
        {
            return entities.Any(e => IsCollidingWith(newPos, e));
        }
    }
}
