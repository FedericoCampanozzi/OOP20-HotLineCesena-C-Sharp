using Main.Commons;

namespace Main.Model.Entities
{
    /// <summary>
    ///     Represents a basic game entity characterized by a
    ///     position, a width and a height.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        ///     This entity's current coordinates on the game map.
        /// </summary>
        /// <returns> this entity's position.</returns>
        IPoint2D Position { get; }

        /// <summary>
        ///     This entity's width.
        /// </summary>
        /// <returns> this entity's width.</returns>
        double Width { get; }

        /// <summary>
        ///     This entity's height.
        /// </summary>
        /// <returns> this entity's height.</returns>
        double Height { get; }
    }
}
