using NUnit.Framework;
using Zammarchi;
using Zammarchi.Items.Weapon;

namespace Test
{
    /// <summary>
    ///     Tests the correct handling of weapon projectiles.
    /// </summary>
    public class AmmoTest
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
        public void AmmoDecTest()
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
        public void RealoadTest()
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
