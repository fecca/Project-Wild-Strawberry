using System;
using System.Collections;
using UnityEngine;

public class Building : MonoBehaviour
{
	[Header("Events")]
	[SerializeField]
	private BuildingUnityEvent OnConstructionComplete;
	[SerializeField]
	private BuildingUnityEvent OnSelect;
	[SerializeField]
	private BuildingUnityEvent OnCancelled;

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

	private void OnEnable()
	{
		gameObject.name = Data.Name;
		foreach (var renderer in Renderers)
		{
			renderer.sharedMaterial = PlacingMaterial;
		}
		State = BuildingState.Placing;
	}

	private IEnumerator Construct()
	{
		State = BuildingState.Constructing;

		var steps = (float)Data.ConstructionTime / Renderers.Length;
		for (var i = 0; i < Renderers.Length; i++)
		{
			yield return new WaitForSeconds(steps);
			Renderers[i].sharedMaterial = Material;
		}

		State = BuildingState.Active;
		OnConstructionComplete.Invoke(this);
	}

	public void Place()
	{
		gameObject.layer = LayerMask.NameToLayer("Building");
		StartCoroutine(Construct());
	}

	public void LeftClick()
	{
		switch (State)
		{
			case BuildingState.Inactive: break;
			case BuildingState.Placing:
				Place();
				break;
			case BuildingState.Constructing:
			case BuildingState.Active:
				OnSelect.Invoke(this);
				break;
			case BuildingState.Selected: break;
			default: throw new NotSupportedException("BuildingState not supported: " + State);
		}
	}

	public void RightClick()
	{
		if (State == BuildingState.Placing)
		{
			OnCancelled.Invoke(this);
		}
	}

	public BuildingState GetState()
	{
		return State;
	}

	public string GetDisplayName()
	{
		return Data.Name;
	}

	public int GetCost()
	{
		return Data.Cost;
	}

	public int GetConstructionTime()
	{
		return Data.ConstructionTime;
	}

	public Sprite GetIcon()
	{
		return Data.Icon;
	}

	public float GetTickValue()
	{
		return Data.TickValue;
	}
}