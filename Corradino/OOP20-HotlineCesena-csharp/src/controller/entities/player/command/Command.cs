using System;
using OOP20_HotlineCesena_csharp.commons;
using OOP20_HotlineCesena_csharp.model.entities.actors.player;

namespace OOP20_HotlineCesena_csharp.controller.entities.player.command
{
    public static class Command
    {
        public static Action<IPlayer> MoveCommand(IPoint2D direction)
        {
            return player => player.Move(direction);
        }
        
        public static Action<IPlayer> RotateCommand(double angle)
        {
            return player => player.Angle = angle;
        }
    }
}