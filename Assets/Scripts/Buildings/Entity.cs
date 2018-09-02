using UnityEngine;

public abstract class Entity : MonoBehaviour
{
	[SerializeField]
	private ButtonData ButtonData;
	[SerializeField]
	private Entity[] MenuItems;
	[SerializeField]
	private GameObject SelectionSphere;

	public string Name { get { return ButtonData.Name; } }
	public int Cost { get { return ButtonData.Cost; } }
	public int ConstructionTime { get { return ButtonData.ConstructionTime; } }
	public Sprite Icon { get { return ButtonData.Icon; } }

	public abstract void Click();
	public abstract void TriggerButtonPress(Entity entity);

	public Entity[] GetMenuItems()
	{
		return MenuItems;
	}

	public void Select(bool select)
	{
		SelectionSphere.SetActive(select);
	}
}