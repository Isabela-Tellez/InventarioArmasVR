using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Animals : MonoBehaviour
{
    public int value;
    public GameManager gameManager;
    AudioManager audioManager;

    private void Awake()
    {
        value = 1;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.animal);
            Destroy(gameObject);
        }
    }
}
