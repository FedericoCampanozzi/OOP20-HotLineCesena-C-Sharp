namespace Zammarchi.Items
{
    /// <summary>
    ///     A builder class that assigns an ItemsType to a CollectibleType.
    ///     When an ItemsType is picked up, add an amount of a CollectibleType to the inventory.
    /// </summary>
    public class Items : IItems
    {
        /// <summary>
        ///     The instance of the inventory.
        /// </summary>
        /// <returns> the actual instance of the inventory.</returns>
        Inventory inventory = Inventory.Instance;

        /// <summary>
        ///     A type of ItemsType.
        /// </summary>
        /// <returns> this item type.</returns>
        public ItemsType ItemsType { get; private set; }

        /// <summary>
        ///     A type of CollectibleType.
        /// </summary>
        /// <returns> this collectible type.</returns>
        public CollectibleType CollectibleType { get; private set; }

        /// <summary>
        ///     The amount of a type of CollectibleType that has to be added to the inventory
        /// </summary>
        /// <returns> this specific amount for the collectible.</returns>
        public int Amount { get; private set; }

        /// <summary>
        ///     For each ItemsType assigns a CollectibleType and its amount.
        /// </summary>
        /// <param name="itemsType"> the specific type of item.</param>
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
        /// <summary>
        ///     The usage of the ItemsType.
        ///     Add the amount of CollectibleType to the inventory.
        /// </summary>
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
