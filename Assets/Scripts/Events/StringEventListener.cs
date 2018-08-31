using UnityEngine;

public class StringEventListener : MonoBehaviour
{
	[SerializeField]
	private StringEvent Event;
	[SerializeField]
	private StringUnityEvent Response;

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised(string message)
	{
		Response.Invoke(message);
	}
}