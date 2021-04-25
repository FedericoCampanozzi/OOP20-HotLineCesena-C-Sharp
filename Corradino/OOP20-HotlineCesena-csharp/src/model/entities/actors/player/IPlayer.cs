namespace OOP20_HotlineCesena_csharp.model.entities.actors.player
{
    public interface IPlayer : IActor
    {
        double NoiseRadius { get; }

        void Use();
    }
}