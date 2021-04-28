using NUnit.Framework;
using Zammarchi;
using Zammarchi.Weapon;
using Zammarchi.Weapon.AttackStrategy;
using System;

namespace Test
{
    public class AmmoTest
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
        public void AmmoDec()
        {
            Weapon rifle = new Weapon(WeaponType.Rifle);
            int attackCounter = 5;
            for (int i = 0; i < attackCounter; i++)
            {
                rifle.Fire();
            }
            Assert.That(rifle.Magazine, Is.EqualTo(rifle.MagazineSize - attackCounter));
        }

        [Test]
        public void Reaload()
        {
            Weapon rifle = new Weapon(WeaponType.Rifle);
            int attackCounter = rifle.Magazine + 1;
            for (int i = 0; i < attackCounter; i++)
            {
                rifle.Fire();
            }
            Assert.That(rifle.Magazine, Is.EqualTo(rifle.MagazineSize - 1));
            rifle.Reload();
            Assert.That(rifle.Magazine, Is.EqualTo(rifle.MagazineSize));
        }
    }
}
