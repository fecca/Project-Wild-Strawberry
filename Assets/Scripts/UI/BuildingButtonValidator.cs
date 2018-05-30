using UnityEngine;

public class BuildingButtonValidator : MonoBehaviour
{
	//[SerializeField]
	//private PlayerResources PlayerResources;
	[SerializeField]
	private BuildingVariable ActiveBuilding;

	public bool Valid()
	{
		return ActiveBuilding.Value == null;
	}
}
