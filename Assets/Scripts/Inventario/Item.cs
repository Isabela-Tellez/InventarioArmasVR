using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item/New Item")]
public class Item : ScriptableObject
{
    public string Name => name;
    public string description;

    public bool stackable;

    public Sprite icon;
    public GameObject prefab;
}
