using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public GameObject   sfxAudioSource;
    public GameObject   sfxSwicthAudioSource;
    void Start()
    {
        playBGM();
    }

    private void playBGM()
    {
        bgmAudioSource.Play();
    }

    public void PlaySFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(sfxAudioSource, spawnPosition, Quaternion.identity);
    }

    public void PlaySFXSwitch(Vector3 spawnPosition)
    {
        GameObject.Instantiate(sfxSwicthAudioSource, spawnPosition, Quaternion.identity);
    }
}
