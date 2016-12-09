using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public bool selected = false;
	
	// Update is called once per frame
	void Update () {
        /*
		if (GetComponent<Renderer>().isVisible && Input.GetMouseButtonUp(0))
        {
            Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
            camPos.y = CameraOperator.ScreenToRectTransform(camPos.y);
            selected = CameraOperator.selection.Contains(camPos);
        }

        if (selected)
            GetComponent<Renderer>().material.color = Color.red;
        else
            GetComponent<Renderer>().material.color = Color.white;
        */
	}
}
