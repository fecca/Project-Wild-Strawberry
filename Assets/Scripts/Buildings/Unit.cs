using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Unit : Entity
{
	[SerializeField]
	private NavMeshAgent Agent;

	private IEnumerator MoveToBuilding(Building building)
	{
		building.SetState(BuildingState.Constructing);
		Agent.SetDestination(building.transform.position);

		yield return new WaitForSeconds(1.0f);

		var dist = Agent.remainingDistance;
		while (Agent.pathStatus != NavMeshPathStatus.PathComplete || Agent.remainingDistance > 0)
		{
			yield return new WaitForEndOfFrame();
		}

		EventManager.TriggerEvent(BuildingEventType.StartConstruction, building);
		Destroy(gameObject);
	}

	public override void Click()
	{
		Select(true);
	}

	public override void TriggerButtonPress(Entity entity)
	{
		if (!(entity is Building))
		{
			EventManager.TriggerEvent(StringEventType.ErrorMessage, "Only building have build support");
			return;
		}

		EventManager.TriggerEvent(BuildingEventType.ButtonPress, (Building)entity);
	}

	public void MoveTo(Building building)
	{
		StartCoroutine(MoveToBuilding(building));
	}
}