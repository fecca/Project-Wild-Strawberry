using System.Collections;
using UnityEngine;

public class Building : Entity
{
	[SerializeField]
	private UnitBuilder UnitBuilder;

	[Header("Data")]
	[SerializeField]
	private BuildingData Data;
	[SerializeField]
	private BuildingState State;

	[Header("Rendering")]
	[SerializeField]
	private Material Material;
	[SerializeField]
	private Material PlacingMaterial;
	[SerializeField]
	private Renderer[] Renderers;

	[Header("Grid/Collision")]
	[SerializeField]
	private BuildingPlacementValidator BuildingPlacementValidator;
	[SerializeField]
	private BuildingGridBounds BuildingGridBounds;

	public float TickValue { get { return Data.TickValue; } }

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

		var steps = (float)ConstructionTime / Renderers.Length;
		for (var i = 0; i < Renderers.Length; i++)
		{
			yield return new WaitForSeconds(steps);
			Renderers[i].sharedMaterial = Material;
		}

		State = BuildingState.Idle;
		EventManager.TriggerEvent(BuildingEventType.Constructed, this);
	}

	private void TrainUnit(Unit unit)
	{
		if (State != BuildingState.Idle)
		{
			EventManager.TriggerEvent(StringEventType.ErrorMessage, "Building is not ready yet");
			return;
		}

		UnitBuilder.TrainUnit(unit);
	}

	public override void Click()
	{
		if (ValidatePlacement())
		{
			EventManager.TriggerEvent(BuildingEventType.Construct, this);
		}
		else
		{
			Select(true);
		}
	}

	public override void TriggerButtonPress(Entity entity)
	{
		if (!(entity is Unit))
		{
			EventManager.TriggerEvent(StringEventType.ErrorMessage, "Only units have build support");
			return;
		}

		TrainUnit((Unit)entity);
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

	public BuildingState GetState()
	{
		return State;
	}
}