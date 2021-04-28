using OOP20_HotlineCesena_csharp.model.entities.actors.player;

namespace OOP20_HotlineCesena_csharp.controller.entities.player.command
{
    /// <summary>
    ///     Interface used for applying the Command pattern.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        ///     Allows to invoke one or more <see cref="IPlayer"/> methods.
        /// </summary>
        /// <param name="player">the <see cref="IPlayer"/> instance this
        /// command will be given to</param>
        void Execute(IPlayer player);
    }
}
