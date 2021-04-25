using System;

namespace OOP20_HotlineCesena_csharp.commons
{
    public class Point2D : IPoint2D, IEquatable<Point2D>
    {
        public static readonly IPoint2D Zero = new Point2D(0.0, 0.0);
        const double Epsilon = 0.000001;

        public Point2D(double x, double y)
        {
            (X, Y) = (x, y);
        }

        public double X { get; }

        public double Y { get; }

        public IPoint2D Normalize()
        {
            double magnitude = Math.Sqrt(X * X + Y * Y);
            return magnitude == 0.0 ? Zero : new Point2D(X / magnitude, Y / magnitude);
        }

        public IPoint2D Add(IPoint2D p)
        {
            return new Point2D(X + p.X, Y + p.Y);
        }

        public IPoint2D Subtract(IPoint2D p)
        {
            return new Point2D(X - p.X, Y - p.Y);
        }

        public IPoint2D Multiply(double scalar)
        {
            return new Point2D(X * scalar, Y * scalar);
        }

        public double Distance(IPoint2D p)
        {
            double a = X - p.X;
            double b = Y - p.Y;
            return Math.Sqrt(a * a + b * b);
        }

        public bool Equals(Point2D other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Math.Abs(X - other.X) < Epsilon && Math.Abs(Y - other.Y) < Epsilon;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && Equals((Point2D) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public static bool operator ==(Point2D left, Point2D right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Point2D left, Point2D right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return "[" + X + ", " + Y + "]";
        }
    }
}
