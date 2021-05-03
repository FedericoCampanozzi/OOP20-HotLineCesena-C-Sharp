using System;
using System.Collections.Generic;
using Main.Commons;
using Main.Controller.Entities.Player;
using Main.Controller.Entities.Player.Command;
using NUnit.Framework;

namespace Test
{
    public class InterpreterTest
    {
        const double SceneWidth = 800.0;
        const double SceneHeight = 600.0;
        const double DeltaTime = 1.0;

        static readonly IPoint2D SpritePos = Point2D.Zero;

        readonly IDictionary<Enum, string> _bindings = new Dictionary<Enum, string>
        {
            {KeyCode.W, "move_north"},
            {KeyCode.S, "move_south"},
            {KeyCode.D, "move_east"},
            {KeyCode.A, "move_west"},
            {KeyCode.R, "reload"},
            {KeyCode.E, "use"},
            {MouseButton.Primary, "attack"}
        };

        readonly IDictionary<string, ICommand> _continuousActions = new Dictionary<string, ICommand>
        {
            {"attack", new AttackCommand()},
            {"reload", new ReloadCommand()},
            {"use", new UseCommand()}
        };

        readonly IDictionary<string, ICommand> _oneTimeActions = new Dictionary<string, ICommand>();

        readonly IDictionary<string, IDirection> _movements = new Dictionary<string, IDirection>
        {
            {"move_north", Direction.North},
            {"move_south", Direction.South},
            {"move_east", Direction.East},
            {"move_west", Direction.West}
        };

        IInputInterpreter _interpreter;

        [SetUp]
        public void Setup()
        {
            _interpreter =
                new InputInterpreter(_bindings, _movements, _continuousActions, _oneTimeActions);
        }

        [Test]
        public void DeliverNothingWhenReceivingNoInputs()
        {
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum>(), Point2D.Zero);
            ICollection<ICommand> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Assert.That(commands, Is.Empty);
        }

        [Test]
        public void DeliverNothingWhenReceivingUnboundInputs()
        {
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum> {KeyCode.J}, Point2D.Zero);
            ICollection<ICommand> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Assert.That(commands, Is.Empty);
        }

        [Test]
        public void DeliverMouseCommand()
        {
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum> {MouseButton.Primary}, Point2D.Zero);
            ICollection<ICommand> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Assert.That(commands, Has.Exactly(1).Items);
            Assert.That(commands, Does.Contain(_continuousActions[_bindings[MouseButton.Primary]]));
        }

        [Test]
        public void DeliverKeyCommand()
        {
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum> {KeyCode.E}, Point2D.Zero);
            ICollection<ICommand> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Assert.That(commands, Has.Exactly(1).Items);
            Assert.That(commands, Does.Contain(_continuousActions[_bindings[KeyCode.E]]));
        }

        [Test]
        public void DeliverMovement()
        {
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum> {KeyCode.W}, Point2D.Zero);
            ICollection<ICommand> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Assert.That(commands, Has.Exactly(1).Items);
            Assert.That(commands, Has.One.Matches<ICommand>(c => c is MoveCommand));
        }

        [Test]
        public void DeliverRotation()
        {
            var mouseCoords = new Point2D(SceneWidth / 2.0, SceneHeight);
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum>(), mouseCoords);
            ICollection<ICommand> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Assert.That(commands, Has.Exactly(1).Items);
            Assert.That(commands, Has.One.Matches<ICommand>(c => c is RotateCommand));
        }

        enum KeyCode
        {
            W,
            S,
            D,
            A,
            R,
            E,
            J
        }

        enum MouseButton
        {
            Primary,
            Secondary
        }
    }
}
