using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class DiceNumber : MonoBehaviour
{
    [SerializeField] private Figure _figure; 
    
    private TMP_Text _tmp;

    private void OnEnable()
    {
        _figure.ChangedDiceNumber += ShowNumber;
        _figure.JumpingStopped += HideNumber;
    }

    private void OnDisable()
    {
        _figure.ChangedDiceNumber -= ShowNumber;
        _figure.JumpingStopped -= HideNumber;
    }

    private void Awake() => _tmp = GetComponent<TMP_Text>();

    private void Start() => _tmp.text = "Tap to Play";

    private void ShowNumber(int number)
    {
        _tmp.enabled = true;
        _tmp.text = number.ToString();
    }

    private void HideNumber()
    {
        _tmp.enabled = false;
    }
}
