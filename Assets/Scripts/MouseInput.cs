using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour
{
	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject()) { return; }

		var mouseLeft = Input.GetMouseButtonUp(0);
		var mouseRight = Input.GetMouseButtonUp(1);
		var mouseMiddle = Input.GetMouseButtonUp(2);

		if (!mouseLeft && !mouseRight && !mouseMiddle) { return; }

		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, 1 << LayerMask.NameToLayer("Building")))
		{
			var building = hit.collider.GetComponent<Building>();
			if (building != null)
			{
				var mouseButton = mouseLeft ? MouseButtonType.Left : mouseRight ? MouseButtonType.Right : MouseButtonType.Middle;
				building.Interact(mouseButton);
			}
		}
	}
}
