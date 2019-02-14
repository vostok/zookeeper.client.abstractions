namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    // CR(iloktionov): Rename to WatchedEventType?

    public enum NodeChangedEventType
    {
        NodeCreated = 1,
        NodeDeleted = 2,
        NodeDataChanged = 3,
        NodeChildrenChanged = 4,
    }
}