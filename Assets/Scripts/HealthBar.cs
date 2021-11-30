using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _slider;

    private void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
    }

    public void ChangeHealth(float healthChange)
    {
        StartCoroutine(ChangeHealthValue(healthChange));
    }

    public IEnumerator ChangeHealthValue(float healthChange)
    {
        float stepOfChange = 0.00010f;
        float targetHealth = _slider.value + healthChange;

        if (targetHealth < _slider.minValue)
            targetHealth = _slider.minValue;
        else if (targetHealth > _slider.maxValue)
            targetHealth = _slider.maxValue;

        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, stepOfChange);
            yield return null;
        }
    }
}
