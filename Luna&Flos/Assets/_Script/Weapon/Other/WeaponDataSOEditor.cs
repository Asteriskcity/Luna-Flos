#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.Callbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    [CustomEditor(typeof(WeaponDataSO))]
    public class WeaponDataSOEditor : Editor
    {
        private static List<Type> dataCompTypes = new();

        private WeaponDataSO dataSO;

        private bool showUpdateButton;

        private void OnEnable()
        {
            dataSO = target as WeaponDataSO;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var dataCompType in dataCompTypes)
            {
                if (GUILayout.Button(dataCompType.Name))
                {
                    var comp = Activator.CreateInstance(dataCompType) as ComponentData;

                    if (comp == null)
                        return;

                    comp.InitializeAttackData(dataSO.NumberOfAttacks);

                    dataSO.AddData(comp);
                }
            }

            showUpdateButton = EditorGUILayout.Foldout(showUpdateButton, "Update!");

            if (showUpdateButton)
            {
                if (GUILayout.Button("Update Component Name"))
                {
                    foreach (var item in dataSO.ComponentDatas)
                    {
                        item.SetComponentName();
                    }
                }

                if (GUILayout.Button("Update AttackData Name"))
                {
                    foreach (var item in dataSO.ComponentDatas)
                    {
                        item.SetAttackDataName();
                    }
                }

            }

            if (GUILayout.Button("Set Number of Attacks"))
            {
                foreach (var item in dataSO.ComponentDatas)
                {
                    item.InitializeAttackData(dataSO.NumberOfAttacks);
                }
            }


        }

        [DidReloadScripts]
        private static void OnRecompile()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());
            var filteredTypes = types.Where(
                type => type.IsSubclassOf(typeof(ComponentData)) && !type.ContainsGenericParameters && type.IsClass
            );

            dataCompTypes = filteredTypes.ToList();
        }
    }
}
#endif