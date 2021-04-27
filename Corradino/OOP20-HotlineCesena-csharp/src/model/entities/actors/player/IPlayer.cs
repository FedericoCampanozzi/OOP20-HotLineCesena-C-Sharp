﻿namespace OOP20_HotlineCesena_csharp.model.entities.actors.player
{
    /// <summary>
    /// Models the player character and their unique actions.
    /// </summary>
    public interface IPlayer : IActor
    {   
        /// <summary>
        /// Radius of the noise currently emitted by the player based on their state.
        /// </summary>
        double NoiseRadius { get; }

        /// <summary>
        /// Uses or picks up items found on ground.
        /// </summary>
        void Use();
    }
}
