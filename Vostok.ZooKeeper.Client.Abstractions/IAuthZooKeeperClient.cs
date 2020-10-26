using System.Threading.Tasks;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Authentication;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;
using Vostok.ZooKeeper.Client.Abstractions.Model.Result;

namespace Vostok.ZooKeeper.Client.Abstractions
{
    /// <summary>
    /// <para>Represents a client for ZooKeeper service with authentication.</para>
    /// <para>Client's operations:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="GetAclAsync"/></description></item>
    ///     <item><description><see cref="SetAclAsync"/></description></item>
    ///     <item><description><see cref="AddAuthenticationInfo"/></description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public interface IAuthZooKeeperClient
    {
        /// <summary>
        /// <para>Returns the ACLs and stat of the node specified in given <paramref name="request" />.</para>
        /// <para>Check returned <see cref="GetAclResult"/> to see if operation was successful.</para>
        /// </summary>
        [ItemNotNull]
        Task<GetAclResult> GetAclAsync([NotNull] GetAclRequest request);

        /// <summary>
        /// <para>Sets the ACL for the node specified in given <paramref name="request" />.</para>
        /// <para>Check returned <see cref="SetAclResult"/> to see if operation was successful.</para>
        /// </summary>
        [ItemNotNull]
        Task<SetAclResult> SetAclAsync([NotNull] SetAclRequest request);

        /// <summary>
        /// <para>Authenticate using given <paramref name="authenticationInfo"/>.</para>
        /// <para>The function can be called multiple times if the application wants to authenticate using different <paramref name="authenticationInfo"/>.</para>>
        /// </summary>
        void AddAuthenticationInfo([NotNull] AuthenticationInfo authenticationInfo);
    }
}