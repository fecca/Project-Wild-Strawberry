using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class PlayerResources : ScriptableObject
{
	public GenericEvent OnPlayerResourcesChanged;

	private int m_gold;
	public int Gold
	{
		get { return m_gold; }
		set
		{
			m_gold = value;
			OnPlayerResourcesChanged.Raise();
		}
	}
}

[CustomEditor(typeof(PlayerResources))]
public class PlayerDataEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		var customType = (PlayerResources)target;

		customType.Gold = EditorGUILayout.IntField("Gold", customType.Gold);
	}
}