using UnityEngine;

public class Building : MonoBehaviour
{
	[SerializeField]
	private BuildingRuntimeSet AvailableBuildings;
	[SerializeField]
	private BuildingRuntimeSet BuiltBuildings;

	private void OnEnable()
	{
		AvailableBuildings.Remove(this);
		BuiltBuildings.Add(this);
	}

	private void OnDisable()
	{
		BuiltBuildings.Remove(this);
		AvailableBuildings.Add(this);
	}

	private void OnDestroy()
	{
		BuiltBuildings.Remove(this);
		AvailableBuildings.Remove(this);
	}
}