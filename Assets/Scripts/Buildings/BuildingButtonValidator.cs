using UnityEngine;

public class BuildingButtonValidator : MonoBehaviour
{
	[SerializeField]
	private BuildingVariable ActiveBuilding;

	public bool Validate()
	{
		return ActiveBuilding.Value == null || ActiveBuilding.Value.GetState() != BuildingState.Placing;
	}
}