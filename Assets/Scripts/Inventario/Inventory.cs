using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<SlotInventory> slots;
}
