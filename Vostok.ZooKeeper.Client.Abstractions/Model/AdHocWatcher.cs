using System;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    public class AdHocWatcher : INodeWatcher
    {
        private readonly Action<NodeChangedEventType, string> processingDelegate;

        public AdHocWatcher(Action<NodeChangedEventType, string> processingDelegate)
        {
            this.processingDelegate = processingDelegate;
        }

        public void ProcessEvent(NodeChangedEventType type, string path)
        {
            processingDelegate(type, path);
        }
    }
}