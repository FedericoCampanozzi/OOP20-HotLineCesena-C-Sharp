using Main.Model.Entities.Actors.player;

namespace Main.Controller.Entities.Player.Command
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
