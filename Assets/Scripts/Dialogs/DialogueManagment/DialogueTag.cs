using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tags))]
public class DialogueTag : MonoBehaviour
{
    private Tags _tags;

    public void Init()
    {
        _tags = GetComponent<Tags>();
    }

    public void HandleTags(List<string> tags)
    {
        if (tags.Count == 0)
            return;

        foreach (var taValueg in tags)
        {
            string[] keyTag = taValueg.Split(":");

            if (keyTag.Length != 2)
                throw new ArgumentException($"������������ ���������� ���� {keyTag[0]}, {keyTag[1]}");

            string key = keyTag[0].Trim();
            string value = keyTag[1].Trim();

            _tags.GetValue(key).Calling(value);
        }
    }
}
