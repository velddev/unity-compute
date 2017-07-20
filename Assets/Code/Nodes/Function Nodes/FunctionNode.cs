using Assets.Code.Nodes.Builders;
using Compute.Nodes;
using Compute.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionNode : Node
{
    public string NodeName = "Function Node";

    public TextMesh NodeTextObject;

    public ExecuteNode execInNode;
    public ExecuteNode execOutNode;

    public List<ObjectDataNode> InputNodes = new List<ObjectDataNode>();
    public List<ObjectDataNode> OutputNodes = new List<ObjectDataNode>();

    public bool canRun;

	private Vector2 dragOffset;

    protected override void Start()
    {
        base.Start();



        execInNode = new ExecuteNodeBuilder(true)
            .AddToNode(transform, 0)
            .BuildAsExecuteNode();

        execOutNode = new ExecuteNodeBuilder(false)
            .AddToNode(transform, 0)
            .BuildAsExecuteNode();
    }

    private void Update()
    {
        RunInternal();
    }

	protected override void OnDragStart() {
		
		base.OnDragStart();

		Vector2 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		dragOffset = ( (Vector2)transform.position - mousePosition );

	}

	protected override void OnDrag()
    {
        if (SelectionManager.Instance.SelectedNode == this)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );

			transform.position = mousePosition + dragOffset;

            execInNode.UpdateLines();
            execOutNode.UpdateLines();

        }
    }

	public virtual void Run()
    {

    }

    public virtual void PostRun()
    {

    }

    public void RunInternal()
    {
        if (canRun)
        {
            spriteRenderer.color = Color.green;
            StartCoroutine(GoBackToWhite());

            canRun = false;

            try
            {
                Run();

                if(execOutNode != null)
                {
                    execOutNode.ConnectedNodes.ForEach(x =>
                    {
                        x.GetOther(execOutNode).ParentNode.canRun = true;
                    });
                }

                Debug.Log("ran '" + gameObject.name + "'");
            }
            catch(Exception e)
            {
                Debug.LogError("error @ '" + gameObject.name + "', message: " + e.Message + "\n" + e.StackTrace);
                spriteRenderer.color = Color.red;
            }
        }
    }

    IEnumerator GoBackToWhite()
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
