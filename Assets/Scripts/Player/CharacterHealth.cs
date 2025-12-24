using UnityEngine;

public class CharacterHealth
{
    private int _maxHealth;
    private int _currentHealth;

    private bool _isDead;
    private bool _isTakedDamage;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
    public bool IsTakedDamage => _isTakedDamage;
    public bool IsDead => _currentHealth <= 0;

    public CharacterHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
    }

    public void SetCurrentHealth(int value)
    {
        _currentHealth = value;
    }

    public void Heal(int value)
    {
        if(_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        _currentHealth += value;
    }

    public void TakeDamage(int damage)
    {
        _isTakedDamage = true;

        if (damage < 0)
            return;

        _currentHealth -= damage;
    }

    public void ResetTakeDamage() => _isTakedDamage = false;
}
