using UnityEngine;

public class UI : MonoBehaviour
{
	[SerializeField]
	private BuildingsVariable AllBuildings;
	[SerializeField]
	private BuildingButton BuildingButtonTemplate;

	private void Start()
	{
		if (BuildingButtonTemplate == null) { return; }
		if (AllBuildings == null) { return; }

		for (var i = AllBuildings.Value.Count - 1; i >= 0; i--)
		{
			var building = AllBuildings.Value[i];
			var button = Instantiate(BuildingButtonTemplate, transform) as BuildingButton;
			button.SetText(building.name);
			button.SetPosition(button.transform.position + Vector3.up * (40 * i));
			button.SetBuildingReference(building);
		}
		BuildingButtonTemplate.gameObject.SetActive(false);
	}
}