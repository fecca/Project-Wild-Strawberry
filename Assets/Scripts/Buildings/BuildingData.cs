using UnityEngine;

[CreateAssetMenu]
public class BuildingData : ScriptableObject
{
	public BuildingType Type;
	public string Name;
	public Sprite Icon;
	public int Cost;
	public int ConstructionTime;
}