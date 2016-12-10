using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
    public GameObject selectedObject;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject hitObject = hitInfo.transform.root.gameObject;
                if (hitObject.tag == "Interactable Object")
                    SelectObject(hitObject);
                else
                    ClearSelection();
            }
        }


	}

    public void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)
                return;
            else
            {
                ClearSelection(); 
            }
        }

        selectedObject = obj;
        //Grab all renderers components in a unit
        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderedObject in rs)
        {
            Material m = renderedObject.material;
            m.color = Color.green;
            renderedObject.material = m;
        }
    }

    public void ClearSelection()
    {
        if (selectedObject == null)
            return;
        //Grab all renderers components in a unit
        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderedObject in rs)
        {
            Material m = renderedObject.material;
            m.color = Color.white;
            renderedObject.material = m;
        }
        selectedObject = null;
    }
}
