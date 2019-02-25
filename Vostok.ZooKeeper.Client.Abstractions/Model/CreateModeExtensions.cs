namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    public static class CreateModeExtensions
    {
        public static bool IsSequential(this CreateMode createMode)
        {
            return createMode == CreateMode.EphemeralSequential || createMode == CreateMode.PersistentSequential;
        }

        public static bool IsEphemeral(this CreateMode createMode)
        {
            return createMode == CreateMode.Ephemeral || createMode == CreateMode.EphemeralSequential;
        }
    }
}