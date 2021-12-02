using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;
    private Text _text;
    private bool _isChanging;
    private float _stepOfValueChange;

    private void Start()
    {
        _text = gameObject.GetComponentInChildren<HealthMeter>().GetComponent<Text>();
        _slider = gameObject.GetComponent<Slider>();
        _slider.minValue = _health.MinValue;
        _slider.maxValue = _health.MaxValue;
        _slider.value = _health.CurrentValue;
        _isChanging = false;
        _stepOfValueChange = _health.MaxValue / 3000;
    }

    private void Update()
    {
        if (_isChanging != true)
        {
            if (_slider.value != _health.CurrentValue)
            {
                StartCoroutine(ChangeSliderValue());
                _text.text = _health.CurrentValue.ToString();
            }
        }
    }

    private IEnumerator ChangeSliderValue()
    {
        float targetHealth = _health.CurrentValue;

        _isChanging = true;

        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _stepOfValueChange);
            yield return null;
        }

        _isChanging = false;
    }
}
