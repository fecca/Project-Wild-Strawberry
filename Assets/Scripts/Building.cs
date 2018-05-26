using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
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
		Renderer.material = PlacingMaterial;
		State = BuildingState.Placing;
	}

	private void OnDisable()
	{
		BuiltBuildings.Remove(this);

		State = BuildingState.Inactive;
	}

	private void OnDestroy()
	{
		BuiltBuildings.Remove(this);
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