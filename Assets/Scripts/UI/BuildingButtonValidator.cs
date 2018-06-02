using UnityEngine;

public class BuildingButtonValidator : Validator
{
	[SerializeField]
	private BuildingVariable ActiveBuilding;

	public override bool Validate()
	{
		return ActiveBuilding.Value == null || ActiveBuilding.Value.GetState() != BuildingState.Placing;
	}
}