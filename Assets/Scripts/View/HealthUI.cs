using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Image _healthFill;
    private void Update()
    {
        _healthFill.fillAmount = (float)_playerHealth.CurrentHealth / (float)_playerHealth.MaxHealth;
    }
}
