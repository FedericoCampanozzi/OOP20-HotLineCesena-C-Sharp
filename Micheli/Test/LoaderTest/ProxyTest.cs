using Micheli.Loader;
using NUnit.Framework;

namespace Micheli.Test.LoaderTest
{
    /// <summary>
    /// Models a test class for ProxyLoader and ProxyAudio.
    /// </summary>
    public class ProxyTest
    {
        [Test]
        public void ImageTest()
        {
            IImageLoader loader = new ProxyImage();

            // Loads the image from the file system
            Assert.AreEqual(FileType.Test, loader.GetImage(FileType.Test).GetImageType);

            // Loads the same image but from the dictionary
            Assert.AreEqual(FileType.InMap, loader.GetImage(FileType.Test).GetImageType);

            // Loads the image from the file system
            Assert.AreEqual(FileType.NotInMap, loader.GetImage(FileType.NotInMap).GetImageType);
        }

        [Test]
        public void AudioTest()
        {
            IAudioLoader loader = new ProxyAudio();

            // Loads the audio from the file system
            Assert.AreEqual(FileType.Test, loader.GetAudio(FileType.Test).GetAudioType);

            // Loads the same audio but from the dictionary
            Assert.AreEqual(FileType.InMap, loader.GetAudio(FileType.Test).GetAudioType);

            // Loads the audio from the file system
            Assert.AreEqual(FileType.NotInMap, loader.GetAudio(FileType.NotInMap).GetAudioType);
        }
    }
}
