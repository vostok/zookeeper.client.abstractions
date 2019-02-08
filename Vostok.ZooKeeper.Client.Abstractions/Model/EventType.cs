namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    // CR(iloktionov): Rename to WatchedEventType?

    public enum EventType
    {
        NodeCreated = 1,
        NodeDeleted = 2,
        NodeDataChanged = 3,
        NodeChildrenChanged = 4,
    }
}