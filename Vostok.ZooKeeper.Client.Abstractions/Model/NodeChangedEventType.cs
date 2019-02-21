namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    public enum NodeChangedEventType
    {
        NodeCreated,
        NodeDeleted,
        NodeDataChanged,
        NodeChildrenChanged
    }
}