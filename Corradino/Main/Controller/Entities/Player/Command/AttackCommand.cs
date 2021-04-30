using Main.Model.Entities.Actors.Player;

namespace Main.Controller.Entities.Player.Command
{
    /// <summary>
    ///     Encapsulates IPlayer.Attack
    /// </summary>
    public class AttackCommand : ICommand
    {
        public void Execute(IPlayer player)
        {
            player.Attack();
        }
    }
}
