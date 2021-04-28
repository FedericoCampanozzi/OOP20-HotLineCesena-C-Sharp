using NUnit.Framework;
using Zammarchi;
using Zammarchi.Items;
using System;

namespace Test
{
    public class ItemsTest
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
        public void BriefCaseTest()
        {
            Items briefCase = new Items(ItemsType.BriefCase);
            briefCase.Usage();
            Assert.That(inventory.MoneyCounter, Is.EqualTo(briefCase.Amount));
        }

        [Test]
        public void AmmoBagTest()
        {
            Items ammoBag = new Items(ItemsType.AmmoBag);
            ammoBag.Usage();
            Assert.That(inventory.AmmoCounter, Is.EqualTo(ammoBag.Amount));
        }
    }
}
