using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.TerrainTools;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(WeaponData))]
public class WeaponDataEditor : Editor
{
    private static List<Type> _dataComponentTypes = new List<Type>();

    private WeaponData _data;

    private void OnEnable() =>
        _data = target as WeaponData;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        foreach (var dataCompType in _dataComponentTypes)
        {
            if (GUILayout.Button(dataCompType.Name))
            {
                var comp = Activator.CreateInstance(dataCompType) as ComponentData;

                if (comp == null)
                    return;

                _data.AddData(comp);
            }
        }

        if (GUILayout.Button("Force Update Component Names"))
        {
            foreach (var item in _data.ComponentData)
            {
                item.SetComponentName();
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
        _dataComponentTypes = filteredTypes.ToList();
    }
}