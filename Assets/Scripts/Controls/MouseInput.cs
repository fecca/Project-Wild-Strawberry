using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour
{
	[SerializeField]
	private LayerMask LayerMask;
	[SerializeField]
	private BuildingVariable ActiveBuilding;

	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject()) { return; }

		if (Input.GetMouseButtonUp(0))
		{
			int layerMask = (1 << LayerMask.NameToLayer("Ground"));
			layerMask |= (1 << LayerMask.NameToLayer("Building"));
			layerMask |= (1 << LayerMask.NameToLayer("Unit"));

			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, LayerMask))
			{
				var entity = hit.collider.GetComponent<Entity>();
				EventManager.TriggerEvent(EntityEventType.Click, entity);

				//var interactable = hit.collider.GetComponent<IInteractable>();
				//if (interactable != null)
				//{
				//	interactable.Click();
				//}
				//else
				//if (LayerMask.LayerToName(hit.collider.gameObject.layer).Equals("Ground"))
				//{
				//	EventManager.TriggerEvent(BuildingEventType.Select, null);
				//}
			}
		}
	}
}
