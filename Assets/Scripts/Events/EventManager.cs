using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	private void Awake()
	{
		SetupBuildingEvents();
		SetupStringEvents();
	}

	#region BUILDING EVENTS

	[SerializeField]
	private BuildingEvent OnBuildingButtonPressed;
	[SerializeField]
	private BuildingEvent OnBuildingPurchased;
	[SerializeField]
	private BuildingEvent OnBuildingPlaced;
	[SerializeField]
	private BuildingEvent OnBuildingCancelled;
	[SerializeField]
	private BuildingEvent OnBuildingConstructed;
	[SerializeField]
	private BuildingEvent OnBuildingSelected;

	private static Dictionary<BuildingEventType, BuildingEvent> m_buildingEvents = new Dictionary<BuildingEventType, BuildingEvent>();

	private void SetupBuildingEvents()
	{
		m_buildingEvents.Add(BuildingEventType.ButtonPressed, OnBuildingButtonPressed);
		m_buildingEvents.Add(BuildingEventType.Purchased, OnBuildingPurchased);
		m_buildingEvents.Add(BuildingEventType.Placed, OnBuildingPlaced);
		m_buildingEvents.Add(BuildingEventType.Cancelled, OnBuildingCancelled);
		m_buildingEvents.Add(BuildingEventType.Constructed, OnBuildingConstructed);
		m_buildingEvents.Add(BuildingEventType.Selected, OnBuildingSelected);
	}

	public static void TriggerEvent(BuildingEventType type, Building building)
	{
		m_buildingEvents[type].Raise(building);
	}

	#endregion

	#region STRING EVENTS

	[SerializeField]
	private StringEvent OnBuildingPurchasedFailed;

	private static Dictionary<StringEventType, StringEvent> m_stringEvents = new Dictionary<StringEventType, StringEvent>();

	private void SetupStringEvents()
	{
		m_stringEvents.Add(StringEventType.BuildingPurchasedFailed, OnBuildingPurchasedFailed);
	}

	public static void TriggerEvent(StringEventType type, string message)
	{
		m_stringEvents[type].Raise(message);
	}

	#endregion
}