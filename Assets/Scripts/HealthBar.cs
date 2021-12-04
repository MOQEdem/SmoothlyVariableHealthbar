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
    private float _stepOfValueChange;

    private void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
        _slider.minValue = _health.MinValue;
        _slider.maxValue = _health.MaxValue;
        _slider.value = _health.CurrentValue;
        _stepOfValueChange = _health.MaxValue / 3000;

        StartCoroutine(ManipulateSliderValue());
    }

    private IEnumerator ManipulateSliderValue()
    {
        var timeBetweenChecks = new WaitForSeconds(0.5f);

        while (true)
        {
            while (_slider.value != _health.CurrentValue)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, _health.CurrentValue, _stepOfValueChange);
                _text.text = _health.CurrentValue.ToString();
                yield return null;
            }

            yield return timeBetweenChecks;
        }
    }
}

