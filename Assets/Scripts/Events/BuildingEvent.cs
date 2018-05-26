using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BuildingEvent : ScriptableObject
{
	private List<BuildingEventListener> Listeners = new List<BuildingEventListener>();

	public void Raise(Building building)
	{
		for (int i = Listeners.Count - 1; i >= 0; i--)
		{
			Listeners[i].OnEventRaised(building);
		}
	}

	public void RegisterListener(BuildingEventListener listener)
	{
		Listeners.Add(listener);
	}

	public void UnregisterListener(BuildingEventListener listener)
	{
		Listeners.Remove(listener);
	}
}