using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
	[SerializeField]
	private Button Button;
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
		transform.name = building.DisplayName;
		//transform.position = position;
		GetComponent<RectTransform>().position += position;
		//GetComponent<RectTransform>().ForceUpdateRectTransforms();
		Image.sprite = building.Icon;
		Name.text = string.Format("{0}", building.DisplayName);
		CostText.text = string.Format("{0}g", building.Cost);
		TimeText.text = string.Format("{0}s", building.ConstructionTime);
		gameObject.SetActive(true);
	}

	public void Click()
	{
		EventManager.TriggerEvent(BuildingEventType.ButtonPress, m_building);
	}
}