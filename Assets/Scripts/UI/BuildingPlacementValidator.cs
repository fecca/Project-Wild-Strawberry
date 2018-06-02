using UnityEngine;

public class BuildingPlacementValidator : Validator
{
	[SerializeField]
	private BuildingGridBounds BuildingGridBounds;

	private void OnEnable()
	{
		BuildingGridBounds.CreateCollision();
	}

	public override bool Validate()
	{
		return BuildingGridBounds.Collisions == 0;
	}
}