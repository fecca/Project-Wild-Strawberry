using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
	[SerializeField]
	private BuildingRuntimeSet AvailableBuildings;
	[SerializeField]
	private BuildingRuntimeSet BuiltBuildings;
	[SerializeField]
	private BuildingState State;

	[Header("Visuals")]
	[SerializeField]
	private Image Icon;
	[SerializeField]
	private Material Material;
	[SerializeField]
	private Material PlacingMaterial;
	[SerializeField]
	private Renderer Renderer;

	private void OnEnable()
	{
		AvailableBuildings.Remove(this);
		Renderer.material = PlacingMaterial;
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
		Renderer.material = Material;
		State = BuildingState.Built;
	}

	public BuildingState GetState()
	{
		return State;
	}
}