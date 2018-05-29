using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BuildingController : MonoBehaviour
{
	[SerializeField]
	private UnityEvent OnStart;
	[SerializeField]
	private BuildingRuntimeSet ActiveBuildings;
	[SerializeField]
	private BuildingRuntimeSet BuildingsUnderConstruction;
	[SerializeField]
	private PlayerResources PlayerResources;
	[SerializeField]
	private FloatReference TickInterval;
	[SerializeField]
	private BuildingVariable ActiveBuilding;

	private void Start()
	{
		OnStart.Invoke();
		StartCoroutine(TickBuildings());
	}

	public void BuildBuilding(Building building)
	{
		if (ActiveBuilding.Value == null)
		{
			ActiveBuilding.Value = Instantiate(building);
		}
	}

	public void ConstructBuilding(Building building)
	{
		BuildingsUnderConstruction.Add(building);
		ActiveBuilding.Value = null;
	}

	public void CancelBuilding(Building building)
	{
		ActiveBuildings.Remove(building);
		ActiveBuilding.Value = null;
		Destroy(building.gameObject);
	}

	public void ResetBuildings()
	{
		for (int i = ActiveBuildings.Items.Count - 1; i >= 0; i--)
		{
			Destroy(ActiveBuildings.Items[i].gameObject);
		}
	}

	private IEnumerator TickBuildings()
	{
		while (true)
		{
			yield return new WaitForSeconds(TickInterval.Value);

			var totalValue = 0f;
			foreach (var building in ActiveBuildings.Items)
			{
				totalValue += building.GetTickValue();
			}

			PlayerResources.Gold += totalValue;
		}
	}
}