using UnityEngine;

public class UI : MonoBehaviour
{
	[SerializeField]
	private BuildingRuntimeSet AvailableBuildings;
	[SerializeField]
	private BuildingButton BuildingButtonTemplate;

	private void Start()
	{
		if (BuildingButtonTemplate == null) { return; }
		if (AvailableBuildings == null) { return; }

		for (var i = AvailableBuildings.Items.Count - 1; i >= 0; i--)
		{
			var building = AvailableBuildings.Items[i];
			var button = Instantiate(BuildingButtonTemplate, transform) as BuildingButton;
			button.SetText(building.name);
			button.SetPosition(button.transform.position + Vector3.up * (40 * i));
			button.SetBuildingReference(building);
		}
		BuildingButtonTemplate.gameObject.SetActive(false);
	}
}