﻿using System.Collections;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	[Header("Buildings")]
	[SerializeField]
	protected BuildingVariable ActiveBuilding;
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
		ActiveBuilding.Value = Instantiate(building);
		EventManager.TriggerEvent(BuildingEventType.Purchase, building);
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
			EventManager.TriggerEvent(StringEventType.ErrorMessage, $"Another building is already active");
			return;
		}

		if (PlayerResources.Gold >= building.Cost)
		{
			InstantiateBuilding(building);
		}
		else
		{
			EventManager.TriggerEvent(StringEventType.ErrorMessage, $"Not enough resources");
		}
	}

	public void OnBuildingCancelled(Building building)
	{
		ActiveBuilding.Value = null;
		Destroy(building.gameObject);
	}

	public void OnBuildingConstructionStarted(Building building)
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
}