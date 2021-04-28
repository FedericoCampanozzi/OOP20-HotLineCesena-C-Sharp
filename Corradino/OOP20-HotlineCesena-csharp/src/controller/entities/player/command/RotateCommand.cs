using OOP20_HotlineCesena_csharp.model.entities.actors.player;

namespace OOP20_HotlineCesena_csharp.controller.entities.player.command
{
    /// <summary>
    ///     Encapsulates IPlayer.Angle = value
    /// </summary>
    public class RotateCommand : ICommand
    {
        readonly double _angle;

        public RotateCommand(double angle)
        {
            _angle = angle;
        }
        
        public void Execute(IPlayer player)
        {
            player.Angle = _angle;
        }
    }
}
