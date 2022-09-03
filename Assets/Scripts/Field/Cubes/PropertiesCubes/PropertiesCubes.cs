using UnityEngine;

public class PropertiesCubes : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Figure figure) == false) return;
        _particleSystem.Play();
        UseCube(figure);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Figure figure))
            UseCube(figure);
    }

    protected virtual void UseCube(Figure figure) { }
}
