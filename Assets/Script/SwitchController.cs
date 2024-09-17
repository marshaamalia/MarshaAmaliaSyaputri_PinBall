using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.VFX;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;
    public float score;

    public ScoreManager scoreManager;

    private SwitchState state;
    private Renderer renderer;

    public float multiplier;
    public VFXManager vfxManager;
    public AudioManager audioManager;

    private void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toogle();

            //playsfx
            audioManager.PlaySFXSwitch(other.transform.position);

            //playvfx
            vfxManager.PlayVFX(other.transform.position);

            //score add
            scoreManager.AddScore(score);
        }
    }

    private void Set(bool active)
    {
        if (active == true) 
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;

            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toogle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }

    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
