using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public void Shake(float duration = 0.5f, float magnitude = 0.15f, float wait = 0) {
        StartCoroutine(ShakeNumerator(duration, magnitude, wait));
    }

    private IEnumerator ShakeNumerator(float duration, float magnitude, float wait) {
        if (wait != 0) yield return new WaitForSeconds(wait);

        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}