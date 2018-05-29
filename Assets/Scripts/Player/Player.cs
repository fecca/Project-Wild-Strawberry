using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private PlayerResources PlayerResources;

	private void Start()
	{
		PlayerResources.Gold = PlayerResources.Gold;
	}

	public void SubtractBuildingCost(Building building)
	{
		PlayerResources.Gold -= building.GetCost();
	}

	public void AddBuildingCost(Building building)
	{
		PlayerResources.Gold += building.GetCost();
	}
}