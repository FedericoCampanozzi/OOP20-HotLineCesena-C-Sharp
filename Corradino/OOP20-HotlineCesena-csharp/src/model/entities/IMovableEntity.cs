using OOP20_HotlineCesena_csharp.commons;

namespace OOP20_HotlineCesena_csharp.model.entities
{
    /// <summary>
    ///     Represents a generic entity capable of moving in a specified direction.
    /// </summary>
    public interface IMovableEntity : IEntity
    {
        /// <summary>
        ///     The angle this entity is currently facing.
        /// </summary>
        double Angle { get; set; }

        /// <summary>
        ///     The speed at which this entity moves.
        /// </summary>
        double Speed { get; set; }

        /// <summary>
        ///     Makes this entity move in a certain direction.
        /// </summary>
        /// <param name="direction">the direction this entity will move in</param>
        void Move(IPoint2D direction);

        /// <summary>
        ///     Tests whether this entity will collide with another.
        /// </summary>
        /// <param name="newPosition">
        ///     the new position in which this entity is going
        ///     to move
        /// </param>
        /// <param name="other">the other entity</param>
        /// <returns>
        ///     <code>true</code> if this entity will collide with
        ///     another, <code>false</code> otherwise.
        /// </returns>
        bool IsCollidingWith(IPoint2D newPosition, IEntity other);
    }
}
