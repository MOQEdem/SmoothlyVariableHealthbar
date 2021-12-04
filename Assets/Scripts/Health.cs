using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _minValue;

    private float _currentValue;

    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;
    public float MinValue => _minValue;

    private void Start()
    {
        _currentValue = _maxValue / 2;
    }

    public void Damage(float damageValue)
    {
        _currentValue -= damageValue;

        if (_currentValue < _minValue)
            _currentValue = _minValue;
    }

    public void Heal(float healValue)
    {
        _currentValue += healValue;

        if (_currentValue > _maxValue)
            _currentValue = _maxValue;
    }
}
