using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] ButtonInventory[] _buttons;
    [SerializeField] Inventory _inventory;
    void Start()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_inventory.slots[i].item != null)
            {
                _buttons[i].Set(_inventory.slots[i].item.icon, _inventory.slots[i].amount.ToString());
            }
            else
            {
                _buttons[i].Clean();
            }
        }
    }
}
