using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CustomLineRenderer : MonoBehaviour {

    public int TotalSegments = 32;

    public Vector2 StartPoint = Vector2.zero;
    public Vector2 EndPoint = Vector2.zero;

    LineRenderer line;

    void Start ()
    {
        line = GetComponent<LineRenderer>();
    
        line.positionCount = TotalSegments;
        for(int i = 0; i < line.positionCount; i++)
        {
            line.SetPosition(i, Vector3.zero);
        }
	}

    private void Update()
    {
        OnUpdatePath();
    }

    void OnUpdatePath()
    {
        for(int i = 0; i < line.positionCount; i++)
        {
            float t = i / (float)TotalSegments;

            float xPos = Mathf.SmoothStep(StartPoint.x, EndPoint.x, t);
            float yPos = Mathf.Lerp(StartPoint.y, EndPoint.y, t);
            Vector2 newPos = new Vector2(xPos, yPos);
            line.SetPosition(i, new Vector3(newPos.x, newPos.y, 0));
        }
    }
}
