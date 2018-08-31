using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private PlayerResources PlayerResources;

	private void Start()
	{
		PlayerResources.Gold = PlayerResources.StartingGold.Value;
	}

	public void OnBuildingPurchased(Building building)
	{
		PlayerResources.Gold -= building.Cost();
	}

	public void OnBuildingCancelled(Building building)
	{
		PlayerResources.Gold += building.Cost();
	}
}