using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 5f;

    public AudioSource EarthquakeSound;

    [SerializeField]
    private GameObject earthquakeText;

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking(){
        Vector3 startPosition = transform.localPosition;
        float elapsedTime = 0f;
        earthquakeText.SetActive(true);
        EarthquakeSound.Play();

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/duration);
            transform.localPosition = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        earthquakeText.SetActive(false);


        transform.localPosition = startPosition;
    }
}
