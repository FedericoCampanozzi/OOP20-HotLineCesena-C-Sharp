namespace Micheli.utils
{
    /// <summary>
    /// Models a point representing a location in (x,y) coordinate space.
    /// </summary>
    public class Point2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D"/> class.
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        public Point2D(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        public double _x { get; }

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        public double _y { get; }

        /// <summary>
        /// Adds two points together.
        /// </summary>
        /// <param name="arg1">the point that wants to be added to the current</param>
        /// <returns>a new point</returns>
        public Point2D Add(Point2D arg1)
        {
            return new Point2D(this._x + arg1._x, this._y + arg1._y);
        }

        /// <summary>
        /// Multiply the current point by a value.
        /// </summary>
        /// <param name="val">the magnitude of the multiplication</param>
        /// <returns>a new point</returns>
        public Point2D Multiply(double val)
        {
            return new Point2D(this._x * val, this._y * val);
        }

        /// <summary>
        /// Checks if two points are equal, by comparing
        /// x and y coordinates.
        /// </summary>
        /// <param name="arg1">the other point</param>
        /// <returns>a new point</returns>
        public bool Equals(Point2D arg1)
        {
            return this._x == arg1._x && this._y == arg1._y;
        }
    }
}
