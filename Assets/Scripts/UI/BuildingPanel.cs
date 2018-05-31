using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanel : MonoBehaviour
{
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
	private BuildingsVariable AllBuildings;
	[SerializeField]
	private BuildingButton BuildingButtonPrefab;
	[SerializeField]
	private BuildingButtonValidator BuildingButtonValidator;

	private List<BuildingButton> m_buildingButtons = new List<BuildingButton>();
	private Building m_building;

	private void Start()
	{
		ClearText();
		CreateButtons();
	}

	private void Update()
	{
		if (m_building != null)
		{
			TypeText.text = string.Format("Type: {0}", m_building.GetDisplayName());
			DisplayNameText.text = string.Format("Name: {0}", m_building.GetDisplayName());
			CostText.text = string.Format("Cost: {0}", m_building.GetCost());
			ConstructionTimeText.text = string.Format("Construction time: {0}", m_building.GetConstructionTime());
			State.text = string.Format("State: {0}", m_building.GetState());
		}
	}

	private void ClearText()
	{
		TypeText.text = string.Empty;
		DisplayNameText.text = string.Empty;
		CostText.text = string.Empty;
		ConstructionTimeText.text = string.Empty;
		State.text = string.Empty;
	}

	public void CreateButtons()
	{
		if (BuildingButtonPrefab == null) { return; }
		if (AllBuildings == null) { return; }

		for (var i = AllBuildings.Value.Count - 1; i >= 0; i--)
		{
			var button = Instantiate(BuildingButtonPrefab, transform) as BuildingButton;
			var position = new Vector3
			{
				x = transform.position.x + 20 + (i / 2 * 100),
				z = transform.position.z,
				y = transform.position.y + 10 + (i % 2 * 90)
			};
			button.Setup(AllBuildings.Value[i], BuildingButtonValidator, position);

			m_buildingButtons.Add(button);
		}
	}

	public void UpdateButtons(PlayerResources playerResources)
	{
		foreach (var button in m_buildingButtons)
		{
			button.UpdateVisibility(playerResources);
		}
	}

	public void DisplayInformation(Building building)
	{
		ClearText();

		m_building = building;
	}
}