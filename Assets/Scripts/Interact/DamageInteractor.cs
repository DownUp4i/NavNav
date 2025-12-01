using System.Data;
using UnityEngine;

public class DamageInteractor : MonoBehaviour
{
    [SerializeField] private float _timeToInteract;

    private IDamageInteractable _interactable;
    private IDamagable _damagable;


    private void Awake()
    {
        _interactable = GetComponent<IDamageInteractable>();
    }

    private void Update()
    {
        if (_damagable != null)
        {
            _timeToInteract -= Time.deltaTime;

            if (_timeToInteract <= 0) 
                _interactable.Interact(_damagable);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _damagable = other.GetComponent<IDamagable>();
    }
}
