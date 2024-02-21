using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    public Light pointLight;
    public AudioSource audioSource;
    public AudioClip glitchSound;
    private float glitchDuration = 1.437f;
    private float repeatTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlickerWithSound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FlickerWithSound()
    {
        while (true)
        {
            audioSource.clip = glitchSound;
            audioSource.Play();

            for (int i = 0; i < 3; i++)
            {
                pointLight.enabled = !pointLight.enabled;
                yield return new WaitForSeconds(glitchDuration / 3);
                pointLight.enabled = !pointLight.enabled;
                yield return new WaitForSeconds(glitchDuration / 3);
            }
            yield return new WaitForSeconds(repeatTime - glitchDuration);
        }
    }
}
