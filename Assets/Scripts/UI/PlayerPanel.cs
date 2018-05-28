using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
	[SerializeField]
	private PlayerResources PlayerResources;
	[SerializeField]
	private Text GoldText;

	private void Start()
	{
		UpdateResources();
	}

	public void UpdateResources()
	{
		GoldText.text = string.Format("Gold: {0}", PlayerResources.Gold);
	}
}
