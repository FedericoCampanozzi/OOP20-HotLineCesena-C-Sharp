namespace OOP20_HotlineCesena_csharp.model.entities.actors
{
    /// <summary>
    ///     Animated entity that is able to perform a set of basic actions.
    ///     Deleted all references to Inventory, since it is not needed here.
    /// </summary>
    public interface IActor : IMovableEntity
    {
        double MaxHealth { get; }

        double CurrentHealth { get; }

        ActorStatus Status { get; }

        void Attack();

        void Reload();

        void TakeDamage(double damage);

        void Heal(double hp);

        void Update(double timeElapsed);
    }
}
