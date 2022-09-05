using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private AudioSource _mainSound;
    private Slider _slider;
    private float _sliderChange = 0.2f;
    private Animator _animator;
    private const string Play = "Play";

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _animator = GetComponent<Animator>();
    }
    
    public IEnumerator Loading(float delay)
    {
        var seconds = new WaitForSeconds(delay);
        
        while (_slider.value != _slider.maxValue)
        {
            _slider.value += _sliderChange;
            yield return seconds;
        }
        _slider.gameObject.SetActive(false);
        ChangeColor();
        _mainSound.Play();
    }

    private void ChangeColor()
    {
        _animator.SetTrigger(Play);
    }
}
