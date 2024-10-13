using System;
using UnityEngine;

[Serializable]
public class ComponentData
{
    [SerializeField, HideInInspector] private string _name;

    public void SetComponentName() => 
        _name = GetType().Name;
}