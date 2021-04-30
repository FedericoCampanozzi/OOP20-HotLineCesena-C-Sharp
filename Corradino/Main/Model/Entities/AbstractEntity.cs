using Main.Commons;

namespace Main.Model.Entities
{
    public abstract class AbstractEntity : IEntity
    {
        protected AbstractEntity(IPoint2D position, double width, double height)
        {
            (Position, Width, Height) = (Objects.RequireNonNull(position), width, height);
        }

        public IPoint2D Position { get; protected set; }
        
        public double Width { get; }
        
        public double Height { get; }
    }
}
