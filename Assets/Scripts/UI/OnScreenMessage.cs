using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenMessage : MonoBehaviour
{
	[Header("UI")]
	[SerializeField]
	private Text m_text;

	private Coroutine m_coroutine;

	private void Awake()
	{
		m_text.color = m_text.color.WithAlpha(0.0f);
	}

	public void DisplayMessage(string message)
	{
		if (m_coroutine != null) { StopCoroutine(m_coroutine); }

		m_text.text = message;
		m_text.color = m_text.color.WithAlpha(1.0f);
		m_coroutine = StartCoroutine(FadeText());
	}

	private IEnumerator FadeText()
	{
		yield return new WaitForSeconds(2.0f);

		var startingAlpha = m_text.color.a;
		var endingAlpha = 0.0f;
		var currentAlpha = startingAlpha;
		var t = 0.0f;
		var overTime = 0.5f;

		while (currentAlpha > endingAlpha)
		{
			currentAlpha = Mathf.Lerp(startingAlpha, endingAlpha, t / overTime);
			m_text.color = m_text.color.WithAlpha(currentAlpha);
			t += Time.deltaTime;

			yield return new WaitForEndOfFrame();
		}
	}
}