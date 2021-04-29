using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campanozzi.Utilities
{
    public static class MathUtils
    {
        public static double Distance(KeyValuePair<int, int> p1, KeyValuePair<int, int> p2)
        {
            return Math.Sqrt((p2.Key - p1.Key) * (p2.Key - p1.Key) + (p2.Value - p1.Value) * (p2.Value - p1.Value));
        }

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
