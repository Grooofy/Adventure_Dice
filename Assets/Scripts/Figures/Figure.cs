using System.Collections;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Events;
using static UnityEngine.Mathf;


[RequireComponent(typeof(SphereCollider))]
public class Figure : MonoBehaviour
{
    [SerializeField] private DiceCheckZone _checkZone;
    [SerializeField] private AudioSource _audioSource;
    
    public event UnityAction<int> ChangedDiceNumber;
    public event UnityAction<int> TakenCoin;
    public event UnityAction<int> ChangedTurn;
    public event UnityAction JumpingStopped;
    public event UnityAction TakenBonus;
    public event UnityAction Jumping;


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
        StartCoroutine(JumpIn(number));
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
            _audioSource.Play();
            transform.DOJump( new Vector3( transform.position.x + distance, transform.position.y, transform.position.z), _jumpForse, numJumps, duration);
            ChangedDiceNumber?.Invoke(number);
            number--;
            yield return new WaitForSeconds(duration);
        }
        
        _collider.enabled = true;
        JumpingStopped?.Invoke();
    }
}