using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
#if UNITY_EDITOR
    void Start()
    {
        transform.localPosition = Vector3.up * 1.7f;
    }

#endif
}
