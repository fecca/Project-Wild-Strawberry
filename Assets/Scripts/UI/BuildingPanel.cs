using System.Collections.Generic;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
	[SerializeField]
	private MenuButton MenuButtonPrefab;

	private List<MenuButton> m_buttons = new List<MenuButton>();
	private Entity m_activeEntity;

	private void CreateButtons(Entity[] menuItems)
	{
		for (var i = 0; i < menuItems.Length; i++)
		{
			var button = Instantiate(MenuButtonPrefab, transform) as MenuButton;
			var position = new Vector3 { x = 20 + (i * 100), z = 0, y = 0 };
			button.Setup(OnButtonClicked, menuItems[i], position);

			m_buttons.Add(button);
		}
	}

	private void DestroyButtons()
	{
		foreach (var button in m_buttons)
		{
			Destroy(button.gameObject);
		}
		m_buttons.Clear();
	}

	private void OnButtonClicked(Entity clickedEntity)
	{
		m_activeEntity.TriggerButtonPress(clickedEntity);
	}

	public void OnEntityClicked(Entity entity)
	{
		m_activeEntity = entity;
		DestroyButtons();
		CreateButtons(entity.GetMenuItems());
	}
}