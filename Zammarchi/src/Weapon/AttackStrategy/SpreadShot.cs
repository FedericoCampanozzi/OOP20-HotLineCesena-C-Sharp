using System;
using System.Collections.Generic;
using System.Text;

namespace Zammarchi.Weapon.AttackStrategy
{
    public class SpreadShot : IAttackStrategy
    {
        public int ProjCount { get; } = 3;
        readonly History history = History.Instance;

        public void Shoot(Weapon weapon)
        {
            for (int i = 0; i < ProjCount; i++)
            {
                history.DamageCounter += weapon.Damage;
                history.ProjCounter++;
            }
            weapon.Magazine--;
        }
    }
}
