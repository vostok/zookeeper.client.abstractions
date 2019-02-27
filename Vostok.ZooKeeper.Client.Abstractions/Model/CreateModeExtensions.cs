using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// A set of extensions for <see cref="CreateMode"/>.
    /// </summary>
    [PublicAPI]
    public static class CreateModeExtensions
    {
        /// <summary>
        /// Checks that create mode is sequential.
        /// </summary>
        public static bool IsSequential(this CreateMode createMode)
        {
            return createMode == CreateMode.EphemeralSequential || createMode == CreateMode.PersistentSequential;
        }

        /// <summary>
        /// Checks that create mode is ephemeral.
        /// </summary>
        public static bool IsEphemeral(this CreateMode createMode)
        {
            return createMode == CreateMode.Ephemeral || createMode == CreateMode.EphemeralSequential;
        }
    }
}