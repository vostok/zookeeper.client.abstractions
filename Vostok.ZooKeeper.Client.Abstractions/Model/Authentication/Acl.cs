using System;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Authentication
{
    /// <summary>
    /// Represents access control list.
    /// </summary>
    [PublicAPI]
    public class Acl
    {
        /// <summary>
        /// Represents completely open ACL
        /// </summary>
        public static Acl OpenUnsafe = new Acl(Permissions.All, Id.Anyone);

        /// <summary>
        /// This ACL gives the creators authentication id's all permissions.
        /// </summary>
        public static Acl CreatorAll = new Acl(Permissions.All, Id.Auth);

        /// <summary>
        /// This ACL gives the world the ability to read.
        /// </summary>
        public static Acl ReadUnsafe = new Acl(Permissions.Read, Id.Anyone);

        /// <summary>
        /// <para>Generates Digest ACL for given <paramref name="login"/> and <paramref name="plainTextPassword"/>.</para>
        /// </summary>
        public static Acl Digest(Permissions permissions, string login, string plainTextPassword)
        {
            using (var sha = new SHA1Managed())
            {
                var loginPasswordString = $"{login}:{plainTextPassword}";
                var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(loginPasswordString));
                var digest = Convert.ToBase64String(hash);
                var id = new Id(AclSchemes.Digest, $"{login}:{digest}");
                return new Acl(permissions, id);
            }
        }

        public Acl(Permissions permissions, [NotNull] Id id)
        {
            Permissions = permissions;
            Id = id;
        }

        public Permissions Permissions { get; }

        [NotNull]
        public Id Id { get; }

        public override string ToString() => $"{Id}:{(int)Permissions}";
    }
}