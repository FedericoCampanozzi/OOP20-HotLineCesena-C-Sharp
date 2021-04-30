using Main.Model.Entities.Actors.Player;

namespace Main.Controller.Entities.Player.Command
{
    /// <summary>
    ///     Encapsulates IPlayer.Reload
    /// </summary>
    public class ReloadCommand : ICommand
    {
        public void Execute(IPlayer player)
        {
            player.Reload();
        }
    }
}
