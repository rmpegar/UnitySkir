using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
    public GameObject selectedObject;
    // Use this for initialization
    void Start () {
		
	}
	/*
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.transform.root.gameObject;

            SelectObject(hitObject);
        }
        else
        {
            ClearSelection();
        }
	}

    public void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)
                return;
        }
        

        selectedObject = obj;
        //Grab all renderers components in a unit
        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in rs)
        {
            Material m = ren.material;
            m.color = Color.green;
            ren.material = m;
        }
    }

    public void ClearSelection()
    {
        if (selectedObject == null)
            return;
        //Grab all renderers components in a unit
        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in rs)
        {
            Material m = ren.material;
            m.color = Color.white;
            ren.material = m;
        }
        selectedObject = null;
    }*/
}
