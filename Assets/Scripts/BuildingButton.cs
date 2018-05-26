using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
	[SerializeField]
	private BuildingEvent OnBuildingSelected;
	[SerializeField]
	private Text Text;

	private Building m_building;

	public void SetText(string text)
	{
		Text.text = text;
		transform.name = text;
	}

	public void SetPosition(Vector3 position)
	{
		transform.position += position;
	}

	public void SetBuildingReference(Building building)
	{
		m_building = building;
	}

	public void Click()
	{
		if (m_building != null)
		{
			OnBuildingSelected.Raise(m_building);
		}
	}
}