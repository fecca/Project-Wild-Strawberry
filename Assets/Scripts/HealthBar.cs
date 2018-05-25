using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField]
	private Image m_image;
	[SerializeField]
	private FloatReference PlayerMaxHealth;
	[SerializeField]
	private FloatVariable PlayerHealth;

	public void UpdateHealth()
	{
		m_image.fillAmount = Mathf.Clamp01(PlayerHealth.Value / PlayerMaxHealth.Value);
	}
}