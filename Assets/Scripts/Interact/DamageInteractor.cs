using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DamageInteractor : MonoBehaviour
{
    [SerializeField] private float _timeToInteract;

    private IDamageInteractable _interactable;

    private List<IDamagable> _damagableList = new List<IDamagable>();

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
            if (_damagableList != null && _damagableList.Count > 0)
            {
                foreach (IDamagable damagable in _damagableList)
                {
                    _interactable.Interact(damagable);
                }
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _interactable.Radius);

        _isStarted = true;

        foreach(Collider collider in colliders)
        {
            IDamagable damagable = collider.GetComponent<IDamagable>();
            if (damagable != null)
                _damagableList.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();

        if (damagable != null)
        {
            _damagableList.Remove(damagable);
        }
    }
}
