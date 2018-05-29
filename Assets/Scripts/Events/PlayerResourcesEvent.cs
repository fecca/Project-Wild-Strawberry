using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerResourcesEvent : ScriptableObject
{
	private List<PlayerResourcesEventListener> Listeners = new List<PlayerResourcesEventListener>();

	public void Raise(PlayerResources playerResources)
	{
		for (int i = Listeners.Count - 1; i >= 0; i--)
		{
			Listeners[i].OnEventRaised(playerResources);
		}
	}

	public void RegisterListener(PlayerResourcesEventListener listener)
	{
		Listeners.Add(listener);
	}

	public void UnregisterListener(PlayerResourcesEventListener listener)
	{
		Listeners.Remove(listener);
	}
}