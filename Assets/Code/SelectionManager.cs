using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private static SelectionManager __instance = null;
    public static SelectionManager Instance
    {
        get
        {
            return __instance;
        }
    }

    public Node HoverNode = null;
    public Node SelectedNode = null;

    Material DefaultMaterial = null;
    Material OutlineMaterial = null;

    public void Start()
    {
        if(__instance == null)
        {
            __instance = this;
        }
        DefaultMaterial = Resources.Load("DefaultMaterial", typeof(Material)) as Material;
        OutlineMaterial = Resources.Load("OutlineMaterial", typeof(Material)) as Material;
    }

    public void SetSelectedNode(Node node)
    {
        if(SelectedNode != null)
        {
            SelectedNode.gameObject.GetComponent<SpriteRenderer>().material = DefaultMaterial;
        }
        node.gameObject.GetComponent<SpriteRenderer>().material = OutlineMaterial;
        SelectedNode = node;
    }
}
