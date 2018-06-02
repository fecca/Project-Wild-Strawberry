using UnityEngine;

public class BuildingBounds : MonoBehaviour
{
	[SerializeField]
	private Material Material;
	[SerializeField]
	private Material CollisionMaterial;

	private Renderer m_renderer;
	private BuildingPlacementValidator m_validator;
	private bool m_hasCollided;

	private void Awake()
	{
		m_renderer = GetComponent<Renderer>();
	}

	public void Initialize(BuildingPlacementValidator validator)
	{
		m_validator = validator;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (m_renderer.enabled)
		{
			m_renderer.sharedMaterial = CollisionMaterial;
		}
		m_validator.Collisions++;
	}

	private void OnTriggerExit(Collider other)
	{
		if (m_renderer.enabled)
		{
			m_renderer.sharedMaterial = Material;
		}
		m_validator.Collisions--;
	}

	public void DisableTriggers()
	{
		m_renderer.enabled = false;
	}
}