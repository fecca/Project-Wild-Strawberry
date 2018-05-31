using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
	[SerializeField]
	private Text GoldText;

	public void UpdateResources(PlayerResources playerResources)
	{
		GoldText.text = Mathf.FloorToInt(playerResources.Gold).ToString();
	}
}