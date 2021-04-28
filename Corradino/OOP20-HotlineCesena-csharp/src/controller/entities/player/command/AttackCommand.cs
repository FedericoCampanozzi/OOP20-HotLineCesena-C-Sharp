using OOP20_HotlineCesena_csharp.model.entities.actors.player;

namespace OOP20_HotlineCesena_csharp.controller.entities.player.command
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
