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

		if (Input.GetMouseButtonUp(0))
		{
			int layerMask = (1 << LayerMask.NameToLayer("Ground"));
			layerMask |= (1 << LayerMask.NameToLayer("Building"));

			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, layerMask))
			{
				if (ActiveBuilding.Value != null)
				{
					if (ActiveBuilding.Value.ValidatePlacement())
					{
						OnBuildingPlaced.Invoke(ActiveBuilding.Value);
					}
					else if (ActiveBuilding.Value.GetState() != BuildingState.Placing)
					{
						if (LayerMask.LayerToName(hit.collider.gameObject.layer).Equals("Ground"))
						{
							OnBuildingSelected.Invoke(null);
						}
					}
				}

				if (LayerMask.LayerToName(hit.collider.gameObject.layer).Equals("Building"))
				{
					var building = hit.collider.GetComponent<Building>();
					if (ActiveBuilding.Value == null)
					{
						OnBuildingSelected.Invoke(building);
					}
					else
					{
						if (ActiveBuilding.Value != building && ActiveBuilding.Value.GetState() != BuildingState.Placing)
						{
							OnBuildingSelected.Invoke(building);
						}
					}
				}
			}
		}
	}
}
