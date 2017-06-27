using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compute.Nodes.Builders
{
    class NodeConnectionBuilder<T> where T : ConnectedNode
    {
        NodeConnection<T> currentNode;

        public NodeConnectionBuilder()
        {
            currentNode = new NodeConnection<T>(null, null, null);
        }

        public NodeConnection<T> Build()
        {
            return currentNode;
        }

        public NodeConnectionBuilder<T> SetConnectionLine(CustomLineRenderer connectionLine)
        {
            currentNode.ConnectedLine = connectionLine;
            return this;
        }

        public NodeConnectionBuilder<T> SetNodes(T node1, T node2)
        {
            if(node1.IsInputNode != node2.IsInputNode)
            {
                if(node1.IsInputNode)
                {
                    currentNode.InputNode = node1;
                    currentNode.OutputNode = node2;
                }
                else
                {
                    currentNode.OutputNode = node1;
                    currentNode.InputNode = node2;
                }
            }
            return this;
        }

        public NodeConnectionBuilder<T> SetInputNode(T inputNode)
        {
            currentNode.InputNode = inputNode;
            return this;
        }

        public NodeConnectionBuilder<T> SetOutputNode(T outputNode)
        {
            currentNode.OutputNode = outputNode;
            return this;
        }
    }
}
