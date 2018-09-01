using UnityEngine;

public class UnitEventListener : MonoBehaviour
{
	[SerializeField]
	private UnitEvent Event;
	[SerializeField]
	private UnitUnityEvent Response = new UnitUnityEvent();

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised(Unit unit)
	{
		Debug.Log($"{this} received event: {Event}");
		Response.Invoke(unit);
	}
}
