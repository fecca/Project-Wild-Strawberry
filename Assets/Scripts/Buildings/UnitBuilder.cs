using System.Collections;
using UnityEngine;

public class UnitBuilder : MonoBehaviour
{
	private bool m_isTraining;

	public void TrainUnit(Unit unit)
	{
		if (m_isTraining)
		{
			EventManager.TriggerEvent(StringEventType.ErrorMessage, "Building is busy");
			return;
		}

		StartCoroutine(Train(unit));
	}

	private IEnumerator Train(Unit prefab)
	{
		m_isTraining = true;

		yield return new WaitForSeconds(2.0f);

		var unit = Instantiate(prefab) as Unit;
		var randomPosition = Random.insideUnitCircle.normalized * 1.5f;
		unit.transform.position = transform.position + new Vector3(randomPosition.x, 1, randomPosition.y);

		m_isTraining = false;
		EventManager.TriggerEvent(UnitEventType.UnitTrained, unit);
	}
}