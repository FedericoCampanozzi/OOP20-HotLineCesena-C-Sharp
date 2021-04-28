namespace Micheli.utils
{
    /// <summary>
    /// Util class used for math methods
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Calculates a new rounded sum between two points
        /// </summary>
        /// <param name="arg1">the first point</param>
        /// <param name="arg2">the second point</param>
        /// <returns>a new point</returns>
        public static Point2D roundedSumPoint2D(Point2D arg1,  Point2D arg2)
        {
            return new Point2D((int)arg1._x + (int)arg2._x,
                    (int)arg1._y + (int)arg2._y);
        }
    }
}
