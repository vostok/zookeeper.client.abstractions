using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Authentication
{
    /// <summary>
    /// Represents an authentication identifier.
    /// </summary>
    [PublicAPI]
    public class AclId
    {
        /// <summary>
        /// This Id represents anyone.
        /// </summary>
        public static AclId Anyone = new AclId(AclSchemes.World, "anyone");

        /// <summary>
        /// This Id is only usable to set ACLs. It will get substituted with the
        /// Id's the client authenticated with.
        /// </summary>
        public static AclId Auth = new AclId(AclSchemes.Auth, string.Empty);

        public AclId([NotNull] string scheme, [NotNull] string identifier)
        {
            Scheme = scheme;
            Identifier = identifier;
        }

        [NotNull]
        public string Scheme { get; }

        [NotNull]
        public string Identifier { get; }

        public override string ToString() => $"{Scheme}:{Identifier}";
    }
}
