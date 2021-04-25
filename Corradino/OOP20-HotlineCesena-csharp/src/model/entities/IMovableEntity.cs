using OOP20_HotlineCesena_csharp.commons;

namespace OOP20_HotlineCesena_csharp.model.entities
{
    public interface IMovableEntity : IEntity
    {
        double Angle { get; set; }

        double Speed { get; set; }
        void Move(IPoint2D direction);

        bool IsCollidingWith(IPoint2D newPosition, IEntity other);
    }
}