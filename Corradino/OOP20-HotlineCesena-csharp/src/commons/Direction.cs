namespace OOP20_HotlineCesena_csharp.commons
{
    public sealed class Direction : IDirection
    {
        public static readonly IDirection North = new Direction(new Point2D(0.0, -1.0));
        public static readonly IDirection South = new Direction(new Point2D(0.0, 1.0));
        public static readonly IDirection East = new Direction(new Point2D(1.0, 0.0));
        public static readonly IDirection West = new Direction(new Point2D(-1.0, 0.0));
        public static readonly IDirection None = new Direction(Point2D.Zero);

        Direction(IPoint2D dir)
        {
            Dir = dir;
        }

        public IPoint2D Dir { get; }
    }
}