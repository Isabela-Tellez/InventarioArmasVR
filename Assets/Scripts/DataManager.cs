using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] Inventory _inventory;

#if UNITY_EDITOR

    public int GetInventoryCount()
    {
        int count = _inventory == null ? 0 : _inventory.slots.Count;
        return count;
    }

#endif

    public SlotInventory GetSlotByIndex(int index)
    {
#if UNITY_EDITOR

        if (_inventory == null)
        {
            Debug.Log("Repasa el gameObject con el script DataManager no hay inventario");
            return null;
        }

        if (_inventory.slots == null)
        {
            Debug.Log("Repasa el archivo inventario de la carpeta Data. Estará sin items");
            return null;
        }
#endif

        return _inventory.slots[index];
    }

    public SlotInventory GetSlotByName(string name)
    {
        for (int i = 0; i < _inventory.slots.Count; i++)
        {
            if (_inventory.slots[i].item == null) break;
            if (_inventory.slots[i].item.Name == name) return _inventory.slots[i];
        }

        return null;
    }

    public void InsertItemAtPosition(SlotInventory slot, int index) 
    {
        _inventory.slots[index] = slot;
    }

    public void AddItem(SlotInventory slot)
    {
        int index = -1;

        if (_inventory.slots.Contains(slot)) index = _inventory.slots.FindIndex(X => X.item.Name == slot.item.Name);

        if (index >= 0)
        {
            if (_inventory.slots[index].item.stackable)
            {
                _inventory.slots[index].amount++;
                return;
            }
        }
        AddItemAtEmptySlot(slot.item);
    }

    private void AddItemAtEmptySlot(Item item)
    {
        int index = -1;
        index = _inventory.slots.FindIndex(X => X.item == null);

        if (index >= 0)
        {
            _inventory.slots[index].item = item;
            _inventory.slots[index].amount = 1;
        }
    }

    public void RemoveItemAt(int index) 
    {
        _inventory.slots[index].amount--;
        if (_inventory.slots[index].amount == 0)
        {
            for (int i = 0; i < _inventory.slots.Count; i++)
            {
                MoveDownItemAtPosition(index);
            }
        }
    }

    public void MoveDownItemAtPosition(int index)
    {
        if (index + 1 >= _inventory.slots.Count || index < 0) return;

        _inventory.slots[index] = _inventory.slots[index + 1];
    }
}
