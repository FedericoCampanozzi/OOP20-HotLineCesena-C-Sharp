using OOP20_HotlineCesena_csharp.commons;

namespace OOP20_HotlineCesena_csharp.model.entities
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
