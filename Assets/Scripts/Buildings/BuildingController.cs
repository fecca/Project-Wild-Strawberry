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
		ActiveBuilding.Value = Instantiate(building);
	}

	public void PlaceBuilding(Building building)
	{
		building.Place();
		BuildingsUnderConstruction.Add(building);
		ActiveBuilding.Value = null;
	}

	public void BuildingConstructionCompleted(Building building)
	{
		BuildingsUnderConstruction.Remove(building);
		ActiveBuildings.Add(building);
	}

	public void CancelBuilding(Building building)
	{
		ActiveBuilding.Value = null;
		Destroy(building.gameObject);
	}

	public void SelectBuilding(Building building)
	{
		ActiveBuilding.Value = building;
	}

	public void ResetBuildings()
	{
		for (int i = ActiveBuildings.Items.Count - 1; i >= 0; i--)
		{
			CancelBuilding(ActiveBuildings.Items[i]);
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