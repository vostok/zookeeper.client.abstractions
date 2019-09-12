using FluentAssertions;
using NUnit.Framework;
using Vostok.ZooKeeper.Client.Abstractions.Model;

namespace Vostok.ZooKeeper.Client.Abstractions.Tests
{
    [TestFixture]
    public class ConnectionStateExtensions_Tests
    {
        [TestCase(ConnectionState.Connected, false, true)]
        [TestCase(ConnectionState.Connected, true, true)]
        [TestCase(ConnectionState.ConnectedReadonly, false, false)]
        [TestCase(ConnectionState.ConnectedReadonly, true, true)]
        [TestCase(ConnectionState.Disconnected, false, false)]
        [TestCase(ConnectionState.Disconnected, true, false)]
        [TestCase(ConnectionState.Expired, false, false)]
        [TestCase(ConnectionState.Expired, true, false)]
        public void IsConnected_should_be_connected(ConnectionState state, bool canBeReadOnly, bool expected)
        {
            state.IsConnected(canBeReadOnly).Should().Be(expected);
        }
    }
}