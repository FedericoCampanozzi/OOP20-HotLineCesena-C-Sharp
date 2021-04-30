using Main.Commons;

namespace Main.Model.Entities
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
