using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Data/Weapon/Basic Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private int _numberOfAttacks;
    [SerializeReference] private List<ComponentData> _componentData;

    public int NumberOfAttacks => _numberOfAttacks;
    public List<ComponentData> ComponentData => _componentData;

    public void AddData(ComponentData data)
    {
        if (ComponentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
            return;

        ComponentData.Add(data);
    }
 
    public T GetData<T>() =>
        ComponentData.OfType<T>().FirstOrDefault();
}