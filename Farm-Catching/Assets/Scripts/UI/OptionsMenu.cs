using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void FullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void Volume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
