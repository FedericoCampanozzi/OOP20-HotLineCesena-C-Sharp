using System.Collections.Generic;
using Main.Commons;
using Main.Controller.Entities.Player.Command;
using Main.Model.Entities;
using Main.Model.Entities.Actors;
using Main.Model.Entities.Actors.Player;
using NUnit.Framework;


namespace Test
{
    public class PlayerTest
    {
        const double Speed = 2.0;
        const int Angle = 270;
        const double PlayerWidth = 1.0;
        const double PlayerHeight = 1.0;
        const double MaxHp = 100.0;

        const double ObstacleWidth = 0.5;
        const double ObstacleHeight = 0.5;

        readonly IDictionary<ActorStatus, double> _noiseMap = new Dictionary<ActorStatus, double>
        {
            {ActorStatus.Idle, 0.0},
            {ActorStatus.Moving, 8.0},
            {ActorStatus.Attacking, 15.0},
            {ActorStatus.Dead, 0.0}
        };

        readonly IEnumerable<IEntity> _obstacles = new HashSet<IEntity>
        {
            new Obstacle(new Point2D(0.0, -1.0), ObstacleWidth, ObstacleHeight)
        };

        readonly IPoint2D _startingPos = Point2D.Zero;
        IPlayer _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player(_startingPos, PlayerWidth, PlayerHeight, Angle, Speed, MaxHp, _noiseMap, _obstacles);
        }

        [TearDown]
        public void ResetStatus()
        {
            _player.Update(0.0);
        }

        [Test]
        public void Collisions()
        {
            Assert.That(_player.Status, Is.Not.EqualTo(ActorStatus.Dead));
            _player.Move(Direction.North.Get); // Should be hitting an obstacle
            Assert.That(_player.Position, Is.Not.EqualTo(Direction.North.Get.Multiply(Speed)));
        }

        [Test]
        public void NoiseRadius()
        {
            _player.Move(Direction.South.Get);
            Assert.That(_player.Status, Is.EqualTo(ActorStatus.Moving));
            Assert.That(_player.NoiseRadius, Is.EqualTo(_noiseMap[ActorStatus.Moving]));
            _player.Attack();
            Assert.That(_player.Status, Is.EqualTo(ActorStatus.Attacking));
            Assert.That(_player.NoiseRadius, Is.EqualTo(_noiseMap[ActorStatus.Attacking]));
            _player.TakeDamage(5000.0);
            Assert.That(_player.NoiseRadius, Is.EqualTo(_noiseMap[ActorStatus.Dead]));
        }

        [Test]
        public void ReceiveCommand()
        {
            Assert.That(_player.Position, Is.EqualTo(_startingPos));
            new MoveCommand(Direction.East.Get).Execute(_player);
            Assert.That(_player.Position, Is.EqualTo(Direction.East.Get.Multiply(Speed)));
        }
    }
}
