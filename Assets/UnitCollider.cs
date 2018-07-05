using System.Collections.Generic;
using UnityEngine;

public class UnitCollider : MonoBehaviour
{
	private List<GameObject> m_colliders = new List<GameObject>();

	private void OnTriggerEnter(Collider other)
	{
		m_colliders.Add(other.gameObject);
		other.GetComponent<Renderer>().material.color = Color.red;
	}

	private void OnTriggerExit(Collider other)
	{
		m_colliders.Remove(other.gameObject);
		other.GetComponent<Renderer>().material.color = Color.white;
	}

	public List<GameObject> GetUnits()
	{
		return m_colliders;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, transform.localScale);
	}
}
