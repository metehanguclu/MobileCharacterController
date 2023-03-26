using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    public static void CreateCharacter(Object player)
    {
        if (player)
        {
            GameObject temp = Instantiate((GameObject)player);
            temp.transform.position = Vector3.zero;
            temp.AddComponent<CharacterController>();
            temp.AddComponent<PlayerController>();
            temp.AddComponent<Animator>();
        }
    }
}
