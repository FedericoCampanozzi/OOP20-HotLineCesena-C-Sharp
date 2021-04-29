namespace Micheli.utils
{
    /// <summary>
    /// Utility class used for math methods
    /// </summary>
    public class MathUtility
    {
        /// <summary>
        /// Calculates a new rounded sum between two points
        /// </summary>
        /// <param name="arg1">the first point</param>
        /// <param name="arg2">the second point</param>
        /// <returns>a new point</returns>
        public static Point2D RoundedSumPoint2D(Point2D arg1,  Point2D arg2)
        {
            return new Point2D((int)arg1.X + (int)arg2.X, (int)arg1.Y + (int)arg2.Y);
        }
    }
}
