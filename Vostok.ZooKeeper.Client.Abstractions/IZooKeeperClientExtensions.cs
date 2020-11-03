using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Vostok.Commons.Binary;
using Vostok.ZooKeeper.Client.Abstractions.Model;
using Vostok.ZooKeeper.Client.Abstractions.Model.Authentication;
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

        /// <inheritdoc cref="IZooKeeperClient.CreateAsync"/>
        public static async Task<CreateResult> CreateAsync(this IZooKeeperClient client, [NotNull] string path, CreateMode createMode, [CanBeNull] byte[] data = null) =>
            await client.CreateAsync(new CreateRequest(path, createMode) {Data = data}).ConfigureAwait(false);

        /// <inheritdoc cref="IZooKeeperClient.CreateAsync"/>
        public static CreateResult Create(this IZooKeeperClient client, [NotNull] string path, CreateMode createMode, [CanBeNull] byte[] data = null) =>
            client.Create(new CreateRequest(path, createMode) {Data = data});

        /// <inheritdoc cref="IZooKeeperClient.DeleteAsync"/>
        public static DeleteResult Delete(this IZooKeeperClient client, DeleteRequest request) =>
            client.DeleteAsync(request).GetAwaiter().GetResult();

        /// <inheritdoc cref="IZooKeeperClient.SetDataAsync"/>
        public static SetDataResult SetData(this IZooKeeperClient client, SetDataRequest request) =>
            client.SetDataAsync(request).GetAwaiter().GetResult();

        /// <inheritdoc cref="IZooKeeperClient.SetDataAsync"/>
        public static async Task<SetDataResult> SetDataAsync(this IZooKeeperClient client, [NotNull] string path, [CanBeNull] byte[] data) =>
            await client.SetDataAsync(new SetDataRequest(path, data)).ConfigureAwait(false);

        /// <inheritdoc cref="IZooKeeperClient.SetDataAsync"/>
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

        ///<inheritdoc cref="UpdateDataAsync(IZooKeeperClient, UpdateDataRequest)"/>
        public static UpdateDataResult UpdateData(this IZooKeeperClient zooKeeperClient, UpdateDataRequest request) =>
            zooKeeperClient.UpdateDataAsync(request).GetAwaiter().GetResult();

        ///<inheritdoc cref="UpdateDataAsync(IZooKeeperClient, UpdateDataRequest)"/>
        public static UpdateDataResult UpdateData(this IZooKeeperClient zooKeeperClient, [NotNull] string path, [NotNull] Func<byte[], byte[]> update) =>
            zooKeeperClient.UpdateData(new UpdateDataRequest(path, update));

        ///<inheritdoc cref="UpdateDataAsync(IZooKeeperClient, UpdateDataRequest)"/>
        public static Task<UpdateDataResult> UpdateDataAsync(this IZooKeeperClient zooKeeperClient, [NotNull] string path, [NotNull] Func<byte[], byte[]> update) =>
            zooKeeperClient.UpdateDataAsync(new UpdateDataRequest(path, update));

        /// <summary>
        /// <para>Trying to update node data with optimistic concurrency strategy according to given <paramref name="request"/>.</para>
        /// <para>Check returned <see cref="UpdateDataResult"/> to see if operation was successful.</para>
        /// </summary>
        public static async Task<UpdateDataResult> UpdateDataAsync(this IZooKeeperClient zooKeeperClient, UpdateDataRequest request)
        {
            try
            {
                for (var i = 0; i < request.Attempts; i++)
                {
                    var readResult = await zooKeeperClient.GetDataAsync(new GetDataRequest(request.Path)).ConfigureAwait(false);
                    if (!readResult.IsSuccessful)
                        return UpdateDataResult.Unsuccessful(readResult.Status, readResult.Path, readResult.Exception);

                    var newData = request.Update(readResult.Data);
                    
                    if (ByteArrayKey.Equals(readResult.Data, newData))
                        return UpdateDataResult.Successful(readResult.Path);

                    var setDataRequest = new SetDataRequest(request.Path, newData)
                    {
                        Version = readResult.Stat.Version
                    };

                    var updateResult = await zooKeeperClient.SetDataAsync(setDataRequest).ConfigureAwait(false);

                    if (updateResult.Status == ZooKeeperStatus.VersionsMismatch)
                        continue;

                    return updateResult.IsSuccessful ? UpdateDataResult.Successful(updateResult.Path) : UpdateDataResult.Unsuccessful(updateResult.Status, updateResult.Path, updateResult.Exception);
                }

                return UpdateDataResult.Unsuccessful(ZooKeeperStatus.VersionsMismatch, request.Path, null);
            }
            catch (Exception e)
            {
                return UpdateDataResult.Unsuccessful(ZooKeeperStatus.UnknownError, request.Path, e);
            }
        }

        /// <inheritdoc cref="IZooKeeperAuthClient.GetAclAsync"/>
        public static GetAclResult GetAcl(this IZooKeeperClient client, GetAclRequest request) =>
            client.AsAuthZooKeeperClient().GetAclAsync(request).GetAwaiter().GetResult();

        /// <inheritdoc cref="IZooKeeperAuthClient.GetAclAsync"/>
        public static Task<GetAclResult> GetAclAsync(this IZooKeeperClient client, GetAclRequest request) =>
            client.AsAuthZooKeeperClient().GetAclAsync(request);

        /// <inheritdoc cref="IZooKeeperAuthClient.GetAclAsync"/>
        public static GetAclResult GetAcl(this IZooKeeperClient client, [NotNull] string path) =>
            client.AsAuthZooKeeperClient().GetAclAsync(new GetAclRequest(path)).GetAwaiter().GetResult();

        /// <inheritdoc cref="IZooKeeperAuthClient.GetAclAsync"/>
        public static Task<GetAclResult> GetAclAsync(this IZooKeeperClient client, [NotNull] string path) =>
            client.AsAuthZooKeeperClient().GetAclAsync(new GetAclRequest(path));

        /// <inheritdoc cref="IZooKeeperAuthClient.SetAclAsync"/>
        public static SetAclResult SetAcl(this IZooKeeperClient client, SetAclRequest request) =>
            client.AsAuthZooKeeperClient().SetAclAsync(request).GetAwaiter().GetResult();

        /// <inheritdoc cref="IZooKeeperAuthClient.SetAclAsync"/>
        public static Task<SetAclResult> SetAclAsync(this IZooKeeperClient client, SetAclRequest setAclRequest) =>
            client.AsAuthZooKeeperClient().SetAclAsync(setAclRequest);

        /// <inheritdoc cref="IZooKeeperAuthClient.SetAclAsync"/>
        public static SetAclResult SetAcl(this IZooKeeperClient client, [NotNull] string path, [NotNull] List<Acl> acls) =>
            client.SetAcl(new SetAclRequest(path, acls));

        /// <inheritdoc cref="IZooKeeperAuthClient.SetAclAsync"/>
        public static Task<SetAclResult> SetAclAsync(this IZooKeeperClient client, [NotNull] string path, [NotNull] List<Acl> acls) =>
            client.AsAuthZooKeeperClient().SetAclAsync(new SetAclRequest(path, acls));

        /// <inheritdoc cref="IZooKeeperAuthClient.AddAuthenticationInfo"/>
        public static void AddAuthenticationInfo(this IZooKeeperClient client, AuthenticationInfo authInfo) =>
            client.AsAuthZooKeeperClient().AddAuthenticationInfo(authInfo);

        /// <summary>
        /// <para>Authenticate using given <paramref name="login"/> and <paramref name="password"/> with <see cref="AclSchemes.Digest"/> scheme.</para>
        /// <para>The function can be called multiple times if the application wants to authenticate using different <paramref name="login"/> and <paramref name="password"/>.</para>>
        /// </summary>
        public static void AddAuthenticationInfo(this IZooKeeperClient client, [NotNull] string login, [NotNull] string password) =>
            client.AddAuthenticationInfo(AuthenticationInfo.Digest(login, password));
    }
}