using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using NUnit.Framework;
using OOP20_HotlineCesena_csharp.commons;
using OOP20_HotlineCesena_csharp.controller.entities.player;
using OOP20_HotlineCesena_csharp.controller.entities.player.command;
using OOP20_HotlineCesena_csharp.model.entities.actors.player;
using OOP20_HotlineCesena_csharp.utils;

namespace Test
{
    public class Tests
    {
        enum KeyCode
        {
            W, S, D, A, R, E, J
        }
        
        enum MouseButton
        {
            Primary, Secondary
        }
        
        static readonly IPoint2D SpritePos = Point2D.Zero;
        const double SceneWidth = 800.0;
        const double SceneHeight = 600.0;
        const double DeltaTime = 1.0;
        IInputInterpreter _interpreter;
        readonly IDictionary<Enum, string> _bindings = new Dictionary<Enum, string>
        {
            {KeyCode.W,             "move_north"},
            {KeyCode.S,             "move_south"},
            {KeyCode.D,             "move_east"},
            {KeyCode.A,             "move_west"},
            {KeyCode.R,             "reload"},
            {KeyCode.E,             "use"},
            {MouseButton.Primary,   "attack"}
        };

        readonly IDictionary<string, IDirection> _movements = new Dictionary<string, IDirection>
        {
            {"move_north", Direction.North},
            {"move_south", Direction.South},
            {"move_east",  Direction.East},
            {"move_west",  Direction.West}
        };

        readonly IDictionary<string, Action<IPlayer>> _continuousActions = new Dictionary<string, Action<IPlayer>>
        {
            {"attack", p => p.Attack()},
            {"reload", p => p.Reload()},
            {"use",    p => p.Use()}
        };
        
        [SetUp]
        public void Setup()
        {
            _interpreter =
                new InputInterpreter(_bindings, _movements, _continuousActions, new Dictionary<string, Action<IPlayer>>());
        }

        [Test]
        public void DeliverNothingWhenReceivingNoInputs()
        {
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum>(), Point2D.Zero);
            ICollection<Action<IPlayer>> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Assert.That(commands, Is.Empty);
        }
        
        [Test]
        public void DeliverNothingWhenReceivingUnboundInputs() {
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum> {KeyCode.J}, Point2D.Zero);
            ICollection<Action<IPlayer>> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Assert.That(commands, Is.Empty);
        }
        
        [Test]
        public void DeliverMouseCommand() {
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum> {MouseButton.Primary}, Point2D.Zero);
            ICollection<Action<IPlayer>> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Assert.That(commands, Does.Contain(_continuousActions[_bindings[MouseButton.Primary]]));
        }
        
        [Test]
        public void DeliverKeyCommand() {
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum> {KeyCode.E}, Point2D.Zero);
            ICollection<Action<IPlayer>> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Assert.That(commands, Has.Exactly(1).Items);
            Assert.That(commands, Does.Contain(_continuousActions[_bindings[KeyCode.E]]));
        }
        
        [Test]
        public void DeliverMovement() {
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum> {KeyCode.W}, Point2D.Zero);
            ICollection<Action<IPlayer>> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Action<IPlayer> expected = Command.MoveCommand(_movements[_bindings[KeyCode.W]].Dir);
            Assert.That(commands, Has.Exactly(1).Items);
            Assert.That(commands, Has.Exactly(1).Matches<Action<IPlayer>>(c => c.Method.Equals(expected.Method)));
        }
        
        [Test]
        public void DeliverRotation()
        {
            var mouseCoords = new Point2D(SceneWidth / 2.0, SceneHeight);
            var inputs = new Tuple<ISet<Enum>, IPoint2D>(new HashSet<Enum>(), mouseCoords);
            ICollection<Action<IPlayer>> commands = _interpreter.Interpret(inputs, SpritePos, DeltaTime);
            Action<IPlayer> expected = Command.RotateCommand(MathUtils.MouseToDegrees(mouseCoords));
            Assert.That(commands, Has.Exactly(1).Items);
            Assert.That(commands, Has.Exactly(1).Matches<Action<IPlayer>>(c => c.Method.Equals(expected.Method)));
        }
    }
}