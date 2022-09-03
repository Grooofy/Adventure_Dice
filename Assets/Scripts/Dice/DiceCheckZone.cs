using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DiceCheckZone : MonoBehaviour
{
    public event UnityAction<int> CheckedDice;

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
        if (_sides.Count == 2)
            FindOutNumbers();
    }

    private void FindOutNumbers()
    {
        _sumNumbers = _sides.Sum(side => side.Number);
        CheckedDice?.Invoke(_sumNumbers);
        _sumNumbers = 0;
        _sides.Clear();
    }

}