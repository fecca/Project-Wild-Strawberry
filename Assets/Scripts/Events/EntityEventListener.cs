using UnityEngine;

public class EntityEventListener : MonoBehaviour
{
	[SerializeField]
	private EntityEvent Event;
	[SerializeField]
	private EntityUnityEvent Response = new EntityUnityEvent();

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised(Entity entity)
	{
		Debug.Log($"{this} received event: {Event}");
		Response.Invoke(entity);
	}
}