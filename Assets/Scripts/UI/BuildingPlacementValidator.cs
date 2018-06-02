using UnityEngine;

public class BuildingPlacementValidator : MonoBehaviour
{
	public bool Validate(BuildingGridBounds buildingGridBounds)
	{
		return buildingGridBounds.Collisions == 0;
	}
}