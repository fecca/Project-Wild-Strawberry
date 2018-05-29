using System;
using System.Collections;
using UnityEngine;

public class Building : MonoBehaviour
{
	[SerializeField]
	private BuildingData Data;
	[SerializeField]
	private BuildingRuntimeSet ActiveBuildings;
	[SerializeField]
	private BuildingState State;
	[SerializeField]
	private BuildingEvent OnConstruct;
	[SerializeField]
	private BuildingEvent OnSelect;

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
		FollowMouse();
	}

	private void OnDisable()
	{
		ActiveBuildings.Remove(this);

		State = BuildingState.Inactive;
	}

	private void OnDestroy()
	{
		ActiveBuildings.Remove(this);
	}

	private void Update()
	{
		if (State == BuildingState.Placing)
		{
			FollowMouse();
		}
	}

	private void FollowMouse()
	{
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, 1 << LayerMask.NameToLayer("Ground")))
		{
			transform.position = hit.point;
		}
	}

	private void Place()
	{
		ActiveBuildings.Add(this);
		StartCoroutine(Construct());
	}

	private IEnumerator Construct()
	{
		State = BuildingState.Constructing;
		OnConstruct.Raise(this);

		var steps = (float)Data.ConstructionTime / Renderers.Length;
		for (var i = 0; i < Renderers.Length; i++)
		{
			yield return new WaitForSeconds(steps);
			Renderers[i].sharedMaterial = Material;
		}

		State = BuildingState.Active;
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
				OnSelect.Raise(this);
				break;
			case BuildingState.Selected: break;
			default: throw new NotSupportedException("BuildingState not supported: " + State);
		}
	}

	public void RightClick()
	{
		if (State == BuildingState.Placing)
		{
			Destroy(gameObject);
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

	public int GetTickValue()
	{
		return Data.TickValue;
	}
}