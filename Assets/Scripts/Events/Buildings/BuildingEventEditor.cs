using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BuildingEvent))]
public class BuildingEventEditor : Editor
{
	private Building m_building;

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		m_building = (Building)EditorGUILayout.ObjectField("Building", m_building, typeof(Building), true);

		var myScript = (BuildingEvent)target;
		if (GUILayout.Button("Raise"))
		{
			if (m_building != null)
			{
				myScript.Raise(m_building);

				System.Reflection.Assembly assembly = typeof(EditorWindow).Assembly;
				EditorWindow.FocusWindowIfItsOpen(assembly.GetType("UnityEditor.GameView"));
			}
		}
	}
}