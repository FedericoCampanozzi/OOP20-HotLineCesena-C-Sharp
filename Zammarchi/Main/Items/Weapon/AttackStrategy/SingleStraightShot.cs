namespace Zammarchi.Items.Weapon.AttackStrategy
{
    /// <summary>
    ///     A type of fire strategy: generates a single projectile for each shot.
    /// </summary>
    public class SingleStraightShot : IAttackStrategy
    {
        /// <summary>
        ///     The instance of the inventory.
        /// </summary>
        readonly Inventory inventory = Inventory.Instance;

        public void Shoot(Weapon weapon)
        {
            inventory.DamageCounter += weapon.Damage;
            inventory.ProjCounter++;
            weapon.Magazine--;
        }
    }
}
