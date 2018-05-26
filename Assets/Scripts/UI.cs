using UnityEngine;

public class UI : MonoBehaviour
{
	[SerializeField]
	private BuildingsVariable AllBuildings;
	[SerializeField]
	private BuildingButton BuildingButtonTemplate;

	private BuildingButton m_buildingMenuButton;

	private void Start()
	{
		BuildingButtonTemplate.gameObject.SetActive(false);
		UpdateButtons();
	}

	public void UpdateButtons()
	{
		if (BuildingButtonTemplate == null) { return; }
		if (AllBuildings == null) { return; }

		for (var i = AllBuildings.Value.Count - 1; i >= 0; i--)
		{
			var building = AllBuildings.Value[i];
			var button = Instantiate(BuildingButtonTemplate, transform) as BuildingButton;
			button.SetText(building.name);
			button.SetPosition(Vector3.up * (40 * i));
			button.SetBuildingReference(building);
			button.gameObject.SetActive(true);
		}
	}

	public void OpenBuildingMenu(Building building)
	{
		if (m_buildingMenuButton == null)
		{
			m_buildingMenuButton = Instantiate(BuildingButtonTemplate, transform) as BuildingButton;
			m_buildingMenuButton.SetPosition(Vector3.up * (40 * 1) + Vector3.right * 130);
		}
		m_buildingMenuButton.SetText(building.name);
		m_buildingMenuButton.SetBuildingReference(building);
		m_buildingMenuButton.gameObject.SetActive(true);
	}
}