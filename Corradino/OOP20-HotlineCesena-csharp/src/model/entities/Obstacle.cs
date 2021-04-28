using OOP20_HotlineCesena_csharp.commons;

namespace OOP20_HotlineCesena_csharp.model.entities
{
    /// <summary>
    ///     Map obstacle. Used for collision tests.
    /// </summary>
    public class Obstacle : AbstractEntity
    {
        public Obstacle(IPoint2D position, double width, double height) : base(position, width, height)
        {
        }
    }
}
