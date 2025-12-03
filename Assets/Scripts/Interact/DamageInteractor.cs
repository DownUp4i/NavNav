using System.Data;
using UnityEngine;

public class DamageInteractor : MonoBehaviour
{
    [SerializeField] private float _timeToInteract;

    private IDamageInteractable _interactable;
    private IDamagable _damagable;

    private bool _isStarted;

    private void Awake()
    {
        _interactable = GetComponent<IDamageInteractable>();
    }

    private void Update()
    {
        if (_isStarted)
            _timeToInteract -= Time.deltaTime;

        if (_timeToInteract <= 0)
        {
            if (_damagable != null)
            {
                _interactable.Interact(_damagable);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isStarted = true;
        _damagable = other.GetComponent<IDamagable>();

    }

    private void OnTriggerExit(Collider other)
    {
        _damagable = null;
    }
}
