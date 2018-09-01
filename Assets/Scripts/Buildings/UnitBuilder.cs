using System;
using System.Collections;
using UnityEngine;

public class UnitBuilder : MonoBehaviour
{
	private bool m_isTraining;

	public void TrainUnit(UnitType type)
	{
		if (m_isTraining)
		{
			EventManager.TriggerEvent(StringEventType.ErrorMessage, "Building is busy");
			return;
		}

		switch (type)
		{
			case UnitType.FilthyPeasant:
				StartCoroutine(Train(type));
				break;
			default:
				throw new NotImplementedException($"UnitType not implemented: {type}");
		}
	}

	private IEnumerator Train(UnitType type)
	{
		m_isTraining = true;

		yield return new WaitForSeconds(2.0f);

		var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.name = type.ToString();
		var unit = cube.AddComponent<Unit>();
		cube.AddComponent<Rigidbody>();
		cube.transform.localScale = Vector3.one * 0.25f;
		var randomPosition = UnityEngine.Random.insideUnitCircle.normalized * 1.5f;
		cube.transform.position = transform.position + new Vector3(randomPosition.x, 1, randomPosition.y);

		m_isTraining = false;
		EventManager.TriggerEvent(UnitEventType.UnitTrained, unit);
	}
}