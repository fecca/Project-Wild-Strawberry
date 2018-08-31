using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
	[Header("UI")]
	[SerializeField]
	private Text GoldText;

	public void OnPlayerResourcesUpdated(PlayerResources playerResources)
	{
		GoldText.text = Mathf.FloorToInt(playerResources.Gold).ToString();
	}
}