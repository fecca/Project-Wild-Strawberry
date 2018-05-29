using System.Collections.Generic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
	[SerializeField]
	private BuildingsVariable AllBuildings;
	[SerializeField]
	private BuildingButton BuildingButtonPrefab;

	private List<BuildingButton> m_buildingButtons = new List<BuildingButton>();

	private void Start()
	{
		CreateButtons();
	}

	public void CreateButtons()
	{
		if (BuildingButtonPrefab == null) { return; }
		if (AllBuildings == null) { return; }

		for (var i = AllBuildings.Value.Count - 1; i >= 0; i--)
		{
			var button = Instantiate(BuildingButtonPrefab, transform) as BuildingButton;
			button.Setup(AllBuildings.Value[i], BuildingButtonPrefab.transform.position + Vector3.up * (74 * i));
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
}