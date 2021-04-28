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
        /// Class constructor.
        /// </summary>
        public ProxyImage()
        {
            this._loadedImage = new Dictionary<string, Image>();
            this._loader = new ProxyImageLoader();

        }

        public Image GetImage(ImageType image)
        {
            if (this._loadedImage.ContainsKey(image.ToString()))
            {
                return this._loader.GetImage(ImageType.IN_MAP);
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
            public Image GetImage(ImageType image)
            {
                return new Image(image);
            }
        }
    }
}
