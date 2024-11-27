using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour
{
    private float _minTimeBeforeDisappear = 2f;
    private float _maxTimeBeforeDisappear = 5f;
    private float _deltaTimeInSeconds = 1f;

    private WaitForSecondsRealtime _wait;

    private void Awake()
    {
        _wait = new WaitForSecondsRealtime(_deltaTimeInSeconds);
    }

    public void StartCounting(Action onComplete)
    {
        StartCoroutine(Count(onComplete));
    }

    private IEnumerator Count(Action onComplete)
    {
        float timeBeforeDisappear = UnityEngine.Random.Range(_minTimeBeforeDisappear, _maxTimeBeforeDisappear + 1f);

        while (timeBeforeDisappear > 0f)
        {
            timeBeforeDisappear -= _deltaTimeInSeconds;

            yield return _wait;
        }

        onComplete?.Invoke();
    }
}