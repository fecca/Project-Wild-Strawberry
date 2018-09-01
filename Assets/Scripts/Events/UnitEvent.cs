using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnitEvent : ScriptableObject
{
	private List<UnitEventListener> Listeners = new List<UnitEventListener>();

	public void Raise(Unit unit)
	{
		Debug.Log($"Raising event: {this}");
		for (int i = Listeners.Count - 1; i >= 0; i--)
		{
			Listeners[i].OnEventRaised(unit);
		}
	}

	public void RegisterListener(UnitEventListener listener)
	{
		Listeners.Add(listener);
	}

	public void UnregisterListener(UnitEventListener listener)
	{
		Listeners.Remove(listener);
	}
}