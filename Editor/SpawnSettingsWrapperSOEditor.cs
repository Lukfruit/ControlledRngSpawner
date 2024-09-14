// using UnityEngine;
// using UnityEditor;
// using System.Collections.Generic;
//
// [CustomEditor(typeof(SpawnSettingsWrapperSO))]
// public class SpawnSettingsWrapperSOEditor //: Editor
// {
//     private SpawnSettingsWrapperSO spawnSettingsWrapper;
//     private SerializedProperty spawnSettingsProperty;
//     private SerializedProperty radiusProperty;
//     private List<string> mobTypeNames;
//
//     private void OnEnable()
//     {
//         spawnSettingsWrapper = (SpawnSettingsWrapperSO)target;
//         spawnSettingsProperty = serializedObject.FindProperty("spawnSettings");
//         radiusProperty = spawnSettingsProperty.FindPropertyRelative("Radius");
//
//         mobTypeNames = new List<string>(System.Enum.GetNames(typeof(MobType)));
//     }
//
//     public override void OnInspectorGUI()
//     {
//         serializedObject.Update();
//
//         EditorGUILayout.PropertyField(radiusProperty);
//
//         EditorGUILayout.LabelField("Mob Type Amounts", EditorStyles.boldLabel);
//
//         if (spawnSettingsWrapper.spawnSettings.MobTypeAmount == null)
//         {
//             spawnSettingsWrapper.spawnSettings.MobTypeAmount = new Dictionary<MobType, int>();
//         }
//
//         foreach (string mobTypeName in mobTypeNames)
//         {
//             MobType mobType = (MobType)System.Enum.Parse(typeof(MobType), mobTypeName);
//             int amount = spawnSettingsWrapper.spawnSettings.MobTypeAmount.ContainsKey(mobType) 
//                 ? spawnSettingsWrapper.spawnSettings.MobTypeAmount[mobType] 
//                 : 0;
//
//             int newAmount = EditorGUILayout.IntField(mobTypeName, amount);
//
//             if (newAmount != amount)
//             {
//                 spawnSettingsWrapper.spawnSettings.MobTypeAmount[mobType] = newAmount;
//                 EditorUtility.SetDirty(target);
//             }
//         }
//
//         serializedObject.ApplyModifiedProperties();
//     }
// }