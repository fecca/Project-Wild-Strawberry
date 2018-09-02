using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
	[SerializeField]
	private PlayerResources PlayerResources;

	private List<Unit> m_units = new List<Unit>();

	public void OnUnitButtonPressed(Unit unit)
	{
		if (PlayerResources.Gold >= unit.Cost)
		{
			EventManager.TriggerEvent(UnitEventType.TrainUnit, unit);
		}
		else
		{
			EventManager.TriggerEvent(StringEventType.ErrorMessage, $"Not enough resources");
		}
	}

	public void OnUnitTrained(Unit unit)
	{
		m_units.Add(unit);
	}
}
