using UnityEngine;

public class BuildingEventListener : MonoBehaviour
{
	[SerializeField]
	private BuildingEvent Event;
	[SerializeField]
	private BuildingUnityEvent Response = new BuildingUnityEvent();

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised(Building building)
	{
		Debug.Log($"Received event: {Event}");
		Response.Invoke(building);
	}
}
