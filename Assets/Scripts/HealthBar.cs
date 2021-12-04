using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Text _text;

    private Slider _slider;
    private bool _isChanging;
    private float _stepOfValueChange;

    private void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
        _slider.minValue = _health.MinValue;
        _slider.maxValue = _health.MaxValue;
        _slider.value = _health.CurrentValue;
        _isChanging = false;
        _stepOfValueChange = _health.MaxValue / 3000;

        StartCoroutine(CheckHealthChange());
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

    private IEnumerator CheckHealthChange()
    {
        var timeBetweenChecks = new WaitForSeconds(0.5f);

        while (true)
        {
            if (_isChanging != true)
            {
                if (_slider.value != _health.CurrentValue)
                {
                    StartCoroutine(ChangeSliderValue());
                    _text.text = _health.CurrentValue.ToString();
                }
            }

            yield return timeBetweenChecks;
        }
    }
}
