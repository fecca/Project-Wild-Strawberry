using UnityEngine;
using UnityEngine.Events;

public class GenericEventListener : MonoBehaviour
{
	[SerializeField]
	private GenericEvent Event;
	[SerializeField]
	private UnityEvent Response;

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised()
	{
		Response.Invoke();
	}
}