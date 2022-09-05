using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField] private List<DiceModel> _models;
    [SerializeField] private AudioSource _audioSource;

    private Rigidbody _rigidbody;
    private Vector3 _startPoint;


    private const float _powerThrow = 500f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    } 
       

    private void Start()
    {
        CreateModel();
        _startPoint = transform.position;
    }

    public void CalculateRoll()
    {
        transform.position = _startPoint;
        transform.rotation = Quaternion.identity;

        _rigidbody.AddForce(Vector3.up * _powerThrow);
        _rigidbody.AddTorque(CreateRandomDirection());
    }

    private Vector3 CreateRandomDirection()
    {
        const float maxValue = 501;
        float directionX = Random.Range(0, maxValue);
        float directionY = Random.Range(0, maxValue);
        float directionZ = Random.Range(0, maxValue);

        return new Vector3(directionX, directionY, directionZ);
    }

    private void CreateModel()
    {
        Instantiate(_models[0].Dice, transform.position, transform.rotation, transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == null) return;
        _audioSource.Play();
    }
}