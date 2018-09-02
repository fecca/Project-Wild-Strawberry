using System.Collections;
using UnityEngine;

public class Building : MonoBehaviour
{
	[SerializeField]
	private UnitBuilder UnitBuilder;

	[Header("Data")]
	[SerializeField]
	private BuildingData Data;
	[SerializeField]
	private ButtonData ButtonData;
	[SerializeField]
	private BuildingState State;

	[Header("Rendering")]
	[SerializeField]
	private Material Material;
	[SerializeField]
	private Material PlacingMaterial;
	[SerializeField]
	private Renderer[] Renderers;
	[SerializeField]
	private GameObject Circle;

	[Header("Grid/Collision")]
	[SerializeField]
	private BuildingPlacementValidator BuildingPlacementValidator;
	[SerializeField]
	private BuildingGridBounds BuildingGridBounds;

	public float TickValue { get { return Data.TickValue; } }

	public string Name { get { return ButtonData.Name; } }
	public int Cost { get { return ButtonData.Cost; } }
	public int ConstructionTime { get { return ButtonData.ConstructionTime; } }
	public Sprite Icon { get { return ButtonData.Icon; } }

	private void OnEnable()
	{
		gameObject.name = Data.Name;
		SetPlacementMaterial();
		BuildingGridBounds.EnableRenderers();
		State = BuildingState.Placing;
	}

	private void SetPlacementMaterial()
	{
		foreach (var renderer in Renderers)
		{
			renderer.sharedMaterial = PlacingMaterial;
		}
	}

	private IEnumerator Construct()
	{
		State = BuildingState.Constructing;

		var steps = (float)ButtonData.ConstructionTime / Renderers.Length;
		for (var i = 0; i < Renderers.Length; i++)
		{
			yield return new WaitForSeconds(steps);
			Renderers[i].sharedMaterial = Material;
		}

		State = BuildingState.Idle;
		EventManager.TriggerEvent(BuildingEventType.Constructed, this);
	}

	public bool ValidatePlacement()
	{
		return State == BuildingState.Placing && BuildingPlacementValidator.Validate(BuildingGridBounds);
	}

	public void Place()
	{
		gameObject.layer = LayerMask.NameToLayer("Building");
		BuildingGridBounds.DisableRenderers();
		StartCoroutine(Construct());
	}

	public void Select(bool select)
	{
		Circle.SetActive(select);
	}

	public BuildingState GetState()
	{
		return State;
	}

	public void TrainUnit(UnitType type)
	{
		if (State != BuildingState.Idle)
		{
			EventManager.TriggerEvent(StringEventType.ErrorMessage, "Building is not ready yet");
			return;
		}

		UnitBuilder.TrainUnit(type);
	}
}