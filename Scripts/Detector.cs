using System;
using System.Collections;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private Siren _siren;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _siren.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _siren.Stop();
        }
    }
}
