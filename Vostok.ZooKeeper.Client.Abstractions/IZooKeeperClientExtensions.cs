using System.Threading.Tasks;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;
using Vostok.ZooKeeper.Client.Abstractions.Model.Result;

namespace Vostok.ZooKeeper.Client.Abstractions
{
    /// <summary>
    /// A set of extensions for <see cref="IZooKeeperClient"/>.
    /// </summary>
    [PublicAPI]
    public static class IZooKeeperClientExtensions
    {
        /// <inheritdoc cref="IZooKeeperClient.CreateAsync"/>
        public static CreateResult Create(this IZooKeeperClient client, CreateRequest request) =>
            client.CreateAsync(request).GetAwaiter().GetResult();

        /// <summary>
        /// <para>Creates new node using given node <paramref name="path" />, <paramref name="createMode"/> and <paramref name="data"/>.</para>
        /// <para>All parent nodes will be created if they do not exist.</para>
        /// <para>In case of unsuccessful, result of this operation is not guaranteed.</para>
        /// </summary>
        public static async Task<CreateResult> CreateAsync(this IZooKeeperClient client, [NotNull] string path, CreateMode createMode, [CanBeNull] byte[] data = null) =>
            await client.CreateAsync(new CreateRequest(path, createMode) {Data = data}).ConfigureAwait(false);

        /// <summary>
        /// <para>Creates new node using given node <paramref name="path" />, <paramref name="createMode"/> and <paramref name="data"/>.</para>
        /// <para>All parent nodes will be created if they do not exist.</para>
        /// <para>In case of unsuccessful, result of this operation is not guaranteed.</para>
        /// </summary>
        public static CreateResult Create(this IZooKeeperClient client, [NotNull] string path, CreateMode createMode, [CanBeNull] byte[] data = null) =>
            client.Create(new CreateRequest(path, createMode) {Data = data});

        /// <inheritdoc cref="IZooKeeperClient.DeleteAsync"/>
        public static DeleteResult Delete(this IZooKeeperClient client, DeleteRequest request) =>
            client.DeleteAsync(request).GetAwaiter().GetResult();

        /// <inheritdoc cref="IZooKeeperClient.SetDataAsync"/>
        public static SetDataResult SetData(this IZooKeeperClient client, SetDataRequest request) =>
            client.SetDataAsync(request).GetAwaiter().GetResult();

        /// <summary>
        /// Sets the given <paramref name="data"/> for the node using given <paramref name="path"/>.
        /// </summary>
        public static async Task<SetDataResult> SetDataAsync(this IZooKeeperClient client, [NotNull] string path, [CanBeNull] byte[] data) =>
            await client.SetDataAsync(new SetDataRequest(path, data)).ConfigureAwait(false);

        /// <summary>
        /// Sets the given <paramref name="data"/> for the node using given <paramref name="path"/>.
        /// </summary>
        public static SetDataResult SetData(this IZooKeeperClient client, [NotNull] string path, [CanBeNull] byte[] data) =>
            client.SetData(new SetDataRequest(path, data));

        /// <inheritdoc cref="IZooKeeperClient.ExistsAsync"/>
        public static ExistsResult Exists(this IZooKeeperClient client, ExistsRequest request) =>
            client.ExistsAsync(request).GetAwaiter().GetResult();

        /// <inheritdoc cref="IZooKeeperClient.GetChildrenAsync"/>
        public static GetChildrenResult GetChildren(this IZooKeeperClient client, GetChildrenRequest request) =>
            client.GetChildrenAsync(request).GetAwaiter().GetResult();

        /// <inheritdoc cref="IZooKeeperClient.GetDataAsync"/>
        public static GetDataResult GetData(this IZooKeeperClient client, GetDataRequest request) =>
            client.GetDataAsync(request).GetAwaiter().GetResult();
    }
}