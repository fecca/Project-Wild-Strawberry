﻿using UnityEditor;

[CustomEditor(typeof(PlayerResources))]
public class PlayerResourcesEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		var playerResources = (PlayerResources)target;

		playerResources.Gold = EditorGUILayout.IntField("Gold", playerResources.Gold);
	}
}