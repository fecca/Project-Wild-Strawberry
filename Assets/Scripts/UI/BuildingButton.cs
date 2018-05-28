using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
	[SerializeField]
	private BuildingEvent OnBuildBuilding;
	[SerializeField]
	private Image Image;
	[SerializeField]
	private Text Name;
	[SerializeField]
	private Text CostText;
	[SerializeField]
	private Text TimeText;

	private Building m_building;

	public void Setup(Building building, Vector3 position)
	{
		m_building = building;
		transform.name = building.GetDisplayName();
		transform.position = position;
		Image.sprite = building.GetIcon();
		Name.text = string.Format("{0}", building.GetDisplayName());
		CostText.text = string.Format("{0}g", building.GetCost());
		TimeText.text = string.Format("{0}s", building.GetConstructionTime());
		gameObject.SetActive(true);
	}

	public void Click()
	{
		if (m_building != null)
		{
			OnBuildBuilding.Raise(m_building);
		}
	}
}