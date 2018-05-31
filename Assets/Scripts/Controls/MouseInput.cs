using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour
{
	[SerializeField]
	private BuildingVariable ActiveBuilding;
	[SerializeField]
	private BuildingUnityEvent OnBuildingPlaced;
	[SerializeField]
	private BuildingUnityEvent OnBuildingSelected;

	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject()) { return; }

		RaycastHit hit;
		int layerMask = (1 << LayerMask.NameToLayer("Building"));
		layerMask |= (1 << LayerMask.NameToLayer("Ground"));
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, layerMask))
		{
			if (Input.GetMouseButtonUp(0))
			{
				/* Click ground
				 * 1. ActiveBuilding != null
				 *  1a. ActiveBuilding.State == Placing
				 *	 ? => ActiveBuilding.Place
				 *	 : => null.Select
				 */
				if (LayerMask.LayerToName(hit.collider.gameObject.layer).Equals("Ground"))
				{
					if (ActiveBuilding.Value != null)
					{
						if (ActiveBuilding.Value.GetState() == BuildingState.Placing)
						{
							OnBuildingPlaced.Invoke(ActiveBuilding.Value);
						}
						else
						{
							OnBuildingSelected.Invoke(null);
						}
					}
				}

				/* Click building
				 * 0. building = GetComponent<Building>
				 * 1. ActiveBuilding == null
				 *  => building.Select
				 * 2. ActiveBuilding != null
				 *  2a. ActiveBuilding.State != Placing && ActiveBuilding != building
				 *   => building.Select
				 */
				if (LayerMask.LayerToName(hit.collider.gameObject.layer).Equals("Building"))
				{
					var building = hit.collider.GetComponent<Building>();
					if (ActiveBuilding.Value == null)
					{
						OnBuildingSelected.Invoke(building);
					}
					else
					{
						if (ActiveBuilding.Value.GetState() != BuildingState.Placing && ActiveBuilding.Value != building)
						{
							OnBuildingSelected.Invoke(building);
						}
					}
				}
			}
		}
	}
}
