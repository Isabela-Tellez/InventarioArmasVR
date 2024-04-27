using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool dirRight = true;
    private float timer;

    void Update()
    {
        if (dirRight) //Si es true va a la derecha
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            
        }
        else //Si es false va a la izquierda
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if (timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
