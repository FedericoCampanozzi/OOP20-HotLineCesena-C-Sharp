using System;
using OOP20_HotlineCesena_csharp.commons;

namespace OOP20_HotlineCesena_csharp.utils
{
    public static class MathUtils
    {
        public static double MouseToDegrees(IPoint2D coords)
        {
            return 180 / Math.PI * Math.Atan2(coords.Y, coords.X);
        }

        public static bool IsCollision(IPoint2D p1, double w1, double h1, IPoint2D p2, double w2, double h2)
        {
            return p2.X + w2 >= p1.X
                   && p2.Y + h2 >= p1.Y
                   && p2.X <= p1.X + w1
                   && p2.Y <= p1.Y + h1;
        }
    }
}
