using UnityEngine;
using Random = UnityEngine.Random;

public class Rotator : MonoBehaviour
{
    private float _speed;

    private void Start() => SetRandomSpeed();

    private void Update() => transform.Rotate(Vector3.up, _speed * Time.deltaTime);

    private void SetRandomSpeed()
    {
        int minValue = 6;
        int maxValue = 15;
        
        _speed = Random.Range(minValue, maxValue);
    }
}