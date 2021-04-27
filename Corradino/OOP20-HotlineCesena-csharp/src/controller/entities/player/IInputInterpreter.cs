using System;
using System.Collections.Generic;
using OOP20_HotlineCesena_csharp.commons;
using OOP20_HotlineCesena_csharp.model.entities.actors.player;

namespace OOP20_HotlineCesena_csharp.controller.entities.player
{
    /// <summary>
    /// <para>
    /// Converts keyboard and mouse inputs received from the View into a collection
    /// of commands <see cref="IPlayer"/> can understand.
    /// </para>
    /// <para>
    /// Its implementations must be View-agnostic, meaning they must work with virtually
    /// any graphics library without needing any modifications.
    /// </para>
    /// Despite the name, it's not an application of the Interpreter pattern.
    /// </summary>
    public interface IInputInterpreter
    {
        /// <summary>
        /// Interprets inputs received from the View and converts them to
        /// <see cref="Action"/>s for a <see cref="IPlayer"/> controller to execute.
        /// </summary>
        /// <param name="inputs"> raw inputs captured by the View </param>
        /// <param name="spritePosition"> position of the player's sprite on the screen </param>
        /// <param name="deltaTime"> time elapsed since the last frame </param>
        /// <returns> a set of Commands an external player controller
        /// may execute </returns>
        ///
        ICollection<Action<IPlayer>> Interpret(Tuple<ISet<Enum>, IPoint2D> inputs, IPoint2D spritePosition,
            double deltaTime);
    }
}
