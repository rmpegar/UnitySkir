﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class WorldInteraction : MonoBehaviour {
	NavMeshAgent playerAgent;

	void Start(){
		playerAgent = GetComponent<NavMeshAgent>();
	}

	void Update(){
		if(Input.GetMouseButtonDown(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			GetInteraction();
	}

	void GetInteraction()
	{

		Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit interactionInfo;
		if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
			GameObject interactedObject = interactionInfo.collider.gameObject;
			if(interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
			}
			else
            {
                playerAgent.stoppingDistance = 0f;
				playerAgent.destination = interactionInfo.point;
			}
		}
	}
}