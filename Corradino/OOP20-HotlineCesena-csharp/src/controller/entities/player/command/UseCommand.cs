﻿using OOP20_HotlineCesena_csharp.model.entities.actors.player;

namespace OOP20_HotlineCesena_csharp.controller.entities.player.command
{
    /// <summary>
    ///     Encapsulates IPlayer.Use
    /// </summary>
    public class UseCommand : ICommand
    {
        public void Execute(IPlayer player)
        {
            player.Use();
        }
    }
}