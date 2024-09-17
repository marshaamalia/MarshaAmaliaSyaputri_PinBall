using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject vfxAudioSource;
    public GameObject vfxAudioSwitch;

    public void PlayVFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxAudioSource, spawnPosition, Quaternion.identity);
    }

    public void PlayVFXSWitch(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxAudioSwitch, spawnPosition, Quaternion.identity);
    }
}
