using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private AgentCharacter _character;
    [SerializeField] private Image _healthFill;
    private void Update()
    {
        _healthFill.fillAmount = (float)_character.CurrentHealth / (float)_character.MaxHealth;
    }
}
