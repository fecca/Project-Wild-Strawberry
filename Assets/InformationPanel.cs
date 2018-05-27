using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
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

	private Building m_building;

	private void Start()
	{
		ClearText();
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

	public void DisplayInformation(Building building)
	{
		ClearText();

		m_building = building;
	}
}
