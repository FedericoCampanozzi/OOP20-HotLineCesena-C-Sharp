using System;
using System.Collections.Generic;
using OOP20_HotlineCesena_csharp.commons;
using OOP20_HotlineCesena_csharp.model.entities.actors.player;

namespace OOP20_HotlineCesena_csharp.controller.entities.player
{
    public interface IInputInterpreter
    {
        ICollection<Action<IPlayer>> Interpret(Tuple<ISet<Enum>, IPoint2D> inputs, IPoint2D spritePosition, double deltaTime);
    }
}