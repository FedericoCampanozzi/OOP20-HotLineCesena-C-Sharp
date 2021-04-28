using System;
using System.Collections.Generic;
using System.Text;

namespace Zammarchi.Weapon.AttackStrategy
{
    public interface IAttackStrategy
    {
        void Shoot(Weapon weapon);
    }
}
