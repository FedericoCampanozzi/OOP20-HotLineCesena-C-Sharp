using Zammarchi.Items.Weapon.AttackStrategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zammarchi.Items.Weapon
{
    class WeaponBuilder
    {
        public int Damage { get; private set; }
        public int MagazineSize { get; private set; }
        public IAttackStrategy AttackStrategy { get; private set; }

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

        private void Builder(int damage, int magazineSize, IAttackStrategy attackStrategy)
        {
            this.Damage = damage;
            this.MagazineSize = magazineSize;
            this.AttackStrategy = attackStrategy;
        }
    }
}
