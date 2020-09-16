using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Well-known ACL schemes
    /// </summary>
    [PublicAPI]
    public static class AclSchemes
    {
        /// <summary>
        /// Scheme that has a single id, anyone, that represents anyone.
        /// </summary>
        public const string World = "world";

        /// <summary>
        /// Special scheme which ignores any provided expression and instead uses the current user, credentials, and scheme
        /// </summary>
        public const string Auth = "auth";

        /// <summary>
        /// Uses a username:password string to generate SHA1 hash which is then used as an ACL ID identity
        /// </summary>
        public const string Digest = "digest";

        /// <summary>
        /// Uses the client host IP as an ACL ID identity.
        /// </summary>
        public const string Ip = "ip";

        /// <summary>
        /// Uses the client X500 Principal as an ACL ID identity.
        /// </summary>
        public const string X509 = "x509";
    }
}