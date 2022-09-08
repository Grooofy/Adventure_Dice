using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraAnimation : MonoBehaviour
{
    [SerializeField] private DiceCheckZone _zone;

    private Animator _animator;

    private const string Play = "Play";

    private void OnEnable() => _zone.CheckingNumber += PlayAnimation;

    private void OnDisable() => _zone.CheckingNumber -= PlayAnimation;

    private void Awake() => _animator = GetComponent<Animator>();

    private void PlayAnimation() => _animator.SetTrigger(Play);
}