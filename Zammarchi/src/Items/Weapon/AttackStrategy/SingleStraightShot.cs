using System;
using System.Collections.Generic;
using System.Text;

namespace Zammarchi.Items.Weapon.AttackStrategy
{
    public class SingleStraightShot : IAttackStrategy
    {
        readonly Inventory inventory = Inventory.Instance;

        public void Shoot(Weapon weapon)
        {
            inventory.DamageCounter += weapon.Damage;
            inventory.ProjCounter++;
            weapon.Magazine--;
        }
    }
}
