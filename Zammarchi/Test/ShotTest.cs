using NUnit.Framework;
using Zammarchi;
using Zammarchi.Items.Weapon;
using Zammarchi.Items.Weapon.AttackStrategy;

namespace Test
{
    /// <summary>
    ///     Tests the different types of fire strategies of the weapons.
    /// </summary>
    public class ShotTest
    {
        Inventory inventory;

        [SetUp]
        public void SetUp()
        {
            this.inventory = Inventory.Instance;
        }

        [TearDown]
        public void Update()
        {
            this.inventory.Reset();
        }

        [Test]
        public void RifleShotTest()
        {
            Weapon rifle = new Weapon(WeaponType.Rifle);
            rifle.Fire();
            Assert.That(inventory.ProjCounter, Is.EqualTo(1));
            Assert.That(inventory.DamageCounter, Is.EqualTo(rifle.Damage));
        }

        [Test]
        public void PistolShotTest()
        {
            Weapon pistol = new Weapon(WeaponType.Pistol);
            pistol.Fire();
            Assert.That(inventory.ProjCounter, Is.EqualTo(1));
            Assert.That(inventory.DamageCounter, Is.EqualTo(pistol.Damage));
        }

        [Test]
        public void ShotgunShotTest()
        {
            Weapon shotgun = new Weapon(WeaponType.Shotgun);
            shotgun.Fire();
            Assert.That(inventory.ProjCounter, Is.EqualTo(new SpreadShot().ProjCount));
            Assert.That(inventory.DamageCounter, Is.EqualTo(shotgun.Damage * new SpreadShot().ProjCount));
        }
    }
}
