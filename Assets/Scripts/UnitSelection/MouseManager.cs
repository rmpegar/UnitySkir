using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
    public GameObject hoveredObject;
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
            GameObject hitObject = hitInfo.transform.root.gameObject;
            if (hitObject.tag == "Interactable Object")
                SelectObject(hitObject);
                
            else
                ClearSelection();
        }
        else
        {
            ClearSelection();
        }
        
            selectedObject = hoveredObject;
	}

    public void SelectObject(GameObject obj)
    {
        if (hoveredObject != null)
        {
            if (obj == hoveredObject)
                return;
        }
        hoveredObject = obj;
        //Grab all renderers components in a unit
        Renderer[] rs = hoveredObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderedObject in rs)
        {
            Material m = renderedObject.material;
            m.color = Color.green;
            renderedObject.material = m;
        }
    }

    public void ClearSelection()
    {
        if (hoveredObject == null)
            return;
        //Grab all renderers components in a unit
        Renderer[] rs = hoveredObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderedObject in rs)
        {
            Material m = renderedObject.material;
            m.color = Color.white;
            renderedObject.material = m;
        }
        hoveredObject = null;
    }
}
