using UnityEngine;


[CreateAssetMenu(fileName = "new DiceModel", menuName = "DiceModel", order = 52)]
public class DiceModel : ScriptableObject
{
    [SerializeField] private GameObject _diceModel;
    
    public GameObject Dice => _diceModel;
}
