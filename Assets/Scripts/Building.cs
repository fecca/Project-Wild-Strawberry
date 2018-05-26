using UnityEngine;

public enum BuildingState
{
	Inactive,
	Placing,
	Constructing,
	Built,
}
public class Building : MonoBehaviour
{
	[SerializeField]
	private BuildingRuntimeSet AvailableBuildings;
	[SerializeField]
	private BuildingRuntimeSet BuiltBuildings;
	[SerializeField]
	private BuildingState State;

	private void OnEnable()
	{
		AvailableBuildings.Remove(this);

		State = BuildingState.Placing;
	}

	private void OnDisable()
	{
		BuiltBuildings.Remove(this);
		AvailableBuildings.Add(this);

		State = BuildingState.Inactive;
	}

	private void OnDestroy()
	{
		BuiltBuildings.Remove(this);
		AvailableBuildings.Remove(this);
	}

	public void Place()
	{
		BuiltBuildings.Add(this);

		State = BuildingState.Built;
	}

	public BuildingState GetState()
	{
		return State;
	}
}