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

	public void UpdateText(Building building)
	{
		TypeText.text = string.Format("Type: {0}", building.GetDisplayName());
		DisplayNameText.text = string.Format("Name: {0}", building.GetDisplayName());
		CostText.text = string.Format("Cost: {0}", building.GetCost());
		ConstructionTimeText.text = string.Format("Construction time: {0}", building.GetConstructionTime());
	}
}
