using System;
using System.Collections.Generic;
using System.Linq;
using OOP20_HotlineCesena_csharp.commons;
using OOP20_HotlineCesena_csharp.controller.entities.player.command;
using OOP20_HotlineCesena_csharp.model.entities.actors.player;
using OOP20_HotlineCesena_csharp.utils;

namespace OOP20_HotlineCesena_csharp.controller.entities.player
{
    /// <summary>
    /// <see cref="IInputInterpreter"/> implementation.
    /// </summary>
    public sealed class InputInterpreter : IInputInterpreter
    {
        const float Deadzone = 50.0f;
        readonly IDictionary<Enum, string> _bindings;
        readonly IDictionary<string, Action<IPlayer>> _continuousActions;
        readonly IDictionary<string, IDirection> _movements;
        readonly IDictionary<string, Action<IPlayer>> _oneTimeActions;
        readonly ISet<string> _oneTimeHistory = new HashSet<string>();
        IPoint2D _currentMouseCoords = Point2D.Zero;

        public InputInterpreter(IDictionary<Enum, string> bindings, IDictionary<string, IDirection> movements,
            IDictionary<string, Action<IPlayer>> continuousActions, IDictionary<string, Action<IPlayer>> oneTimeActions)
        {
            (_bindings, _movements, _continuousActions, _oneTimeActions) = (
                Objects.RequireNonNull(bindings),
                Objects.RequireNonNull(movements),
                Objects.RequireNonNull(continuousActions),
                Objects.RequireNonNull(oneTimeActions)
                );
        }

        public ICollection<Action<IPlayer>> Interpret(Tuple<ISet<Enum>, IPoint2D> inputs, IPoint2D spritePosition,
            double deltaTime)
        {
            var outList = new List<Action<IPlayer>>();
            (ISet<Enum> keysAndButtons, IPoint2D mouseCoords) = Objects.RequireNonNull(inputs);
            ISet<string> actionNames = ConvertBindings(keysAndButtons);

            // Compute new movement direction
            IPoint2D moveDir = ProcessMovementDirection(actionNames);
            if (!Equals(moveDir, Direction.None.Get))
            {
                outList.Add(Command.MoveCommand(moveDir.Multiply(deltaTime)));
            }

            // Compute new angle
            IPoint2D newMouseCoords = ProcessMouseCoordinates(mouseCoords, spritePosition);
            if (!_currentMouseCoords.Equals(newMouseCoords))
            {
                outList.Add(Command.RotateCommand(MathUtils.MouseToDegrees(newMouseCoords)));
                _currentMouseCoords = newMouseCoords;
            }

            /*
             * Compute actions that need to be executed only once if
             * the user keeps holding the assigned key
             */
            outList.AddRange(ProcessOneTimeActions(actionNames));

            /*
             * Compute actions that can be executed continuously
             */
            outList.AddRange(ProcessContinuousActions(actionNames));

            return outList;
        }

        ISet<string> ConvertBindings(IEnumerable<Enum> inputs)
        {
            return inputs
                .Where(_bindings.ContainsKey)
                .Select(k => _bindings[k])
                .ToHashSet();
        }

        IPoint2D ProcessMovementDirection(ICollection<string> actions)
        {
            return _movements
                .Where(e => actions.Contains(e.Key))
                .Select(e => e.Value.Get)
                .Aggregate(Point2D.Zero, (p1, p2) => p1.Add(p2))
                .Normalize();
        }

        IPoint2D ProcessMouseCoordinates(IPoint2D mouseCoords, IPoint2D spritePosition)
        {
            return spritePosition.Distance(mouseCoords) > Deadzone
                ? mouseCoords.Subtract(spritePosition)
                : _currentMouseCoords;
        }

        IEnumerable<Action<IPlayer>> ProcessOneTimeActions(ICollection<string> actions)
        {
            foreach (KeyValuePair<string, Action<IPlayer>> entry in _oneTimeActions)
            {
                if (actions.Contains(entry.Key) && !_oneTimeHistory.Contains(entry.Key))
                {
                    _oneTimeHistory.Add(entry.Key);
                    yield return entry.Value;
                }
                else if (!actions.Contains(entry.Key))
                {
                    _oneTimeHistory.Remove(entry.Key);
                }
            }
        }

        IEnumerable<Action<IPlayer>> ProcessContinuousActions(ICollection<string> actions)
        {
            return _continuousActions
                .Where(e => actions.Contains(e.Key))
                .Select(e => e.Value)
                .ToList();
        }
    }
}
