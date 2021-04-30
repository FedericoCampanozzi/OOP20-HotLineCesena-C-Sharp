using Main.Model.Entities.Actors.player;

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
