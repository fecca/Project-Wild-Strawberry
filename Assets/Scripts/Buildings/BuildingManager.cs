using System.Collections;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	[Header("Buildings")]
	[SerializeField]
	private BuildingVariable ActiveBuilding;
	[SerializeField]
	private BuildingRuntimeSet ActiveBuildings;
	[SerializeField]
	private BuildingRuntimeSet BuildingsUnderConstruction;

	[Header("Resource management")]
	[SerializeField]
	private PlayerResources PlayerResources;
	[SerializeField]
	private FloatReference TickInterval;

	private void Start()
	{
		ActiveBuildings.Clear();
		BuildingsUnderConstruction.Clear();

		StartCoroutine(TickBuildings());
	}

	private void InstantiateBuilding(Building building)
	{
		SelectBuilding(null);
		ActiveBuilding.Value = Instantiate(building);
		EventManager.TriggerEvent(BuildingEventType.Purchase, building);
	}

	private void SelectBuilding(Building building)
	{
		if (ActiveBuilding.Value != null)
		{
			ActiveBuilding.Value.Select(false);
		}
		ActiveBuilding.Value = building;
		if (ActiveBuilding.Value != null)
		{
			ActiveBuilding.Value.Select(true);
		}
	}

	private IEnumerator TickBuildings()
	{
		while (true)
		{
			yield return new WaitForSeconds(TickInterval.Value);

			var totalValue = 0f;
			foreach (var building in ActiveBuildings.Items)
			{
				totalValue += building.TickValue;
			}

			PlayerResources.Gold += totalValue;
		}
	}

	public void OnBuildingButtonPressed(Building building)
	{
		if (ActiveBuilding.Value != null && ActiveBuilding.Value.GetState() == BuildingState.Placing)
		{
			EventManager.TriggerEvent(StringEventType.BuildingPurchasedFailed, $"Another building is already active");
			return;
		}

		if (PlayerResources.Gold >= building.Cost)
		{
			InstantiateBuilding(building);
		}
		else
		{
			EventManager.TriggerEvent(StringEventType.BuildingPurchasedFailed, $"Not enough resources");
		}
	}

	public void OnBuildingCancelled(Building building)
	{
		ActiveBuilding.Value = null;
		Destroy(building.gameObject);
	}

	public void OnBuildingPlaced(Building building)
	{
		building.Place();
		BuildingsUnderConstruction.Add(building);
		ActiveBuilding.Value = null;
	}

	public void OnBuildingConstructed(Building building)
	{
		BuildingsUnderConstruction.Remove(building);
		ActiveBuildings.Add(building);
	}

	public void OnBuildingSelected(Building building)
	{
		SelectBuilding(building);
	}
}