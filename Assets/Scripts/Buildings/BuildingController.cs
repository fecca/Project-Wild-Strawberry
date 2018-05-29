using System.Collections;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
	[SerializeField]
	private BuildingsVariable AllBuildings;
	[SerializeField]
	private BuildingRuntimeSet BuildingsUnderConstruction;
	[SerializeField]
	private BuildingRuntimeSet ActiveBuildings;
	[SerializeField]
	private FloatReference TickInterval;
	[SerializeField]
	private PlayerResources PlayerResources;
	[SerializeField]
	private bool ClearBuildingsOnAwake;

	private void Awake()
	{
		if (ClearBuildingsOnAwake)
		{
			BuildingsUnderConstruction.Items.Clear();
			ActiveBuildings.Items.Clear();
		}
	}

	private void Start()
	{
		StartCoroutine(TickBuildings());
	}

	public void BuildBuilding(Building building)
	{
		Instantiate(building);
	}

	public void ConstructBuilding(Building building)
	{
		BuildingsUnderConstruction.Add(building);
	}

	public void CompleteConstruction(Building building)
	{
		BuildingsUnderConstruction.Remove(building);
		ActiveBuildings.Add(building);
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

			var totalValue = 0;
			foreach (var building in ActiveBuildings.Items)
			{
				totalValue += building.GetTickValue();
			}

			PlayerResources.Gold += totalValue;
		}
	}
}