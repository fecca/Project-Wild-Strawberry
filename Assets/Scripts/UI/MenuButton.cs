using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
	[SerializeField]
	private Image Image;
	[SerializeField]
	private Text Name;
	[SerializeField]
	private Text CostText;
	[SerializeField]
	private Text TimeText;

	private Entity m_menuItem;
	private Action<Entity> m_onClick;

	public void Setup(Action<Entity> onClick, Entity menuItem, Vector3 position)
	{
		m_onClick = onClick;
		m_menuItem = menuItem;

		transform.name = menuItem.Name;
		GetComponent<RectTransform>().position += position;
		Image.sprite = menuItem.Icon;
		Name.text = string.Format("{0}", menuItem.Name);
		CostText.text = string.Format("{0}g", menuItem.Cost);
		TimeText.text = string.Format("{0}s", menuItem.ConstructionTime);
		gameObject.SetActive(true);
	}

	public void Click()
	{
		m_onClick(m_menuItem);
		//m_menuItem.TriggerButtonPress();
	}
}