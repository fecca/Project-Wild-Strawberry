using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class BuildingData : ScriptableObject
{
	public BuildingType Type;
	public string Name;
	public Image Icon;
	public float Cost;
	public float ConstructionTime;
}