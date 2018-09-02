using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	private void Awake()
	{
		SetupBuildingEvents();
		SetupUnitEvents();
		SetupEntityEvents();
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
		m_buildingEvents.Add(BuildingEventType.ButtonPress, OnBuildingButtonPressed);
		m_buildingEvents.Add(BuildingEventType.Purchase, OnBuildingPurchased);
		m_buildingEvents.Add(BuildingEventType.Construct, OnBuildingPlaced);
		m_buildingEvents.Add(BuildingEventType.Cancel, OnBuildingCancelled);
		m_buildingEvents.Add(BuildingEventType.Constructed, OnBuildingConstructed);
		m_buildingEvents.Add(BuildingEventType.Select, OnBuildingSelected);
	}

	public static void TriggerEvent(BuildingEventType type, Building building)
	{
		m_buildingEvents[type].Raise(building);
	}

	#endregion

	#region UNIT EVENTS

	[SerializeField]
	private UnitEvent OnUnitButtonPressed;
	[SerializeField]
	private UnitEvent OnUnitTrained;

	private static Dictionary<UnitEventType, UnitEvent> m_unitEvents = new Dictionary<UnitEventType, UnitEvent>();

	private void SetupUnitEvents()
	{
		m_unitEvents.Add(UnitEventType.ButtonPress, OnUnitButtonPressed);
		m_unitEvents.Add(UnitEventType.UnitTrained, OnUnitTrained);
	}

	public static void TriggerEvent(UnitEventType type, Unit unit)
	{
		m_unitEvents[type].Raise(unit);
	}

	#endregion

	#region ENTITY EVENTS

	[SerializeField]
	private EntityEvent OnEntityClicked;

	private static Dictionary<EntityEventType, EntityEvent> m_entityEvents = new Dictionary<EntityEventType, EntityEvent>();

	private void SetupEntityEvents()
	{
		m_entityEvents.Add(EntityEventType.Click, OnEntityClicked);
	}

	public static void TriggerEvent(EntityEventType type, Entity entity)
	{
		m_entityEvents[type].Raise(entity);
	}

	#endregion

	#region STRING EVENTS

	[SerializeField]
	private StringEvent OnErrorMessage;

	private static Dictionary<StringEventType, StringEvent> m_stringEvents = new Dictionary<StringEventType, StringEvent>();

	private void SetupStringEvents()
	{
		m_stringEvents.Add(StringEventType.ErrorMessage, OnErrorMessage);
	}

	public static void TriggerEvent(StringEventType type, string message)
	{
		m_stringEvents[type].Raise(message);
	}

	#endregion
}