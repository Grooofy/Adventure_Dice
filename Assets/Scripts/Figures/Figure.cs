using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;


[RequireComponent(typeof(SphereCollider))]
public class Figure : MonoBehaviour
{
    [SerializeField] private DiceCheckZone _checkZone;
    
    public event UnityAction<int> ChangedDiceNumber;
    public event UnityAction<int> TakenCoin;
    public event UnityAction<int> ChangedTurn;
    public event UnityAction JumpingStopped;
    public event UnityAction TakenBonus;
    public event UnityAction Jumping;


    private Coroutine _jumping;
    private SphereCollider _collider;
    private float _jumpForse = 1;
    
    private void OnEnable()
    {
        _checkZone.CheckedDice += Jump;
    }
    
    private void OnDisable()
    {
        _checkZone.CheckedDice -= Jump;
    }
    
    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
    }
    
    private void Jump(int number)
    {
        _collider.enabled = false;
        
        if (_jumping == null)
        {
            _jumping = StartCoroutine(JumpIn(number));
            _jumping = null;
        }
        else
        {
            StopCoroutine(_jumping);
        }
       
    }

    public void TakeCoins(int coinCount)
    {
        TakenCoin?.Invoke(coinCount);
    }

    public void TakeBonus()
    {
        TakenBonus?.Invoke();
    }

    public void ChangeTurns(int countTurns)
    {
        ChangedTurn?.Invoke(countTurns);
    }

    private IEnumerator JumpIn(int number)
    {
        float duration = 0.5f;
        float distance = 1.5f;
        int numJumps = 1;

        while (number > 0)
        {
            Jumping?.Invoke();
            transform.DOJump(transform.position + Vector3.right * distance, _jumpForse, numJumps, duration);
            ChangedDiceNumber?.Invoke(number);
            yield return new WaitForSeconds(duration);
            number--;
        }

        _collider.enabled = true;
        JumpingStopped?.Invoke();
    }
}