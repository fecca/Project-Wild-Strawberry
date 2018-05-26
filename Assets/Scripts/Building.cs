using System;
using UnityEngine;

public class Building : MonoBehaviour
{
	[SerializeField]
	private BuildingRuntimeSet BuiltBuildings;
	[SerializeField]
	private BuildingState State;
	[SerializeField]
	private BuildingEvent OnClick;

	[Header("Rendering")]
	[SerializeField]
	private Material Material;
	[SerializeField]
	private Material PlacingMaterial;
	[SerializeField]
	private Renderer[] Renderers;

	private void OnEnable()
	{
		foreach (var renderer in Renderers)
		{
			renderer.sharedMaterial = PlacingMaterial;
		}
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

	public void Interact()
	{
		switch (State)
		{
			case BuildingState.Inactive:
				break;
			case BuildingState.Placing:
				Place();
				break;
			case BuildingState.Built:
				OpenBuildingMenu();
				break;
			default:
				throw new NotSupportedException("BuildingState not supported: " + State);
		}
	}

	private void Place()
	{
		BuiltBuildings.Add(this);
		foreach (var renderer in Renderers)
		{
			renderer.sharedMaterial = Material;
		}
		State = BuildingState.Built;
	}

	private void OpenBuildingMenu()
	{
		OnClick.Raise(this);
	}

	public BuildingState GetState()
	{
		return State;
	}
}