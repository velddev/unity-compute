using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compute.Nodes
{
    public class NodeConnection<T> where T : ConnectedNode
    {
        public T InputNode;
        public T OutputNode;

        public CustomLineRenderer ConnectedLine;

        public NodeConnection(T input, T output, CustomLineRenderer line)
        {
            InputNode = input;
            OutputNode = output;
            ConnectedLine = line;
        }

        public NodeConnection<X> Cast<X>() where X : ConnectedNode
        {
            return new NodeConnection<X>(InputNode as X, OutputNode as X, ConnectedLine);
        }

        public T GetOther(T me)
        {
            return (InputNode == me) ? OutputNode : InputNode;
        }

        public void UpdateLine()
        {
            ConnectedLine.StartPoint = InputNode.transform.position;
            ConnectedLine.EndPoint = OutputNode.transform.position;
        }
    }
}
