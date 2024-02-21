using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasEffect : MonoBehaviour
{
    public Image screenOverlay;
    public Color effectColor = Color.green;
    public float effectDuration = 1.0f;
    public Camera mainCamera;
    public AudioSource audioSource;
    private bool isShaking = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gas") && !isShaking)
        {
            StartCoroutine(TriggerEffect());
            audioSource.Play();
        }
    }

    private IEnumerator TriggerEffect()
    {
        isShaking = true;
        screenOverlay.color = effectColor;

        Vector3 originalPosition = mainCamera.transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < effectDuration)
        {
            float x = Random.Range(-0.2f, 0.2f);
            float y = Random.Range(-0.2f, 0.2f);
            mainCamera.transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        screenOverlay.color = new Color(effectColor.r, effectColor.g, effectColor.b, 0);
        mainCamera.transform.localPosition = originalPosition;
        isShaking = false;
    }
}