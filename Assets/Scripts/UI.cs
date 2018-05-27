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
			var button = Instantiate(BuildingButtonTemplate, transform) as BuildingButton;
			button.Setup(AllBuildings.Value[i], BuildingButtonTemplate.transform.position + Vector3.up * (40 * i));
		}
	}
}