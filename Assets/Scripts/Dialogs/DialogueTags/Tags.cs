using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeakerTag))]
[RequireComponent(typeof(MethodTag))]
[RequireComponent(typeof(CooldownTag))]
[RequireComponent(typeof(TypingSoundTag))]
public class Tags : MonoBehaviour
{
    private  Dictionary<string, ITag> _map = new Dictionary<string, ITag>();

    private void Start()
    {
        _map.Add("speaker", GetComponent<SpeakerTag>());
        _map.Add("method", GetComponent<MethodTag>());
        _map.Add("cooldown", GetComponent<CooldownTag>());
        _map.Add("typingSound", GetComponent<TypingSoundTag>());
    }

    public ITag GetValue(string key) =>
        _map.GetValueOrDefault(key);
}