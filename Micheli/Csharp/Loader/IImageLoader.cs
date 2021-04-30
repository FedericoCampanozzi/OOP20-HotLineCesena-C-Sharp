using Micheli.Utils;

namespace Micheli.Loader
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
        Image GetImage(FileType image);
    }
}
