using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
	[SerializeField]
	private FloatReference MaxHealth;
	[SerializeField]
	private FloatVariable Health;
	[SerializeField]
	private bool ResetHealthOnAwake;
	[SerializeField]
	private UnityEvent OnDamageTaken;

	[SerializeField]
	private float m_timer = 0.5f;
	private float m_time = 0f;

	private void Awake()
	{
		if (ResetHealthOnAwake)
		{
			Health.Value = MaxHealth.Value;
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
		m_time += Time.deltaTime;
		if (m_time >= m_timer)
		{
			m_time = 0f;
			OnDamageTaken.Invoke();
		}
	}
}