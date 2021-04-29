using Zammarchi.Items.Weapon.AttackStrategy;

namespace Zammarchi.Items.Weapon
{
    /// <summary>
    ///     Builder class for the types of weapon.
    /// </summary>
    class WeaponBuilder
    {
        /// <summary>
        ///     The damage of this type of weapon.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        ///     The magazine size of this type of weapon.
        /// </summary>
        public int MagazineSize { get; private set; }

        /// <summary>
        ///     The fire startegy of this type of weapon.
        /// </summary>
        public IAttackStrategy AttackStrategy { get; private set; }

        /// <summary>
        ///     Class constructor. Assign different values to the weapon based on the weapon type.
        /// </summary>
        /// <param name="weaponType"> the specific type of weapon.</param>
        public WeaponBuilder(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.Shotgun:
                    Builder(10, 8, new SpreadShot());
                    break;
                case WeaponType.Rifle:
                    Builder(20, 30, new SingleStraightShot());
                    break;
                case WeaponType.Pistol:
                    Builder(15, 10, new SingleStraightShot());
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     Builder of the weapon.
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="magazineSize"></param>
        /// <param name="attackStrategy"></param>
        private void Builder(int damage, int magazineSize, IAttackStrategy attackStrategy)
        {
            this.Damage = damage;
            this.MagazineSize = magazineSize;
            this.AttackStrategy = attackStrategy;
        }
    }
}
