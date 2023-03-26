using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ControllerCreateWindow : EditorWindow
{
    Texture icon;
    Object playerModel;

    [MenuItem("Window/CharacterControllerCreate")]
    public static void ShowWindow()
    {
        GetWindow<ControllerCreateWindow>("Create Character Controller");
    }
    private void OnGUI()
    {
        EditorGUILayout.Space();
        GUILayout.BeginHorizontal();
        GUILayout.Space(Screen.width / 8);
        Texture banner = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Editor/Icon/ccbanner.png", typeof(Texture));
        GUILayout.Box(banner);
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Player Object");
        playerModel = EditorGUILayout.ObjectField(playerModel,typeof(Object),true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        EditorGUILayout.HelpBox("After creating the character, you have to add the joystick object to the Player Controller script.", MessageType.Info);

        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Create!"))
        {
            CharacterCreator.CreateCharacter(playerModel);
        }
        EditorGUILayout.EndHorizontal();
    }
}
