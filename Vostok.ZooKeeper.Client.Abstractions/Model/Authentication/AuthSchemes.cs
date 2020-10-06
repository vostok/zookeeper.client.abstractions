﻿using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Authentication
{
    /// <summary>
    /// Authentication schemes.
    /// </summary>
    [PublicAPI]
    public static class AuthSchemes
    {
        /// <summary>
        /// Plaintext login and password authentication. Requires "login:password" Data
        /// </summary>
        public const string Digest = "digest";
    }
}