using UnityEngine;

public class PlayerResourcesEventListener : MonoBehaviour
{
	[SerializeField]
	private PlayerResourcesEvent Event;
	[SerializeField]
	private PlayerResourcesUnityEvent Response = new PlayerResourcesUnityEvent();

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised(PlayerResources playerResources)
	{
		Response.Invoke(playerResources);
	}
}