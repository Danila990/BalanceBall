using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerGameOver : MonoBehaviour
{
    [SerializeField] private float _timeToRespawn = 1;

	private Vector3 _startSpawnPoint;
    private Rigidbody _rb;
    private AudioManager _audioManager;

    [Inject]
    private void Construct(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }
    private void Start()
    {
        _rb = GetComponentInChildren<Rigidbody>();
        _startSpawnPoint = transform.parent.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 4)
        {
            _audioManager.PlayPlayerWaterSound();
            StartCoroutine(PlayWaterSound());
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
            StopAllCoroutines();
    }

    private IEnumerator PlayWaterSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToRespawn);
            transform.position = _startSpawnPoint;
            _rb.velocity = Vector3.zero;
        }
    }
}
