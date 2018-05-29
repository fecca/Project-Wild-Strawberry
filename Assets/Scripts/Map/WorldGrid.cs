using UnityEngine;

public class WorldGrid : MonoBehaviour
{
	[SerializeField]
	private BuildingVariable ActiveBuilding;
	[SerializeField]
	private FloatReference WorldSizeX;
	[SerializeField]
	private FloatReference WorldSizeY;
	[SerializeField]
	private FloatReference GridSizeX;
	[SerializeField]
	private FloatReference GridSizeY;


	private void Update()
	{
		if (ActiveBuilding.Value == null || ActiveBuilding.Value.GetState() != BuildingState.Placing) { return; }

		FollowMouse();
	}

	private void FollowMouse()
	{
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, 1 << LayerMask.NameToLayer("Ground")))
		{
			ActiveBuilding.Value.transform.position = hit.point;
		}
	}

	//public void MoveBuilding(Building building)
	//{
	//	FollowMouse();
	//}
}
