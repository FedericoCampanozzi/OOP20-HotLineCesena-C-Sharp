using System;
using System.Collections.Generic;
using System.Text;

namespace Zammarchi.Items
{
    public class Items : IItems
    {
        Inventory inventory = Inventory.Instance;
        public ItemsType ItemsType { get; private set; }
        public CollectibleType CollectibleType { get; private set; }
        public int Amount { get; private set; }
        public Items(ItemsType itemsType)
        {
            ItemsType = itemsType;
            switch (itemsType)
            {
                case ItemsType.BriefCase:
                    CollectibleType = CollectibleType.Money;
                    Amount = 50;
                    break;
                case ItemsType.AmmoBag:
                    CollectibleType = CollectibleType.Ammunitions;
                    Amount = 20;
                    break;
                default:
                    break;
            }
        }

        public void Usage()
        {
            switch (CollectibleType)
            {
                case CollectibleType.Money:
                    inventory.MoneyCounter += Amount;
                    break;
                case CollectibleType.Ammunitions:
                    inventory.AmmoCounter += Amount;
                    break;
                default:
                    break;
            }
        }
    }
}
