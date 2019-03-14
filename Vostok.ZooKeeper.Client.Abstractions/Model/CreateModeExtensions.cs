using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    [PublicAPI]
    public static class CreateModeExtensions
    {
        /// <summary>
        /// Returns whether given create mode is sequential.
        /// </summary>
        public static bool IsSequential(this CreateMode createMode)
            => createMode == CreateMode.EphemeralSequential || createMode == CreateMode.PersistentSequential;

        /// <summary>
        /// Returns whether given create mode is ephemeral.
        /// </summary>
        public static bool IsEphemeral(this CreateMode createMode)
            => createMode == CreateMode.Ephemeral || createMode == CreateMode.EphemeralSequential;
    }
}