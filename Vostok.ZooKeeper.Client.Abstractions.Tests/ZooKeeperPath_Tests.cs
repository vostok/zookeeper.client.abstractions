using FluentAssertions;
using NUnit.Framework;

namespace Vostok.ZooKeeper.Client.Abstractions.Tests
{
    [TestFixture]
    internal class ZooKeeperPath_Tests
    {
        [TestCase("/aaaa", new[] {"aaaa"})]
        [TestCase("/aaaa/bbb", new[] {"aaaa", "bbb"})]
        [TestCase("/aaaa/bbb/", new[] {"aaaa", "bbb", ""})]
        [TestCase("/aaaa/bbb/c/d/e/f/long_123", new[] {"aaaa", "bbb", "c", "d", "e", "f", "long_123"})]
        public void Split_should_split_by_slashes(string path, string[] expected)
        {
            ZooKeeperPath.Split(path).Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }

        [TestCase(new[] {"aaaa"}, "/aaaa")]
        [TestCase(new[] {"aaaa", "bbb"}, "/aaaa/bbb")]
        [TestCase(new[] {"/aaaa/", "/bbb"}, "/aaaa/bbb")]
        [TestCase(new[] {"/aaaa/", "/bbb/"}, "/aaaa/bbb/")]
        [TestCase(new[] {"aaaa", "bbb", "c", "d", "e", "f", "long_123"}, "/aaaa/bbb/c/d/e/f/long_123")]
        public void Combine_should_combine_by_slashes(string[] segments, string expected)
        {
            ZooKeeperPath.Combine(segments).Should().Be(expected);
        }

        [TestCase("foo", "bar", "/foo/bar")]
        [TestCase("/foo", "bar", "/foo/bar")]
        [TestCase("/foo/", "bar", "/foo/bar")]
        [TestCase("/foo", "/bar", "/foo/bar")]
        [TestCase("/foo/", "/bar", "/foo/bar")]
        [TestCase("/foo/", "/bar/", "/foo/bar/")]
        public void Combine_should_work_correctly_for_two_arguments(string basePath, string relativePath, string expected)
        {
            ZooKeeperPath.Combine(basePath, relativePath).Should().Be(expected);
        }

        [TestCase("/aaaa")]
        [TestCase("/aaaa/")]
        [TestCase("/aaaa/bbb")]
        [TestCase("/aaaa/bbb/")]
        public void Split_followed_by_Combine_should_not_change_path(string path)
        {
            var expected = path;
            for (var i = 0; i < 10; i++)
            {
                path = ZooKeeperPath.Combine(ZooKeeperPath.Split(path));
            }

            path.Should().Be(expected);
        }

        [TestCase("/", null)]
        [TestCase("/foo", "/")]
        [TestCase("/foo/bar", "/foo")]
        [TestCase("/foo/bar/baz", "/foo/bar")]
        [TestCase("/foo/bar/baz/", "/foo/bar/baz")]
        public void GetParentPath_should_provide_correct_parent_paths(string path, string expectedParent)
        {
            ZooKeeperPath.GetParentPath(path).Should().Be(expectedParent);
        }
    }
}