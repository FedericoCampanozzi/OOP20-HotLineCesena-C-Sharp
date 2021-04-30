using Main.Commons;
using Main.Model.Entities.Actors.Player;

namespace Main.Controller.Entities.Player.Command
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

