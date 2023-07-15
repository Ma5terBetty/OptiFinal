namespace Custom.UpdateManager
{
    public interface IGameplayUpdate : IUpdatable
    {
        void Tick();
    }
}