using UnityEngine;

[CreateAssetMenu]
public class BuildingData : ScriptableObject
{
	public BuildingType Type;
	public float TickValue;
	public ColliderData ColliderData;
	public string Name;
	public Sprite Icon;
	public int Cost;
	public int ConstructionTime;
	public ContextMenuData ContextData;
}