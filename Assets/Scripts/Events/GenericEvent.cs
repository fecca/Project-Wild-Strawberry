using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GenericEvent : ScriptableObject
{
	private List<GenericEventListener> Listeners = new List<GenericEventListener>();

	public void Raise()
	{
		for (int i = Listeners.Count - 1; i >= 0; i--)
		{
			Listeners[i].OnEventRaised();
		}
	}

	public void RegisterListener(GenericEventListener listener)
	{
		Listeners.Add(listener);
	}

	public void UnregisterListener(GenericEventListener listener)
	{
		Listeners.Remove(listener);
	}
}