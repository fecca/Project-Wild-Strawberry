using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanel : MonoBehaviour
{
	[Header("UI")]
	[SerializeField]
	private Text TypeText;
	[SerializeField]
	private Text DisplayNameText;
	[SerializeField]
	private Text CostText;
	[SerializeField]
	private Text ConstructionTimeText;
	[SerializeField]
	private Text State;
	[SerializeField]
	private BuildingButton BuildingButtonPrefab;
	[SerializeField]
	private GameObject ConstructMenu;
	[SerializeField]
	private GameObject ContextMenu;

	[Header("Data")]
	[SerializeField]
	private BuildingsVariable AllBuildings;

	private List<BuildingButton> m_buildingButtons = new List<BuildingButton>();

	private void Start()
	{
		ClearText();
		CreateButtons();
		SelectBuilding(null);
	}

	private void ClearText()
	{
		TypeText.text = string.Empty;
		DisplayNameText.text = string.Empty;
		CostText.text = string.Empty;
		ConstructionTimeText.text = string.Empty;
		State.text = string.Empty;
	}

	private void SelectBuilding(Building building)
	{
		ClearText();

		if (building == null)
		{
			ConstructMenu.SetActive(true);
			ContextMenu.SetActive(false);
		}
		else
		{
			TypeText.text = string.Format("Type: {0}", building.Name);
			DisplayNameText.text = string.Format("Name: {0}", building.Name);
			CostText.text = string.Format("Cost: {0}", building.Cost);
			ConstructionTimeText.text = string.Format("Construction time: {0}", building.ConstructionTime);
			State.text = string.Format("State: {0}", building.GetState());

			ConstructMenu.SetActive(false);
			ContextMenu.SetActive(true);
		}
	}

	private void CreateButtons()
	{
		if (BuildingButtonPrefab == null) { return; }
		if (AllBuildings == null) { return; }

		for (var i = AllBuildings.Value.Count - 1; i >= 0; i--)
		{
			var button = Instantiate(BuildingButtonPrefab, ConstructMenu.transform) as BuildingButton;
			var position = new Vector3 { x = (i * 100), z = 0, y = 0 };
			button.Setup(AllBuildings.Value[i], position);

			m_buildingButtons.Add(button);
		}
	}

	public void OnBuildingSelected(Building building)
	{
		SelectBuilding(building);
	}
}