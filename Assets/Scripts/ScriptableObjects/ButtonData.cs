using UnityEngine;

[CreateAssetMenu]
public class ButtonData : ScriptableObject
{
	public string Name;
	public Sprite Icon;
	public int Cost;
	public int ConstructionTime;
}