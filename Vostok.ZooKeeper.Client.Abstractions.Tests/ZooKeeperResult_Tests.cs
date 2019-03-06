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
            new Action(
                    () =>
                    {
                        var value = new TestResult(ZooKeeperStatus.Ok, "path", 42).Value;
                    }).Should()
                .NotThrow<ZooKeeperException>();
        }

        [Test]
        public void Payload_should_throw_on_unsuccessful_result()
        {
            new Action(
                    () =>
                    {
                        var value = new TestResult(ZooKeeperStatus.BadArguments, "path", 42).Value;
                    }).Should()
                .Throw<ZooKeeperException>();
        }

        [TestCase(ZooKeeperStatus.Ok, true)]
        [TestCase(ZooKeeperStatus.NodeNotFound, true)]
        [TestCase(ZooKeeperStatus.BadArguments, false)]
        [TestCase(ZooKeeperStatus.ConnectionLoss, false)]
        public void DeleteResult_NodeNotFound_should_be_successful(ZooKeeperStatus status, bool isSuccessfulStatus)
        {
            DeleteResult.Unsuccessful(status, "path", null).IsSuccessful.Should().Be(isSuccessfulStatus);
        }

        [TestCase(ZooKeeperStatus.Ok, true)]
        [TestCase(ZooKeeperStatus.NodeNotFound, false)]
        [TestCase(ZooKeeperStatus.BadArguments, false)]
        [TestCase(ZooKeeperStatus.ConnectionLoss, false)]
        public void TestResult_NodeNotFound_should_not_be_successful(ZooKeeperStatus status, bool isSuccessfulStatus)
        {
            new TestResult(status, "path", 42).IsSuccessful.Should().Be(isSuccessfulStatus);
        }

        private class TestResult : ZooKeeperResult<int>
        {
            public TestResult(ZooKeeperStatus status, string path, int payload)
                : base(status, path, payload)
            {
            }

            public int Value => Payload;
        }
    }
}