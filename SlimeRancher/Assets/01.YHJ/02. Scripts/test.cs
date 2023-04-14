using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private FoodType foodType;
    [SerializeField] private FoodName foodName;

    private void OnGUI()
    {
        foodType = (FoodType)EditorGUILayout.EnumPopup("Food Type", foodType);
        foodName = (FoodName)EditorGUILayout.EnumPopup("Food Name", foodName);
    }
}

