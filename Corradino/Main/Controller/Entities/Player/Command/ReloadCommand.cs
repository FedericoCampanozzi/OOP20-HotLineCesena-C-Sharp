using Main.Model.Entities.Actors.player;

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
