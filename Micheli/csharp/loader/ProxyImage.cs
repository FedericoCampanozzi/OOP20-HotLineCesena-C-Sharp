using System.Collections.Generic;
using Micheli.utils;

namespace Micheli.loader
{
    /// <summary>
    /// Class that implements a Proxy pattern for an Image file.
    /// </summary>
    public class ProxyImage : IImageLoader
    {
        private Dictionary<string, Image> _loadedImage;
        private IImageLoader _loader;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyImage"/> class.
        /// </summary>
        public ProxyImage()
        {
            this._loadedImage = new Dictionary<string, Image>();
            this._loader = new ProxyImageLoader();
        }

        public Image GetImage(FileType image)
        {
            if (this._loadedImage.ContainsKey(image.ToString()))
            {
                return this._loader.GetImage(FileType.InMap);
            }
            else
            {
                this._loadedImage.Add(image.ToString(), this._loader.GetImage(image));
                return this._loadedImage.GetValueOrDefault(image.ToString());
            }
        }

        /// <summary>
        /// Inner class that loads the Image from the file system.
        /// </summary>
        private class ProxyImageLoader : IImageLoader
        {
            public Image GetImage(FileType image)
            {
                return new Image(image);
            }
        }
    }
}
