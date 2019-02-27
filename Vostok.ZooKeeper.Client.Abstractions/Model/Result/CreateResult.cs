using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents ZooKeeper create node result.</para>
    /// <para>Possible unsuccessful statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeAlreadyExists"/></description></item>
    ///     <item><description><see cref="ZooKeeperStatus.ChildrenForEphemeralsAreNotAllowed"/></description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class CreateResult : ZooKeeperResult<string>
    {
        /// <summary>
        /// Returns path of created node.
        /// </summary>
        public string NewPath => Payload;

        /// <summary>
        /// Creates a new instance of <see cref="CreateResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node to be created.</param>
        /// <param name="newPath">Path of created node.</param>
        public CreateResult(ZooKeeperStatus status, string path, string newPath)
            : base(status, path, newPath)
        {
        }
    }
}