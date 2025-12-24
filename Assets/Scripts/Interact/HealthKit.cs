using UnityEngine;

public class HealthKit : MonoBehaviour, IInteractable
{
    [SerializeField] private int value;

    private IHealable _healable;

    public bool IsInteracted => throw new System.NotImplementedException();

    public void Interact()
    {
        if (_healable != null)
            _healable.Heal(value);

        _healable = null;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        IHealable healable = other.GetComponent<IHealable>();

        if (healable != null)
            _healable = healable;
    }
}
