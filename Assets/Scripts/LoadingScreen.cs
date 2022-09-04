using System.Collections;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class LoadingScreen : MonoBehaviour
{
    private Slider _slider;
    private float _sliderChange = 0.2f;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
    }
    
    public IEnumerator Loading(float delay)
    {
        var seconds = new WaitForSeconds(delay);
        
        while (_slider.value != _slider.maxValue)
        {
            _slider.value += _sliderChange;
            yield return seconds;
        }
        gameObject.SetActive(false);
    }

}
