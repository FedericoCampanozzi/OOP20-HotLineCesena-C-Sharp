using Main.Model.Entities.Actors.player;

namespace Main.Controller.Entities.Player.Command
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
