using UnityEngine;

public class BuildingBounds : MonoBehaviour
{
	[SerializeField]
	private Material Material;
	[SerializeField]
	private Material CollisionMaterial;

	private Renderer m_renderer;

	private void Awake()
	{
		m_renderer = GetComponent<Renderer>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (m_renderer.enabled)
		{
			m_renderer.sharedMaterial = CollisionMaterial;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (m_renderer.enabled)
		{
			m_renderer.sharedMaterial = Material;
		}
	}

	public void DisableTriggers()
	{
		m_renderer.enabled = false;
	}
}