using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public PlayerController player;
    void Update()
    {
        if (FindObjectOfType<GameManager>().isGameActive == false) 
        {
            return;
        }
        transform.Translate(Vector2.right * player.speed * Time.deltaTime);
    }
}
