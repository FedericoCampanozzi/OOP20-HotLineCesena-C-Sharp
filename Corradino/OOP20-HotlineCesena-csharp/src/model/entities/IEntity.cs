using OOP20_HotlineCesena_csharp.commons;

namespace OOP20_HotlineCesena_csharp.model.entities
{
    public interface IEntity
    {
        /// <summary>
        ///     Gets this entity's current coordinates on the game map.
        /// </summary>
        /// <returns> this entity's position.</returns>
        IPoint2D Position { get; }

        /// <summary>
        ///     Gets this entity's width.
        /// </summary>
        /// <returns> this entity's width.</returns>
        double Width { get; }

        /// <summary>
        ///     Gets this entity's height.
        /// </summary>
        /// <returns> this entity's height.</returns>
        double Height { get; }
    }
}