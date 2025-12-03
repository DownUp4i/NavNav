using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    private bool _isDead;
    private bool _isTakedDamage;

    public bool IsDead => _isDead;
    public bool IsTakedDamage => _isTakedDamage;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        _isDead = _currentHealth <= 0;

        if(_isTakedDamage == true)
            _isTakedDamage = false;
    }

    public void TakeDamage(int damage)
    {
        _isTakedDamage = true;

        if (damage < 0)
            return;

        _currentHealth -= damage;

    }
}
