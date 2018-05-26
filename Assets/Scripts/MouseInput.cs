﻿using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour
{
	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject()) { return; }

		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, 1 << LayerMask.NameToLayer("Building")))
			{
				var building = hit.collider.GetComponent<Building>();
				if (building != null)
				{
					building.Interact();
				}
			}
		}
	}
}
