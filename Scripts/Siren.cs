using System.Collections;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _increaseCoroutine;
    private float _increaseValue = 0.2f;
    private float _reductionValue = -0.2f;
    private float _value = 0;

    public void Play()
    {
        _value = _increaseValue;

        if (_increaseCoroutine == null)
        {
            _increaseCoroutine = StartCoroutine(SmoothlyChangeVolume());
        }
    }

    public void Stop()
    {
        _value = _reductionValue;
    }

    private IEnumerator SmoothlyChangeVolume()
    {
        float minValue = 0f;
        float volumeChangeRate = 1f;
        var waitForOneSecond = new WaitForSeconds(volumeChangeRate);

        _audioSource.Play();
        _audioSource.volume = 0.1f;

        while (_audioSource.volume > minValue)
        {
            _audioSource.volume += _value;
            yield return waitForOneSecond;
        }

        _increaseCoroutine = null;
    }
}
