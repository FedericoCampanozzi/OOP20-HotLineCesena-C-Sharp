using System;
using Zammarchi.Items.Weapon.AttackStrategy;
using Zammarchi.Items;

namespace Zammarchi.Items.Weapon
{
    public class Weapon : IItems
    {
        public WeaponType weaponType;

        public int Damage { get; }
        public int Magazine { get; set; }
        public int MagazineSize { get; }
        public IAttackStrategy AttackStrategy { get; }
        public Weapon(WeaponType weaponType)
        {
            WeaponBuilder weaponBuilder = new WeaponBuilder(weaponType);
            this.weaponType = weaponType;
            this.Damage = weaponBuilder.Damage;
            this.Magazine = weaponBuilder.MagazineSize;
            this.MagazineSize = weaponBuilder.MagazineSize;
            this.AttackStrategy = weaponBuilder.AttackStrategy;
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

        public void Usage()
        {
            Fire();
        }
    }
}
