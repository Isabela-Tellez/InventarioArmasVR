using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ManagerControllers : MonoBehaviour
{
    [SerializeField] ActionBasedController _controller, _controllerTeleport;
    [SerializeField] GameObject _controllerGameObject, _controllerTeleportGameObject, visibleObjectWithGripPressed;
    void Start()
    {
        _controller.selectAction.action.started += Action_started;
        _controllerTeleport.selectAction.action.canceled += Action_canceled;
    }

    private void Action_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _controllerTeleportGameObject.SetActive(false);
        _controllerGameObject.SetActive(true);

        if (visibleObjectWithGripPressed != null)
            visibleObjectWithGripPressed.SetActive(false);
    }

    private void Action_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _controllerGameObject.SetActive(false);
        _controllerTeleportGameObject.SetActive(true);

        if (visibleObjectWithGripPressed != null)
        visibleObjectWithGripPressed.SetActive(true);
    }
}
