using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Model : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string AnimationTrigger = "Jump";

    private Figure _figure;

    private void OnEnable()
    {
        _figure = GetComponentInParent<Figure>();
        _figure.Jumping += PlayAnimation;
    }

    private void OnDisable()
    {
        _figure.Jumping -= PlayAnimation;
    }
    
    //private void Awake() => _animator = GetComponent<Animator>();

    private void PlayAnimation() => _animator.SetTrigger(AnimationTrigger);
}