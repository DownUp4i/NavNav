using UnityEngine;

public class CharacterHealth
{
    private int _maxHealth;
    private int _currentHealth;

    private bool _isDead;
    private bool _isTakedDamage;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
    public bool IsTakedDamage { get; set; }
    public bool IsDead => _currentHealth <= 0;

    public CharacterHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
    }

    public void SetCurrentHealth()
    {
        _currentHealth = _maxHealth;
    }


    public void TakeDamage(int damage)
    {
        IsTakedDamage = true;

        if (damage < 0)
            return;

        _currentHealth -= damage;
    }
}
