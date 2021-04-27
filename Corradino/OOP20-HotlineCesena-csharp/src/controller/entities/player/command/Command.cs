using System;
using OOP20_HotlineCesena_csharp.commons;
using OOP20_HotlineCesena_csharp.model.entities.actors.player;

namespace OOP20_HotlineCesena_csharp.controller.entities.player.command
{
    /// <summary>
    /// Static class containing commands for <see cref="IPlayer"/>
    /// to be used with the <see cref="IInputInterpreter"/>.
    /// </summary>
    public static class Command
    {
        /// <summary>
        /// Encapsulates <see cref="IPlayer.Move"/>.
        /// </summary>
        /// <param name="direction">the direciton the player instance
        /// will move in</param>
        /// <returns>a lambda encapsulating <see cref="IPlayer.Move"/></returns>
        public static Action<IPlayer> MoveCommand(IPoint2D direction)
        {
            return player => player.Move(direction);
        }

        /// <summary>
        /// Encapsulates player.Angle = angle.
        /// </summary>
        /// <param name="angle">the angle the player instance will face</param>
        /// <returns>a lambda encapsulating player.Angle = angle</returns>
        public static Action<IPlayer> RotateCommand(double angle)
        {
            return player => player.Angle = angle;
        }
    }
}
