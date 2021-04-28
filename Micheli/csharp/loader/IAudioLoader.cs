using Micheli.utils;

namespace Micheli.loader
{
    /// <summary>
    /// Models a loader of audios
    /// </summary>
    public interface IAudioLoader
    {
        /// <summary>
        /// Returns the audio based on the audio type.
        /// </summary>
        /// <param name="audio">the type of audio</param>
        /// <returns>a new Audio</returns>
        Audio GetAudio(FileType audio);
    }
}
