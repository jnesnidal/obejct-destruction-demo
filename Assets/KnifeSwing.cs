using UnityEngine;
using System.Collections;

public class KnifeSwing : MonoBehaviour
{
    private bool isRotating = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRotating)
        {
            StartCoroutine(RotateY());
        }
    }

    private IEnumerator RotateY()
    {
        isRotating = true;

        // Phase 0: Pull back slightly (-35° to -45°) in 0.05 seconds
        float pullbackDuration = 0.05f;
        float pullbackElapsed = 0f;
        while (pullbackElapsed < pullbackDuration)
        {
            float t = pullbackElapsed / pullbackDuration;
            float angleY = Mathf.Lerp(-35f, -45f, t);
            transform.localRotation = Quaternion.Euler(0f, angleY, 0f);
            pullbackElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0f, -45f, 0f);

        // Phase 1: Fast slice forward (-45° to 35°) in 0.04 seconds
        float duration1 = 0.04f;
        float elapsed1 = 0f;
        while (elapsed1 < duration1)
        {
            float t = elapsed1 / duration1;
            float angleY = Mathf.Lerp(-45f, 35f, t);
            transform.localRotation = Quaternion.Euler(0f, angleY, 0f);
            elapsed1 += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0f, 35f, 0f);

        // Phase 2: Return swing (35° to -35°) in 0.31 seconds
        float duration2 = 0.31f;
        float elapsed2 = 0f;
        while (elapsed2 < duration2)
        {
            float t = elapsed2 / duration2;
            float angleY = Mathf.Lerp(35f, -35f, t);
            transform.localRotation = Quaternion.Euler(0f, angleY, 0f);
            elapsed2 += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0f, -35f, 0f);

        isRotating = false;
    }
}
