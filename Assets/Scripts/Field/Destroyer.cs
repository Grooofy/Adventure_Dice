using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubeView cube))        
           cube.gameObject.SetActive(false);
    }
}