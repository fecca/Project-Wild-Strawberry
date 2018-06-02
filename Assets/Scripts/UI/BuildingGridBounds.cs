using System.Collections.Generic;
using UnityEngine;

public class BuildingGridBounds : MonoBehaviour
{
	[SerializeField]
	private BuildingData BuildingData;
	[SerializeField]
	private BuildingPlacementTrigger Prefab;

	public int Collisions { get; set; }

	private List<BuildingPlacementTrigger> Triggers = new List<BuildingPlacementTrigger>();

	public void CreateCollision()
	{
		var width = BuildingData.ColliderData.Width;
		var depth = BuildingData.ColliderData.Depth;
		var unitSize = BuildingData.ColliderData.UnitSize.Value;

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
}