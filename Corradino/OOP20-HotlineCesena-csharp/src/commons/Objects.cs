using System;

namespace OOP20_HotlineCesena_csharp.commons
{
    /// <summary>
    ///     Collection of Java-like utility methods.
    /// </summary>
    public static class Objects
    {
        /// <summary>
        ///     Tests whether the given object is null. If it is null, throws
        ///     a NullReferenceException.
        /// </summary>
        /// <param name="o">the object to test</param>
        /// <typeparam name="T">any type of object</typeparam>
        /// <returns>the given object if it is not null</returns>
        /// <exception cref="NullReferenceException">if the given object is null</exception>
        public static T RequireNonNull<T>(T o)
        {
            if (o == null)
            {
                throw new NullReferenceException();
            }

            return o;
        }
    }
}
