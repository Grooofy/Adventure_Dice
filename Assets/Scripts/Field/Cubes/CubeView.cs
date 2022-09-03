using UnityEngine;


public class CubeView : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private MeshRenderer _meshRenderer;

    private void Awake() => _meshRenderer = GetComponent<MeshRenderer>();

    private void Start() => _meshRenderer.material = _cube.Material;    
}