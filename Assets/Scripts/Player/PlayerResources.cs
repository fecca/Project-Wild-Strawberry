using UnityEngine;

[CreateAssetMenu]
public class PlayerResources : ScriptableObject
{
	public PlayerResourcesEvent OnPlayerResourcesChanged;
	public FloatReference StartingGold;

	[SerializeField]
	[HideInInspector]
	private float m_gold;

	public float Gold
	{
		get { return m_gold; }
		set
		{
			m_gold = value;
			OnPlayerResourcesChanged.Raise(this);
		}
	}
}