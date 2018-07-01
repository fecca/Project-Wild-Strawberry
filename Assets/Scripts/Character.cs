using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent Agent;

	private Vector3 m_start;
	private Vector3 m_end;
	private Vector3 m_destination;
	private float m_timer;

	private void Start()
	{
		m_start = transform.position;
		m_end = transform.position + transform.forward * 30f;
		m_destination = m_end;
	}

	private void Update()
	{
		if (!Agent.pathPending)
		{
			if (Agent.remainingDistance <= Agent.stoppingDistance)
			{
				if (!Agent.hasPath || Agent.velocity.sqrMagnitude == 0f)
				{
					if ((transform.position - m_start).magnitude <= 0.1f)
					{
						m_destination = m_end;
					}

					if ((transform.position - m_end).magnitude <= 0.1f)
					{
						m_destination = m_start;
					}
				}
			}
		}

		m_timer += Time.deltaTime;
		if (m_timer > 1.0f)
		{
			m_timer = 0f;
			Agent.SetDestination(m_destination);
		}
	}
}