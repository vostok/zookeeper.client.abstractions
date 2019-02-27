using System;
using FluentAssertions;
using NUnit.Framework;
using Vostok.ZooKeeper.Client.Abstractions.Model;
using Vostok.ZooKeeper.Client.Abstractions.Model.Result;

namespace Vostok.ZooKeeper.Client.Abstractions.Tests
{
    [TestFixture]
    internal class ZooKeeperResult_Tests
    {
        [Test]
        public void Payload_should_not_throw_on_successful_result()
        {
            new Action(() =>
            {
                var value = new TestResult(ZooKeeperStatus.Ok, "path", 42).Value;
            }).Should().NotThrow<ZooKeeperException>();
        }

        [Test]
        public void Payload_should_throw_on_unsuccessful_result()
        {
            new Action(() =>
            {
                var value = new TestResult(ZooKeeperStatus.BadArguments, "path", 42).Value;
            }).Should().Throw<ZooKeeperException>();
        }

        private class TestResult : ZooKeeperResult<int>
        {
            public int Value => Payload;

            public TestResult(ZooKeeperStatus status, string path, int payload)
                : base(status, path, payload)
            {
            }
        }
    }
}