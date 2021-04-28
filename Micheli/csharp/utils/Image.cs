using Micheli.loader;

namespace Micheli.utils
{
    /// <summary>
    /// Partial implementation used for recreating an Image file.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets the ImageType of the current Image.
        /// </summary>
        public ImageType GetImageType { get; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="imageType">the type of image</param>
        public Image(ImageType imageType)
        {
            this.GetImageType = imageType;
        }
    }
}
