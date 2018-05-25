using UnityEngine;

public class BuildingHolder : MonoBehaviour
{
	[SerializeField]
	private BuildingsVariable AllBuildings;
	[SerializeField]
	private BuildingRuntimeSet AvailableBuildings;
	[SerializeField]
	private BuildingRuntimeSet BuiltBuildings;
	[SerializeField]
	private bool ClearBuildingsOnAwake;

	private void Awake()
	{
		if (ClearBuildingsOnAwake)
		{
			AvailableBuildings.Items.Clear();
			BuiltBuildings.Items.Clear();
		}

		InstantiateAllBuildings();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			var itemCount = AvailableBuildings.Items.Count;
			if (itemCount > 0)
			{
				var index = Random.Range(0, AvailableBuildings.Items.Count);
				var building = AvailableBuildings.Items[index];
				building.gameObject.SetActive(true);
			}
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			var itemCount = BuiltBuildings.Items.Count;
			if (itemCount > 0)
			{
				var index = Random.Range(0, BuiltBuildings.Items.Count);
				var building = BuiltBuildings.Items[index];
				building.gameObject.SetActive(false);
			}
		}
	}

	private void InstantiateAllBuildings()
	{
		for (var i = AllBuildings.Value.Count - 1; i >= 0; i--)
		{
			var building = Instantiate(AllBuildings.Value[i]);
			building.gameObject.SetActive(false);
		}
	}
}