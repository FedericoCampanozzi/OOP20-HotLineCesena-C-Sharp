using Micheli.loader;

namespace Micheli.utils
{
    /// <summary>
    /// Partial implementation used for recreating an Audio file.
    /// </summary>
    public class Audio
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Audio"/> class.
        /// </summary>
        /// <param name="audioType">the type of audio</param>
        public Audio(FileType audioType)
        {
            this.GetAudioType = audioType;
        }

        /// <summary>
        /// Gets the AudioType of the current Audio.
        /// </summary>
        public FileType GetAudioType { get; }
    }
}
