using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StringEvent : ScriptableObject
{
	private List<StringEventListener> Listeners = new List<StringEventListener>();

	public void Raise(string message)
	{
		for (int i = Listeners.Count - 1; i >= 0; i--)
		{
			Listeners[i].OnEventRaised(message);
		}
	}

	public void RegisterListener(StringEventListener listener)
	{
		Listeners.Add(listener);
	}

	public void UnregisterListener(StringEventListener listener)
	{
		Listeners.Remove(listener);
	}
}