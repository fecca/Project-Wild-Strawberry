using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
	[SerializeField]
	private Text GoldText;

	public void UpdateResources(PlayerResources playerResources)
	{
		GoldText.text = string.Format("Gold: {0}", Mathf.FloorToInt(playerResources.Gold));
	}
}