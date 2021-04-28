using System;
using System.Collections.Generic;
using System.Text;

namespace OOP20_HotlineCesena_csharp.Weapon.AttackStrategy
{
    public class SingleStraightShot : IAttackStrategy
    {
        readonly History history = History.Instance;

        public void Shoot(Weapon weapon)
        {
            history.DamageCounter += weapon.Damage;
            history.ProjCounter++;
            weapon.Magazine--;
        }
    }
}
