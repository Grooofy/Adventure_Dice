using UnityEngine;

[CreateAssetMenu(fileName = "new Cube", menuName = "Cube", order = 51)]
public class Cube : ScriptableObject
{
    [SerializeField] private Material _material;

    public Material Material => _material;
  
}