using UnityEngine;

public class BuildingButtonValidator : Validator
{
	//[SerializeField]
	//private PlayerResources PlayerResources;
	[SerializeField]
	private BuildingVariable ActiveBuilding;

	public override bool Valid()
	{
		return ActiveBuilding.Value == null;
	}
}