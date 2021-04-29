namespace Zammarchi.Items.Weapon.AttackStrategy
{
    /// <summary>
    ///     The fire strategy for weapons.
    /// </summary>
    public interface IAttackStrategy
    {
        /// <summary>
        ///     Generate projectiles in different ways.
        /// </summary>
        /// <param name="weapon"></param>
        void Shoot(Weapon weapon);
    }
}
