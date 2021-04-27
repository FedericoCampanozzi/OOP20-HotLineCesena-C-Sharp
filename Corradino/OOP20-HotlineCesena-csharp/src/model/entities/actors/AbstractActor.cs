using System;
using OOP20_HotlineCesena_csharp.commons;

namespace OOP20_HotlineCesena_csharp.model.entities.actors
{
    public abstract class AbstractActor : AbstractMovableEntity, IActor
    {
        protected AbstractActor(IPoint2D position, double width, double height, double angle, double speed,
            double maxHealth)
            : base(position, width, height, angle, speed)
        {
            (MaxHealth, CurrentHealth) = (maxHealth, maxHealth);
        }

        public double MaxHealth { get; }
        public double CurrentHealth { get; private set; }
        public ActorStatus Status { get; protected set; }

        public void Attack()
        {
            // Not implemented.
        }

        public void Heal(double hp)
        {
            if (hp < 0)
            {
                throw new ArgumentException("Negative hp: " + hp);
            }

            if (IsAlive())
            {
                CurrentHealth = CurrentHealth + hp < MaxHealth ? CurrentHealth + hp : MaxHealth;
            }
        }

        public void Reload()
        {
            // Not implemented
        }

        public void TakeDamage(double damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Negative damage: " + damage);
            }

            if (IsAlive())
            {
                CurrentHealth = CurrentHealth > damage ? CurrentHealth - damage : 0;
            }

            if (CurrentHealth == 0)
            {
                Status = ActorStatus.Dead;
            }
        }

        public void Update(double timeElapsed)
        {
            // Not implemented
        }

        /// <summary>
        ///     Convenience method to be used internally.
        /// </summary>
        /// <returns>true if the actor is alive, false otherwise.</returns>
        protected bool IsAlive()
        {
            return CurrentHealth > 0;
        }

        /// <summary>
        ///     Prohibits rotations when this actor is dead.
        /// </summary>
        /// <returns>true if the actor can rotate, false otherwise.</returns>
        protected override bool CanInitiateRotation()
        {
            return IsAlive();
        }
    }
}