using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EntityEvent : ScriptableObject
{
	private List<EntityEventListener> Listeners = new List<EntityEventListener>();

	public void Raise(Entity entity)
	{
		Debug.Log($"Raising event: {this}");
		for (int i = Listeners.Count - 1; i >= 0; i--)
		{
			Listeners[i].OnEventRaised(entity);
		}
	}

	public void RegisterListener(EntityEventListener listener)
	{
		Listeners.Add(listener);
	}

	public void UnregisterListener(EntityEventListener listener)
	{
		Listeners.Remove(listener);
	}
}