using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private PlayerResources PlayerResources;

	private void Start()
	{
		PlayerResources.Gold = PlayerResources.StartingGold.Value;
	}

	public void PayBuildingCost(Building building)
	{
		PlayerResources.Gold -= building.GetCost();
	}

	public void ReturnBuildingCost(Building building)
	{
		PlayerResources.Gold += building.GetCost();
	}
}