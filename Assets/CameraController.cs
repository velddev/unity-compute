using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public int ZoomLevel = 1;
    public int MaxZoomLevel = 12;
    public int MinZoomLevel = 1;

    public float PanSensitivity = 0.01f;

    private bool isDragging = false;
    private Vector2 dragStartPosition;
    private Vector2 dragMousePosition;

	void Start ()
    {
		
	}
	
	void Update ()
    {
	    if(Input.GetMouseButton(2))
        {
            if(!isDragging)
            {
                isDragging = true;
                dragStartPosition = transform.position;
                dragMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            Vector2 panOffset = dragMousePosition - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.Translate(new Vector3(panOffset.x * PanSensitivity, panOffset.y * PanSensitivity, 0));
            dragMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            isDragging = false;
        }

        float d = Input.GetAxis("Mouse ScrollWheel");

        if (d < 0)
        {
            ZoomLevel++;
            if(ZoomLevel > MaxZoomLevel)
            {
                ZoomLevel = MaxZoomLevel;
            }
            Camera.main.orthographicSize = ZoomLevel;
        }
        else if(d > 0)
        {
            ZoomLevel--;
            if (ZoomLevel < MinZoomLevel)
            {
                ZoomLevel = MinZoomLevel;
            }
            Camera.main.orthographicSize = ZoomLevel;

        }
    }
}
