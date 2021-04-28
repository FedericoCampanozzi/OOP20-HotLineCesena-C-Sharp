using Micheli.loader;

namespace Micheli.utils
{
    /// <summary>
    /// Partial implementation used for recreating an Audio file.
    /// </summary>
    public class Audio
    {
        /// <summary>
        /// Gets the AudioType of the current Audio.
        /// </summary>
        public AudioType GetAudioType { get; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="audioType">the type of audio</param>
        public Audio(AudioType audioType)
        {
            this.GetAudioType = audioType;
        }
    }
}
