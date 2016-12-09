using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOperator : MonoBehaviour
{
    public Texture2D selectionHighlight = null;
    public static Rect selection = new Rect(0, 0, 0, 0); //Creating the selection area
    private Vector3 startClick = -Vector3.one; // Where the Square starts to draw (nowhere at first)

	
	// Update is called once per frame
	void Update () {
        checkCamera();
    }

    private void checkCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (selection.width<0)
            {
                selection.x += selection.width;
                selection.width = -selection.width;

            }
            if (selection.height<0)
            {
                selection.y += selection.height;
                selection.height = -selection.height;
            }
            startClick = -Vector3.one;
        }

        if (Input.GetMouseButton(0))
        {
            selection = new Rect(startClick.x, ScreenToRectTransform(startClick.y),
                Input.mousePosition.x - startClick.x,
                ScreenToRectTransform(Input.mousePosition.y) - ScreenToRectTransform(startClick.y));
        }
    }

    public void OnGui()
    {
        if (startClick != -Vector3.one)
        {
            GUI.color = new Color(1, 1, 1, 0.5f); // R,G,B, Transparency 0-1
            GUI.DrawTexture(selection, selectionHighlight);
        }
    }

    // Rect starts at top left and screen starts at bottom left. This function makes screen start from top left
    public static float ScreenToRectTransform(float y)
    {
        return Screen.height - y;
    }
}
