using OOP20_HotlineCesena_csharp.commons;
using OOP20_HotlineCesena_csharp.utils;

namespace OOP20_HotlineCesena_csharp.model.entities
{
    public abstract class AbstractMovableEntity : AbstractEntity, IMovableEntity
    {
        double _angle;

        protected AbstractMovableEntity(IPoint2D position, double width, double height, double angle, double speed)
            : base(position, width, height)
        {
            (Angle, Speed) = (angle, speed);
        }

        public double Angle
        {
            get => _angle;
            set
            {
                if (CanInitiateRotation())
                {
                    _angle = value;
                }
            }
        }

        public double Speed { get; set; }

        public bool IsCollidingWith(IPoint2D newPosition, IEntity other)
        {
            return MathUtils.IsCollision(
                Objects.RequireNonNull(newPosition),
                Width,
                Height,
                Objects.RequireNonNull(other).Position,
                other.Width,
                other.Height
                );
        }

        /// <inheritdoc />
        /// <remarks>
        ///     Template method based on executeMovement.
        ///     No default implementation is supplied to account for the
        ///     need of different movement logics by different subclasses.
        /// </remarks>
        public void Move(IPoint2D direction)
        {
            if (!Objects.RequireNonNull(direction).Equals(Point2D.Zero))
            {
                ExecuteMovement(direction);
            }
        }

        /// <summary>
        ///     Defines the movement logics for a subclass.
        /// </summary>
        /// <param name="direction">the direction in which this entity will move.</param>
        protected abstract void ExecuteMovement(IPoint2D direction);

        /// <summary>
        ///     Other conditions that need to be satisfied in order to begin
        ///     rotation.
        /// </summary>
        /// <returns> true if this entity can rotate, false otherwise.</returns>
        protected abstract bool CanInitiateRotation();
    }
}
