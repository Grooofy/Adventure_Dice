using UnityEngine;

public class Model : MonoBehaviour
{
    private const string AnimationTrigger = "Jump";

    private Figure _figure;
    private Animator _animator;

    private void OnEnable()
    {
        _figure = GetComponentInParent<Figure>();
        _figure.Jumping += PlayAnimation;
    }

    private void OnDisable()
    {
        _figure.Jumping -= PlayAnimation;
    }
    
    private void Awake() => _animator = GetComponent<Animator>();

    private void PlayAnimation() => _animator.SetTrigger(AnimationTrigger);
}