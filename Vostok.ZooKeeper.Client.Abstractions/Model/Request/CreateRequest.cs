using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper create node request.
    /// </summary>
    [PublicAPI]
    public class CreateRequest : ZooKeeperRequest
    {
        /// <inheritdoc/>
        /// <summary>
        /// Creates a new instance of <see cref="CreateRequest"/>.
        /// </summary>
        /// <param name="path">Path of node to be created. All parent nodes will be created if they do not exist.</param>
        /// <param name="createMode">Type of node to be created. May be ephemeral/persistent and/or sequential.</param>
        public CreateRequest([NotNull] string path, CreateMode createMode)
            : base(path)
        {
            CreateMode = createMode;
        }

        /// <summary>
        /// <para>Data of node to be created.</para>
        /// <para>The maximum allowed size of the data array is 1 Mb.</para>
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Type of node to be created. May be ephemeral/persistent and/or sequential.
        /// </summary>
        public CreateMode CreateMode { get; }

        /// <summary>
        /// Returns string representation of <see cref="CreateRequest"/>.
        /// </summary>
        public override string ToString() => $"CREATE {base.ToString()}, {nameof(Data)} length: {Data?.Length}, {nameof(CreateMode)}: {CreateMode}";
    }
}