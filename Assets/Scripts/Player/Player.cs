using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<Dice> _dices;
    [SerializeField] private Figure _figure;
    [SerializeField] private int _turns;

    public event UnityAction<int> TurnsChanged;
    public event UnityAction TurnsEnded;

    private GameController _gameController;
    private Wallet _wallet;
    private CircleCollider2D _collider;

    private void OnEnable()
    {
        _figure.JumpingStopped += AllowNextMove;
        _figure.TakenCoin += TakeCoins;
        _figure.ChangedTurn += TakeTurn;
        _figure.TakenBonus += TakeBonus;
        _gameController.GameStarted += Move;
    }

    private void OnDisable()
    {
        _figure.JumpingStopped -= AllowNextMove;
        _figure.TakenCoin -= TakeCoins;
        _figure.ChangedTurn -= TakeTurn;
        _figure.TakenBonus -= TakeBonus;
        _gameController.GameStarted -= Move;
    }

    private void Awake()
    {
        _wallet = GetComponentInChildren<Wallet>();
        _collider = GetComponent<CircleCollider2D>();
        _gameController = GetComponent<GameController>();
    }

    private void Move()
    {
        _collider.enabled = false;

        foreach (var dice in _dices)
            dice.CalculateRoll();

        ReduceTurn();
    }

    private void AllowNextMove()
    {
        _collider.enabled = true;
    }

    private void ReduceTurn()
    {
        _turns--;
        TurnsChanged?.Invoke(_turns);
        
        FindHowManyTurns(_turns);
    }

    private void TakeBonus()
    {
        _wallet.DoubleCoins();
    }

    private void TakeCoins(int countCoin)
    {
        _wallet.AddCoins(countCoin);
    }

    private void TakeTurn(int turnsCount)
    {
        _turns += turnsCount;
        TurnsChanged?.Invoke(_turns);
        
        FindHowManyTurns(_turns);
    }

    private void FindHowManyTurns(int number)
    {
        if (number < 0)
            TurnsEnded?.Invoke();
    }
}