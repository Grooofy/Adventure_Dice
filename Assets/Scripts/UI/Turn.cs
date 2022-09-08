using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TextMeshPro))]
public class Turn : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Animator _animator;
    private TMP_Text _tmp;
    private const string AnimationTrigger = "Play";
    private const string TurnsOver = "Over";

    private void OnEnable()
    {
        _player.TurnsChanged += ShowNumber;
        _player.TurnsEnded += ShowEndTurns;
    }

    private void OnDisable()
    {
        _player.TurnsChanged -= ShowNumber;
        _player.TurnsEnded -= ShowEndTurns;
    }

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

    private void ShowEndTurns() => _tmp.text = TurnsOver;
}