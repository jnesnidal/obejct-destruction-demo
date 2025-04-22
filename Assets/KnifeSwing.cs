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

        // Phase 1: -35 to 35 in 0.04 seconds
        float duration1 = 0.04f;
        float elapsed1 = 0f;
        while (elapsed1 < duration1)
        {
            float t = elapsed1 / duration1;
            float angleY = Mathf.Lerp(-35f, 35f, t);
            transform.localRotation = Quaternion.Euler(0f, angleY, 0f);
            elapsed1 += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0f, 35f, 0f);

        // Phase 2: 35 to -35 in 0.36 seconds
        float duration2 = 0.36f;
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
