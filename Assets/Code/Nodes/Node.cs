using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    protected bool isDragging { private set; get; }

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void OnLeftClick()
    {

    }

    protected virtual void OnDrag()
    {

    }

    protected virtual void OnDragStart()
    {

    }

    protected virtual void OnDragFinish()
    {

    }

    protected void OnMouseOver()
    {
        SelectionManager.Instance.HoverNode = this;
    }

    protected void OnMouseExit()
    {
        SelectionManager.Instance.HoverNode = null;
    }

    protected void OnMouseDown()
    {
        SelectionManager.Instance.SetSelectedNode(this);
    }

    protected void OnMouseUp()
    {
        if(isDragging)
        {
            OnDragFinish();
            isDragging = false;
        }
    }

    protected void OnMouseDrag()
    {
        if (!isDragging)
        {
            OnDragStart();
            isDragging = true;
        }
        OnDrag();
    }
}
