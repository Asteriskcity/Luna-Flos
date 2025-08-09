using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Guagua.WeaponSystem;

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Base Weapon Data", order = 0)]

public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public RuntimeAnimatorController AnimatorController { get; private set; }

    [field: SerializeField] public int NumberOfAttacks { get; private set; }

    [field: SerializeReference] public List<ComponentData> ComponentDatas { get; private set; }

    public T GetData<T>()
    {
        return ComponentDatas.OfType<T>().FirstOrDefault();
    }

    public List<Type> GetAllDependencies()
    {
        return ComponentDatas.Select(component => component.ComponentDependency).ToList();
    }

    public void AddData(ComponentData data)
    {
        if (ComponentDatas.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
            return;

        ComponentDatas.Add(data);
    }


}
