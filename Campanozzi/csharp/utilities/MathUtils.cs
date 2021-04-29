using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campanozzi.Utilities
{
    /// <summary>
    /// Collection of static methods describing algorithms or mathematical functions.
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Computes the distance between two pairs of integers.
        /// </summary>
        /// <param name="p1">the first pair</param>
        /// <param name="p2">the second pair</param>
        /// <returns>the distance between the given pairs.</returns>
        public static double Distance(KeyValuePair<int, int> p1, KeyValuePair<int, int> p2)
        {
            return Math.Sqrt((p2.Key - p1.Key) * (p2.Key - p1.Key) + (p2.Value - p1.Value) * (p2.Value - p1.Value));
        }

        /// <summary>
        /// Sums a variable number of pairs of integers.
        /// </summary>
        /// <param name="points">the series of pairs to be summed together.</param>
        /// <returns>the sum of all given pairs.</returns>
        public static KeyValuePair<int, int> Sum(params KeyValuePair<int, int>[] points)
        {
            int k = 0;
            int v = 0;
            foreach (KeyValuePair<int, int> point in points)
            {
                k += point.Key;
                v += point.Value;
            }
            return new KeyValuePair<int, int>(k, v);
        }

        /// <summary>
        /// Subtracts a variable number of pairs of integers from p.
        /// </summary>
        /// <param name="p">the subtrahend.</param>
        /// <param name="points">points the series of pairs that will be subtracted from p.</param>
        /// <returns>the result of the subtraction.</returns>
        public static KeyValuePair<int, int> Subtract(KeyValuePair<int, int> p, params KeyValuePair<int, int>[] points)
        {
            int k = p.Key;
            int v = p.Value;
            foreach (KeyValuePair<int, int> point in points)
            {
                k -= point.Key;
                v -= point.Value;
            }
            return new KeyValuePair<int, int>(k, v);
        }
    }
}
