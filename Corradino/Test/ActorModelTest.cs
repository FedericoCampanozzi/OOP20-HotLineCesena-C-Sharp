using System.Collections.Generic;
using NUnit.Framework;
using OOP20_HotlineCesena_csharp.commons;
using OOP20_HotlineCesena_csharp.model.entities;
using OOP20_HotlineCesena_csharp.model.entities.actors;
using OOP20_HotlineCesena_csharp.model.entities.actors.player;

namespace Test
{
    public class ActorModelTest
    {
        const double Speed = 1.0;
        const int Angle = 270;
        const double Width = 1.0;
        const double Height = 1.0;
        const double MaxHp = 100.0;
        IActor _actor;
        readonly IDictionary<ActorStatus, double> _noiseMap = new Dictionary<ActorStatus, double>();
        readonly IEnumerable<IEntity> _obstacles = new HashSet<IEntity>();

        [SetUp]
        public void Setup()
        {
            _actor = new Player(Point2D.Zero, Width, Height, Angle, Speed, MaxHp, _noiseMap, _obstacles);
        }

        [TearDown]
        public void ResetStatus()
        {
            _actor.Update(0.0);
        }

        [Test]
        public void ActorMove()
        {
            _actor.Move(Direction.North.Get);
            Assert.That(_actor.Position, Is.EqualTo(Direction.North.Get.Multiply(Speed)));
            Assert.That(_actor.Status, Is.EqualTo(ActorStatus.Moving));
        }

        [Test]
        public void ActorRotate()
        {
            _actor.Angle = 90.0;
            Assert.That(_actor.Angle, Is.EqualTo(90.0));
            Assert.That(_actor.Status, Is.EqualTo(ActorStatus.Idle));
        }

        [Test]
        public void ActorTakeDamage()
        {
            double damage = 50.0;
            _actor.TakeDamage(damage);
            Assert.That(_actor.CurrentHealth, Is.EqualTo(MaxHp - damage));
            double unrealDamage = 2000.0;
            _actor.TakeDamage(unrealDamage);
            Assert.That(_actor.CurrentHealth, Is.EqualTo(0.0));
            Assert.That(_actor.Status, Is.EqualTo(ActorStatus.Dead));
        }

        [Test]
        public void ActorDoesNotMoveWhenDead()
        {
            IPoint2D startingPos = _actor.Position;
            _actor.TakeDamage(MaxHp);
            _actor.Move(Direction.South.Get);
            Assert.That(_actor.Position, Is.EqualTo(startingPos));
        }

        [Test]
        public void ActorDoesNotRotateWhenDead()
        {
            double startingAngle = _actor.Angle;
            _actor.TakeDamage(MaxHp);
            _actor.Angle = 0.0;
            Assert.That(_actor.Angle, Is.EqualTo(startingAngle));
        }

        [Test]
        public void ActorDoesNotHealWhenDead()
        {
            _actor.TakeDamage(MaxHp);
            double unrealHp = 50000.0;
            _actor.Heal(unrealHp);
            Assert.That(_actor.CurrentHealth, Is.EqualTo(0.0));
        }
    }
}
