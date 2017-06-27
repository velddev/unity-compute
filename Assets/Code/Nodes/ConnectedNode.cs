using Compute.Nodes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedNode : Node
{
    public bool IsInputNode = false;

    public List<NodeConnection<ConnectedNode>> ConnectedNodes = new List<NodeConnection<ConnectedNode>>();

    public FunctionNode ParentNode;

    protected CustomLineRenderer currentDraggingLine;
    protected GameObject currentGameObject;

    protected override void Start()
    {
        base.Start();
        ParentNode = transform.parent.GetComponent<FunctionNode>();
    }

    protected override void OnDragStart()
    {
        GameObject g = new GameObject("newLine");

        LineRenderer cLineRenderer = g.AddComponent<LineRenderer>();
        cLineRenderer.material = Resources.Load("LineMaterial", typeof(Material)) as Material;
        cLineRenderer.startWidth = 0.01f;
        cLineRenderer.endWidth = 0.01f;

        currentDraggingLine = g.AddComponent<CustomLineRenderer>();
        currentDraggingLine.StartPoint = transform.position;

        currentGameObject = g;
    }
    protected override void OnDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        currentDraggingLine.EndPoint = mousePosition;
    }
    protected override void OnDragFinish()
    {
        ConnectedNode node = (SelectionManager.Instance.HoverNode as ConnectedNode);

        if (node)
        {
            if(node != this)
            {
                currentDraggingLine.EndPoint = node.transform.position;
                currentDraggingLine = null;
                return;
            }
        }
        Destroy(currentGameObject);
        currentDraggingLine = null;
    }

    public void UpdateLines()
    {
        ConnectedNodes.ForEach(x => x.UpdateLine());
    }
}
