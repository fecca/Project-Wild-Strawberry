using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
	[SerializeField]
	private PlayerResources PlayerResources;

	private void Start()
	{
		PlayerResources.Gold = 100;
	}

	public void ConstructBuilding(Building building)
	{
		PlayerResources.Gold -= building.GetCost();
	}
}
