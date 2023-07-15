namespace Custom.UpdateManager
{
    public interface IUpdatable
    {
        
    }

    public static class IUpdatableExtension
    {
        public static void RegisterInManager(this IUpdatable input)
        {
            CustomUpdateManager.Instance.Register(input);
        }

        public static void UnregisterInManager(this IUpdatable input)
        {
            CustomUpdateManager.Instance.Unregister(input);
        }
    }
}