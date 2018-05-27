using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
	[SerializeField]
	private BuildingEvent OnBuildBuilding;
	[SerializeField]
	private Text Text;

	private Building m_building;

	public void Setup(Building building, Vector3 position)
	{
		m_building = building;
		Text.text = building.GetDisplayName();
		transform.name = building.GetDisplayName();
		transform.position = position;
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