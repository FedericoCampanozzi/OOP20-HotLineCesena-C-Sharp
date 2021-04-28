using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Micheli.utils;

namespace Micheli.loader
{
    /// <summary>
    /// Models a loader of images.
    /// </summary>
    public interface IImageLoader
    {
        /// <summary>
        /// Returns the image based on the image type.
        /// </summary>
        /// <param name="image">the image type</param>
        /// <returns>a new Image</returns>
        Image GetImage(ImageType image);
    }
}
