using UnityEngine;

[CreateAssetMenu]
public class PlayerResources : ScriptableObject
{
	public PlayerResourcesEvent OnPlayerResourcesChanged;

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

	public FloatReference StartingGold;
}