using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenericEvent))]
public class GenericEventEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		var myScript = (GenericEvent)target;
		if (GUILayout.Button("Raise"))
		{
			myScript.Raise();
		}
	}
}