using Compute.Nodes;
using Compute.Nodes.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteNode : ConnectedNode
{
    protected override void OnDragFinish()
    {
        ExecuteNode hoveredNode = (SelectionManager.Instance.HoverNode as ExecuteNode);

        if (!hoveredNode)
        {
            Destroy(currentGameObject);
            currentDraggingLine = null;
            return;
        }

        if (hoveredNode != this)
        {
            if (hoveredNode.IsInputNode != IsInputNode)
            {
                NodeConnection<ExecuteNode> nodeConnection = new NodeConnectionBuilder<ExecuteNode>()
                    .SetNodes(this, hoveredNode)
                    .SetConnectionLine(currentDraggingLine)
                    .Build();

                ConnectedNodes.Add(nodeConnection.Cast<ConnectedNode>());
                hoveredNode.ConnectedNodes.Add(nodeConnection.Cast<ConnectedNode>());

                RegisterExecNodes(nodeConnection);

                nodeConnection.UpdateLine();

                currentGameObject = null;
                return;
            }
        }
        Destroy(currentGameObject);
        currentDraggingLine = null;
    }

    private void RegisterExecNodes(NodeConnection<ExecuteNode> node)
    {
        node.InputNode.ParentNode.execInNode = node.InputNode;
        node.OutputNode.ParentNode.execOutNode = node.OutputNode;
    }
}
