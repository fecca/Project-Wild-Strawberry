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
	[SerializeField]
	private GameObject Circle;

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

	public void Select(bool select)
	{
		Circle.SetActive(select);
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