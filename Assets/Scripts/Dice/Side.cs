using UnityEngine;

public class Side : MonoBehaviour
{
    [SerializeField] private int _number;

    public int Number => _number;
}