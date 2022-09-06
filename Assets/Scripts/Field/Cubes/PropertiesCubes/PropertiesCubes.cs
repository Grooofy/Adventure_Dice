using UnityEngine;

public class PropertiesCubes : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private AudioSource _audioSource;

    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _audioSource = GetComponentInChildren<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Figure figure) == false) return;
        _audioSource.Play();
        _particleSystem.Play();
        UseCube(figure);
    }

    protected virtual void UseCube(Figure figure) { }
}
