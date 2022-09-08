using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TextMeshPro))]
public class Coins : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private TMP_Text _tmp;
    private Animator _animator;
    private const string AnimationTrigger = "Play";

    private void OnEnable() => _wallet.CoinsCountChanged += ShowNumber;

    private void OnDisable() => _wallet.CoinsCountChanged -= ShowNumber;

    private void Awake()
    {
        _tmp = GetComponent<TMP_Text>();
        _animator = GetComponent<Animator>();
    }

    private void ShowNumber(int number)
    {
        PlayAnimation();
        _tmp.text = number.ToString();
    }

    private void PlayAnimation() => _animator.SetTrigger(AnimationTrigger);
}