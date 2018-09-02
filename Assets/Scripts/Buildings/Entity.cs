using UnityEngine;

public abstract class Entity : MonoBehaviour, IInteractable
{
	[SerializeField]
	private ButtonData ButtonData;
	[SerializeField]
	private Entity[] MenuItems;

	public string Name { get { return ButtonData.Name; } }
	public int Cost { get { return ButtonData.Cost; } }
	public int ConstructionTime { get { return ButtonData.ConstructionTime; } }
	public Sprite Icon { get { return ButtonData.Icon; } }

	public abstract void Click();
	public abstract void TriggerButtonPress(Entity entity);
	//public abstract void ConstructEntity(Entity entity);

	public Entity[] GetMenuItems()
	{
		return MenuItems;
	}
}