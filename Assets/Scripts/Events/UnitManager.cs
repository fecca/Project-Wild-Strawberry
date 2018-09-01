using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
	private List<Unit> m_units = new List<Unit>();

	public void OnUnitTrained(Unit unit)
	{
		m_units.Add(unit);
	}
}
