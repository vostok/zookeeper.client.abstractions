using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper node creation request.
    /// </summary>
    [PublicAPI]
    public class CreateRequest : ZooKeeperRequest
    {
        /// <param name="path">Full path to the node being created.</param>
        /// <param name="createMode">Type of node to be created. See <see cref="CreateMode"/> for possible values.</param>
        public CreateRequest([NotNull] string path, CreateMode createMode)
            : base(path)
        {
            CreateMode = createMode;
        }

        /// <summary>
        /// <para>Data of node to be created; <c>null</c> means no data.</para>
        /// <para>The maximum allowed size of the data array is 1 megabyte.</para>
        /// </summary>
        [CanBeNull]
        public byte[] Data { get; set; }

        /// <summary>
        /// Type of node to be created. May be ephemeral/persistent, ordinary/sequential.
        /// </summary>
        public CreateMode CreateMode { get; }

        /// <summary>
        /// If set to <c>true</c>, client will also create all missing nodes on the path to given one.
        /// </summary>
        public bool CreateParentsIfNeeded { get; set; } = true;

        public override string ToString() 
            => $"CREATE '{Path}'; Data length = {Data?.Length ?? 0}; Mode: {CreateMode}";
    }
}