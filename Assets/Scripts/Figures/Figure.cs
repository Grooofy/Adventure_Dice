using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Mover))]
public class Figure : MonoBehaviour
{
    [SerializeField] private DiceCheckZone _checkZone;

    public event UnityAction<int> ChangedDiceNumber;
    public event UnityAction<int> TakenCoin;
    public event UnityAction<int> ChangedTurn;
    public event UnityAction Jumping;
    public event UnityAction TakenBonus;
    public event UnityAction JumpingStopped;

    private Coroutine _jumping;
    private SphereCollider _collider;
    private Mover _mover;

    private void OnEnable()
    {
         _mover = GetComponent<Mover>();
        _checkZone.CheckedDice += Jump;
    }

    private void OnDisable() => _checkZone.CheckedDice -= Jump;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
    }

    public void TakeCoins(int coinCount) => TakenCoin?.Invoke(coinCount);

    public void TakeBonus() => TakenBonus?.Invoke();

    public void ChangeTurns(int countTurns) => ChangedTurn?.Invoke(countTurns);

    private void Jump(int number)
    {
        _collider.enabled = false;

        if (_jumping != null)
            StopCoroutine(_jumping);

        _jumping = StartCoroutine(_mover.JumpIn(number, Jumping, ChangedDiceNumber, JumpingStopped, _collider));
    }
}