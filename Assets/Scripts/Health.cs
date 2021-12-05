using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _minValue;

    private float _currentValue;

    public event UnityAction ValueChanged;

    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;
    public float MinValue => _minValue;

    private void Start()
    {
        _currentValue = _maxValue / 2;
        ValueChanged?.Invoke();
    }

    public void Damage(float damageValue)
    {
        _currentValue -= damageValue;
        _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
        ValueChanged?.Invoke();
    }

    public void Heal(float healValue)
    {
        _currentValue += healValue;
        _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
        ValueChanged?.Invoke();
    }
}
