using System.Collections.Generic;
using OOP20_HotlineCesena_csharp.commons;

namespace OOP20_HotlineCesena_csharp.model.entities.actors.player
{
    /// <summary>
    ///     Only partially implemented.
    /// </summary>
    public sealed class Player : AbstractActor, IPlayer
    {
        const double DefaultNoiseLevel = 0.0;
        readonly IDictionary<ActorStatus, double> _noiseMap;

        public Player(IPoint2D position, double width, double height, double angle, double speed,
            double maxHealth, IDictionary<ActorStatus, double> noiseMap)
            : base(position, width, height, angle, speed, maxHealth)
        {
            _noiseMap = Objects.RequireNonNull(noiseMap);
        }

        public double NoiseRadius
        {
            get
            {
                if (_noiseMap.ContainsKey(Status))
                {
                    return _noiseMap[Status];
                }

                return DefaultNoiseLevel;
            }
        }

        public void Use()
        {
            // Not implemented.
        }

        /// <remark>
        ///     Only partially implemented. Collision detection is not needed.
        /// </remark>
        protected override void ExecuteMovement(IPoint2D direction)
        {
            if (IsAlive())
            {
                Position = Position.Add(direction.Multiply(Speed));
                Status = ActorStatus.Moving;
            }
        }
    }
}