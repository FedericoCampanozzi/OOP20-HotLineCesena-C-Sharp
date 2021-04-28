using Micheli.loader;

namespace Micheli.utils
{
    /// <summary>
    /// Partial implementation used for recreating an Image file.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="imageType">the type of image</param>
        public Image(FileType imageType)
        {
            this.GetImageType = imageType;
        }

        /// <summary>
        /// Gets the ImageType of the current Image.
        /// </summary>
        public FileType GetImageType { get; }
    }
}
