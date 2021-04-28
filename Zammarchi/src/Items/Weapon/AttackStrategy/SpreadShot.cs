using System;
using System.Collections.Generic;
using System.Text;

namespace Zammarchi.Items.Weapon.AttackStrategy
{
    public class SpreadShot : IAttackStrategy
    {
        public int ProjCount { get; } = 3;
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
