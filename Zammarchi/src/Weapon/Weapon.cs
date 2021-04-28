using System;
using System.Collections.Generic;
using System.Text;
using Zammarchi.Weapon.AttackStrategy;

namespace Zammarchi.Weapon
{
    public class Weapon
    {
        public WeaponType weaponType;
        private readonly IAttackStrategy attackStrategy;

        public int Damage { get; }
        public int Magazine { get; set; }
        public int MagazineSize { get; }
        public IAttackStrategy AttackStrategy => attackStrategy;
        public Weapon(WeaponType weaponType)
        {
            WeaponBuilder weaponBuilder = new WeaponBuilder(weaponType);
            this.weaponType = weaponType;
            this.Damage = weaponBuilder.Damage;
            this.Magazine = weaponBuilder.MagazineSize;
            this.MagazineSize = weaponBuilder.MagazineSize;
            this.attackStrategy = weaponBuilder.AttackStrategy;
        }

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

        public void Reload()
        {
            Magazine = MagazineSize;
        }

    }
}
