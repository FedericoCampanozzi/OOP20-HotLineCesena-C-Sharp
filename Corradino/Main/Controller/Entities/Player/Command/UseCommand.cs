using Main.Model.Entities.Actors.Player;

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
