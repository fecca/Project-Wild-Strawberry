using UnityEngine;

public class BuildingPlacementTrigger : MonoBehaviour
{
	[SerializeField]
	private Material Material;
	[SerializeField]
	private Material CollisionMaterial;

	private Renderer m_renderer;
	private BuildingGridBounds m_buildingGridBounds;
	private bool m_hasCollided;

	private void Awake()
	{
		m_renderer = GetComponent<Renderer>();
	}

	public void Initialize(BuildingGridBounds buildingGridBounds)
	{
		m_buildingGridBounds = buildingGridBounds;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (m_renderer.enabled)
		{
			m_renderer.sharedMaterial = CollisionMaterial;
		}
		m_buildingGridBounds.Collisions++;
	}

	private void OnTriggerExit(Collider other)
	{
		if (m_renderer.enabled)
		{
			m_renderer.sharedMaterial = Material;
		}
		m_buildingGridBounds.Collisions--;
	}

	public void DisableTriggers()
	{
		m_renderer.enabled = false;
	}
}