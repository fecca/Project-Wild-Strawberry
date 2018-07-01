using System.Collections.Generic;
using UnityEngine;

public class BuildingGridBounds : MonoBehaviour
{
	[SerializeField]
	private ColliderData ColliderData;
	[SerializeField]
	private BuildingPlacementTrigger Prefab;

	public int Collisions { get; set; }

	private List<BuildingPlacementTrigger> Triggers = new List<BuildingPlacementTrigger>();

	private void Start()
	{
		CreateCollision();
	}

	private void CreateCollision()
	{
		var width = ColliderData.Width;
		var depth = ColliderData.Depth;
		var unitSize = ColliderData.UnitSize.Value;

		for (var x = 0; x < width; x++)
		{
			for (var z = 0; z < depth; z++)
			{
				var position = transform.position;
				position.x += (x * unitSize) - ((width - 1) * 0.5f) * unitSize;
				position.z += (z * unitSize) - ((depth - 1) * 0.5f) * unitSize;
				var trigger = Instantiate(Prefab, position, Quaternion.identity, transform);
				trigger.transform.localScale = new Vector3(unitSize, 0.1f, unitSize) * 0.9f;
				trigger.Initialize(this);
				Triggers.Add(trigger);
			}
		}
	}

	public void EnableRenderers()
	{
		foreach (var trigger in Triggers)
		{
			trigger.EnableRenderer();
		}
	}

	public void DisableRenderers()
	{
		foreach (var trigger in Triggers)
		{
			trigger.DisableRenderer();
		}
	}
}