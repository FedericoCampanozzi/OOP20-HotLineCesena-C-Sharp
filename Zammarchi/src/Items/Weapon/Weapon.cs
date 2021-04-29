using Zammarchi.Items.Weapon.AttackStrategy;

namespace Zammarchi.Items.Weapon
{
    /// <summary>
    ///     A game entity, equipped to the player, that can shoot and reload.
    /// </summary>
    public class Weapon : IItems
    {
        /// <summary>
        ///     The type of the weapon
        /// </summary>
        /// <returns> this weapon type.</returns>
        public WeaponType weaponType;

        /// <summary>
        ///     The damage that each projectile deals
        /// </summary>
        /// <returns> the amount of damage.</returns>
        public int Damage { get; }

        /// <summary>
        ///     The current amount of projectiles
        /// </summary>
        /// <returns> the current amount of projectiles in this weapon.</returns>
        public int Magazine { get; set; }

        /// <summary>
        ///     The weapon magazine size.
        /// </summary>
        /// <returns> this weapon magazine size.</returns>
        public int MagazineSize { get; }

        /// <summary>
        ///     The strategy of fire.
        /// </summary>
        /// <returns> this weapon attack startegy.</returns>
        public IAttackStrategy AttackStrategy { get; }

        /// <summary>
        ///     Class constructor. Initialize weapon values.
        /// </summary>
        /// <param name="weaponType"></param>
        public Weapon(WeaponType weaponType)
        {
            WeaponBuilder weaponBuilder = new WeaponBuilder(weaponType);
            this.weaponType = weaponType;
            this.Damage = weaponBuilder.Damage;
            this.Magazine = weaponBuilder.MagazineSize;
            this.MagazineSize = weaponBuilder.MagazineSize;
            this.AttackStrategy = weaponBuilder.AttackStrategy;
        }

        /// <summary>
        ///     The fire action of the weapon.
        ///     If the weapon has no projectiles left, reload itself.
        /// </summary>
        public void Fire()
        {
            if (Magazine > 0)
            {
                AttackStrategy.Shoot(this);
            }
            else
            {
                Reload();
                Fire();
            }

        }

        /// <summary>
        ///     Recharge the projectiles in the weapon
        /// </summary>
        public void Reload()
        {
            Magazine = MagazineSize;
        }

        /// <summary>
        ///     The usage of this weapon: fire
        /// </summary>
        public void Usage()
        {
            Fire();
        }
    }
}
