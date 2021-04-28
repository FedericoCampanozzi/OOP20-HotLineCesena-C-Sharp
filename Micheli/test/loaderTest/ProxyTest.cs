using NUnit.Framework;
using Micheli.loader;
using Micheli.utils;

namespace Micheli.test.loaderTest
{
    /// <summary>
    /// Models a test class for ProxyLoader and ProxyAudio.
    /// </summary>
    class ProxyTest
    {
        [Test]
        public void ImageTest()
        {
            IImageLoader loader = new ProxyImage();

            //Loads the image from the file system
            Assert.AreEqual(ImageType.TEST, loader.GetImage(ImageType.TEST).GetImageType);

            //Loads the same image but from the dictionary
            Assert.AreEqual(ImageType.IN_MAP, loader.GetImage(ImageType.TEST).GetImageType);

            //Loads the image from the file system
            Assert.AreEqual(ImageType.NOT_IN_MAP, loader.GetImage(ImageType.NOT_IN_MAP).GetImageType);
        }

        [Test]
        public void AudioTest()
        {
            IAudioLoader loader = new ProxyAudio();

            //Loads the audio from the file system
            Assert.AreEqual(AudioType.TEST, loader.GetAudio(AudioType.TEST).GetAudioType);

            //Loads the same audio but from the dictionary
            Assert.AreEqual(AudioType.IN_MAP, loader.GetAudio(AudioType.TEST).GetAudioType);

            //Loads the audio from the file system
            Assert.AreEqual(AudioType.NOT_IN_MAP, loader.GetAudio(AudioType.NOT_IN_MAP).GetAudioType);
        }
    }
}
