using UnityEngine;

public class BuildingController : MonoBehaviour
{
	[SerializeField]
	private BuildingsVariable AllBuildings;
	[SerializeField]
	private BuildingRuntimeSet ActiveBuildings;
	[SerializeField]
	private bool ClearBuildingsOnAwake;

	private void Awake()
	{
		if (ClearBuildingsOnAwake)
		{
			ActiveBuildings.Items.Clear();
		}
	}

	public void BuildBuilding(Building building)
	{
		Instantiate(building);
	}

	public void ResetBuildings()
	{
		for (int i = ActiveBuildings.Items.Count - 1; i >= 0; i--)
		{
			Destroy(ActiveBuildings.Items[i].gameObject);
		}
	}
}