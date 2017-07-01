using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Nodes.Builders
{
    class ExecuteNodeBuilder
    {
        static Sprite executeNodeIcon;

        ExecuteNode node;
        GameObject thisObject;

        public ExecuteNodeBuilder(bool inputNode)
        {
            if(executeNodeIcon == null)
            {
                executeNodeIcon = Resources.Load<Sprite>("Nodes/execute-node");
            }

            string prefix = inputNode ? "In" : "Out";
            thisObject = new GameObject("exec" + prefix + "Node");

            SpriteRenderer execInSpriteRenderer = thisObject.AddComponent<SpriteRenderer>();
            execInSpriteRenderer.sprite = executeNodeIcon;
            execInSpriteRenderer.sortingOrder = 1;

            CircleCollider2D execInCircleCollider = thisObject.AddComponent<CircleCollider2D>();
            execInCircleCollider.radius = 0.04f;

            node = thisObject.AddComponent<ExecuteNode>();
            node.IsInputNode = inputNode;
        }

        public ExecuteNodeBuilder AddToNode(Transform t, int index)
        {
            thisObject.transform.parent = t;
            thisObject.transform.localPosition = new Vector3(node.IsInputNode ? -0.3f : 0.3f, 0.12f - (0.1f * index));
            return this;
        }
        public ExecuteNodeBuilder SetInputNode(bool isInputNode)
        {
            node.IsInputNode = isInputNode;
            return this;
        }

        public GameObject Build()
        {
            return thisObject;
        }
        public ExecuteNode BuildAsExecuteNode()
        {
            return node;
        }
    }
}
