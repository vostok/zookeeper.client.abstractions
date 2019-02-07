namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    public enum EventType
    {
        NodeCreated = 1,
        NodeDeleted = 2,
        NodeDataChanged = 3,
        NodeChildrenChanged = 4,
    }
}