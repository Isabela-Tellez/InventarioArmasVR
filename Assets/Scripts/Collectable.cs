using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Collectable : MonoBehaviour
{
    [SerializeField] ActionBasedController _controller;
    [SerializeField] DataManager _data;
    [SerializeField] Item _item;

    public bool _isOver = false;

    private void Awake()
    {
        _controller.activateAction.action.started += Action_started;
    }

    private void Action_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_isOver) return;

        SlotInventory slot = _data.GetSlotByName(_item.Name);

        if (slot == null) 
            slot = new SlotInventory(_item);

        _data.AddItem(slot);
    }

    public void OnHoverEnter() { _isOver = true; }

    public void OnHoverExit() { _isOver = false; }
}
