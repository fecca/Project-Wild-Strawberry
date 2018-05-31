using UnityEngine;

public class BuildingButtonValidator : ButtonValidator
{
	[SerializeField]
	private BuildingVariable ActiveBuilding;

	public override bool Validate()
	{
		return ActiveBuilding.Value == null || ActiveBuilding.Value.GetState() != BuildingState.Placing;
	}
}