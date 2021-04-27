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
    }
}