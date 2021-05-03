namespace Zammarchi.Items.Weapon.AttackStrategy
{
    /// <summary>
    ///     A type of fire strategy: generates multiple projectiles for each shot.
    /// </summary>
    public class SpreadShot : IAttackStrategy
    {
        /// <summary>
        ///     The amount of projectiles that have to be generated.
        /// </summary>
        public int ProjCount { get; } = 3;

        /// <summary>
        ///     The instance of the inventory
        /// </summary>
        readonly Inventory inventory = Inventory.Instance;

        public void Shoot(Weapon weapon)
        {
            for (int i = 0; i < ProjCount; i++)
            {
                inventory.DamageCounter += weapon.Damage;
                inventory.ProjCounter++;
            }
            weapon.Magazine--;
        }
    }
}
