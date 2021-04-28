using OOP20_HotlineCesena_csharp.commons;
using OOP20_HotlineCesena_csharp.model.entities.actors.player;

namespace OOP20_HotlineCesena_csharp.controller.entities.player.command
{
    /// <summary>
    ///     Encapsulates IPlayer.Move
    /// </summary>
    public class MoveCommand : ICommand
    {
        readonly IPoint2D _dir;

        public MoveCommand(IPoint2D dir)
        {
            _dir = dir;
        }
        
        public void Execute(IPlayer player)
        {
            player.Move(_dir);
        }
    }
}

