using System;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    public class AnonymousWatcher : INodeWatcher
    {
        private readonly Action<NodeChangedEventType, string> processingDelegate;

        public AnonymousWatcher(Action<NodeChangedEventType, string> processingDelegate)
        {
            this.processingDelegate = processingDelegate;
        }

        public void ProcessEvent(NodeChangedEventType type, string path)
        {
            processingDelegate(type, path);
        }
    }
}