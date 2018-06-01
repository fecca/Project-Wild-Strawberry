using UnityEngine;

public class WorldGrid : MonoBehaviour
{
	[SerializeField]
	private BuildingVariable ActiveBuilding;
	[SerializeField]
	private FloatReference WorldSizeX;
	[SerializeField]
	private FloatReference WorldSizeZ;
	[SerializeField]
	private FloatReference GridSizeX;
	[SerializeField]
	private FloatReference GridSizeZ;


	private void Update()
	{
		if (ActiveBuilding.Value == null) { return; }
		if (ActiveBuilding.Value.GetState() != BuildingState.Placing) { return; }

		FollowMouse();
	}

	private void FollowMouse()
	{
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, 1 << LayerMask.NameToLayer("Ground")))
		{
			var position = hit.point;
			position.x = GridSizeX.Value > 0 ? (hit.point.x - (hit.point.x % GridSizeX.Value) - (GridSizeX.Value * 0.5f)) : hit.point.x;
			position.y = hit.point.y;
			position.z = GridSizeZ.Value > 0 ? (hit.point.z - (hit.point.z % GridSizeZ.Value) - (GridSizeZ.Value * 0.5f)) : hit.point.z;
			ActiveBuilding.Value.transform.position = position;
		}
	}
}
