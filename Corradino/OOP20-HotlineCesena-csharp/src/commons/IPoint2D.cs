namespace OOP20_HotlineCesena_csharp.commons
{
    public interface IPoint2D
    {
        double X { get; }

        double Y { get; }

        IPoint2D Normalize();

        IPoint2D Add(IPoint2D p);

        IPoint2D Subtract(IPoint2D p);

        IPoint2D Multiply(double scalar);

        double Distance(IPoint2D p);
    }
}
