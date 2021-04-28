using NUnit.Framework;
using OOP20_HotlineCesena_csharp;
using OOP20_HotlineCesena_csharp.Weapon;
using OOP20_HotlineCesena_csharp.Weapon.AttackStrategy;
using System;

namespace Test
{
    public class ShotTest
    {
        History history;

        [SetUp]
        public void SetUp()
        {
            this.history = History.Instance;
        }

        [TearDown]
        public void Update()
        {
            this.history.Reset();
        }

        [Test]
        public void RifleShot()
        {
            Weapon rifle = new Weapon(WeaponType.Rifle);
            rifle.Fire();
            Assert.That(history.ProjCounter, Is.EqualTo(1));
            Assert.That(history.DamageCounter, Is.EqualTo(rifle.Damage));
        }

        [Test]
        public void PistolShot()
        {
            Weapon pistol = new Weapon(WeaponType.Pistol);
            pistol.Fire();
            Assert.That(history.ProjCounter, Is.EqualTo(1));
            Assert.That(history.DamageCounter, Is.EqualTo(pistol.Damage));
        }

        [Test]
        public void ShotgunShot()
        {
            Weapon shotgun = new Weapon(WeaponType.Shotgun);
            shotgun.Fire();
            Assert.That(history.ProjCounter, Is.EqualTo(new SpreadShot().ProjCount));
            Assert.That(history.DamageCounter, Is.EqualTo(shotgun.Damage * new SpreadShot().ProjCount));
        }
    }
}
