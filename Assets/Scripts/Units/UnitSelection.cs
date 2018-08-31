using UnityEngine;

public class UnitSelection : MonoBehaviour
{
	[SerializeField]
	private LayerMask m_layerMask;
	[SerializeField]
	private LineRenderer m_lineRenderer;
	[SerializeField]
	private UnitCollider m_colliderPrefab;

	private Vector3 m_startPosition;
	private bool m_mouseDown;
	private Vector3 point0;
	private Vector3 point1;
	private Vector3 point2;
	private Vector3 point3;
	private UnitCollider m_collider;

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500f, m_layerMask))
			{
				if (!m_mouseDown)
				{
					m_startPosition = hit.point;
					m_mouseDown = true;
					m_collider = Instantiate(m_colliderPrefab) as UnitCollider;
				}

				point0 = m_startPosition + Vector3.up;
				point1 = new Vector3(m_startPosition.x, m_startPosition.y, hit.point.z) + Vector3.up;
				point2 = new Vector3(hit.point.x, m_startPosition.y, hit.point.z) + Vector3.up;
				point3 = new Vector3(hit.point.x, m_startPosition.y, m_startPosition.z) + Vector3.up;

				m_lineRenderer.positionCount = 4;
				m_lineRenderer.SetPositions(new Vector3[] { point0, point1, point2, point3 });

				m_collider.transform.position = Vector3.Lerp(point0, point2, 0.5f);
				m_collider.transform.localScale = new Vector3((point1 - point2).magnitude, 1f, (point0 - point1).magnitude);
			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			if (m_mouseDown)
			{
				var colliders = m_collider.GetUnits();
				Debug.Log($"Selected {colliders.Count} units ");

				m_mouseDown = false;
				m_lineRenderer.positionCount = 0;

				Destroy(m_collider.gameObject);
			}
		}
	}
}
