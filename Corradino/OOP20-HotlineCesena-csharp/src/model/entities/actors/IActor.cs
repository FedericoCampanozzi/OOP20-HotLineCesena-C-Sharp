namespace OOP20_HotlineCesena_csharp.model.entities.actors
{
    public interface IActor : IMovableEntity
    {
        double MaxHealth { get; }

        double CurrentHealth { get; }

        ActorStatus Status { get; }

        IInventory Inventory { get; }

        void Attack();

        void Reload();

        void TakeDamage(double damage);

        void Heal(double hp);

        void Update(double timeElapsed);
    }
}
