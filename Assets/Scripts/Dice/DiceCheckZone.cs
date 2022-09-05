using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DiceCheckZone : MonoBehaviour
{
    public event UnityAction<int> CheckedDice;
    public event UnityAction CheckingNumber;

    private readonly List<Side> _sides = new List<Side>();
    private int _sumNumbers;
        

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Side side))
            _sides.Add(side);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Side side))
            _sides.Remove(side);
    }

    private void Update()
    {
        if (_sides.Count > 1)
            FindOutNumbers();
    }

    private void FindOutNumbers()
    {
        if (CheckNumbers(_sides))
            CheckingNumber?.Invoke();
        
        _sumNumbers = _sides.Sum(side => side.Number);
        _sides.Clear();
        CheckedDice?.Invoke(_sumNumbers);
        _sumNumbers = 0;
        gameObject.SetActive(false);
    }

    private bool CheckNumbers(List<Side> sides)
    {
        return sides[0].Number == sides[1].Number;
    }

}