using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private const float Duration = 0.5f;

    private WaitForSeconds _durationTime = new WaitForSeconds(Duration);

    private float _distance = 1.5f;
    private float _jumpForse = 1;
       
    public IEnumerator JumpIn(int number, UnityAction jumping, UnityAction<int> changedDiceNumber, UnityAction jumpingStopped, SphereCollider collider)
    {
        int numJumps = 1;

        while (number > 0)
        {
            jumping?.Invoke();
            _audioSource.Play();
            transform.DOJump(new Vector3(transform.position.x + _distance, transform.position.y, transform.position.z), _jumpForse, numJumps, Duration);
            changedDiceNumber?.Invoke(number);
            number--;
            yield return _durationTime;
        }

        collider.enabled = true;
        jumpingStopped?.Invoke();
    }
}
