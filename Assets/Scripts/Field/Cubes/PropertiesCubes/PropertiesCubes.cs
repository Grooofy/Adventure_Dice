using UnityEngine;

public class PropertiesCubes : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Figure figure) == false) return;
        _audioSource.Play();
        _particleSystem.Play();
        UseCube(figure);
    }

    protected virtual void UseCube(Figure figure) { }
}
