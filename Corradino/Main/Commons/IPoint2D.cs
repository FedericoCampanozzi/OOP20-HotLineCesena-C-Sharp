namespace Main.Commons
{
    /// <summary>
    /// Models a two-dimensional point with a basic
    /// set of methods.
    /// </summary>
    public interface IPoint2D
    {
        /// <summary>
        /// This point's x coordinate.
        /// </summary>
        double X { get; }

        /// <summary>
        /// This point's y coordinate.
        /// </summary>
        double Y { get; }

        /// <summary>
        /// Returns the normalized version of this point.
        /// </summary>
        /// <returns>the normalized version of this point</returns>
        IPoint2D Normalize();

        /// <summary>
        /// Returns the sum between this point and p.
        /// </summary>
        /// <param name="p">the point to be summed</param>
        /// <returns>the sum between this point and p</returns>
        IPoint2D Add(IPoint2D p);

        /// <summary>
        /// Returns the difference between this point and p.
        /// </summary>
        /// <param name="p">the point to be subtracted</param>
        /// <returns>the difference between this point and p</returns>
        IPoint2D Subtract(IPoint2D p);

        /// <summary>
        /// Returns the product between this point and a scalar value.
        /// </summary>
        /// <param name="scalar">the value by which this point will
        /// be multiplied</param>
        /// <returns>the product between this point and a scalar value</returns>
        IPoint2D Multiply(double scalar);

        /// <summary>
        /// Computes the distance between this point and p.
        /// </summary>
        /// <param name="p">the other point</param>
        /// <returns>the distance between this point and p</returns>
        double Distance(IPoint2D p);
    }
}
