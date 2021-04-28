using System.Collections.Generic;
using Micheli.utils;

namespace Micheli.loader
{
    /// <summary>
    /// Class that implements a Proxy pattern for an Audio file.
    /// </summary>
    public class ProxyAudio : IAudioLoader
    {
        private Dictionary<string, Audio> _loadedAudio;
        private IAudioLoader _loader;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyAudio"/> class.
        /// </summary>
        public ProxyAudio()
        {
            this._loadedAudio = new Dictionary<string, Audio>();
            this._loader = new ProxyAudioLoader();
        }

        public Audio GetAudio(FileType audio)
        {
            if (this._loadedAudio.ContainsKey(audio.ToString()))
            {
                return this._loader.GetAudio(FileType.InMap);
            }
            else
            {
                this._loadedAudio.Add(audio.ToString(), this._loader.GetAudio(audio));
                return this._loadedAudio.GetValueOrDefault(audio.ToString());
            }
        }

        /// <summary>
        /// Inner class that loads the Audio from the file system.
        /// </summary>
        private class ProxyAudioLoader : IAudioLoader
        {
            public Audio GetAudio(FileType audio)
            {
                return new Audio(audio);
            }
        }
    }
}
