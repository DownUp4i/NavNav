using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour, IInteractable
{
    [SerializeField] private int _damageValue;
    [SerializeField] private float _damageRadius;
    [SerializeField] private float _timeToInteract;

    private IDamagable _damagable;
    private SphereCollider _sphereCollider;

    private bool _isSoundPlayed = false;
    private bool _isInteracted = false;

    public bool IsInteracted => _isInteracted;
    public bool SoundPlayed => _isSoundPlayed;

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = _damageRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();

        if (damagable != null)
            _damagable = damagable;
    }

    private void OnTriggerExit(Collider other)
    {
        _damagable = null;
    }

    public void SetSoundPlayed() => _isSoundPlayed = true;

    public void Interact()
    {
        if (_isInteracted == false)
            StartCoroutine(InteractProcess());
    }

    private IEnumerator InteractProcess()
    {
        _isInteracted = true;

        yield return new WaitForSeconds(_timeToInteract);
        SetSoundPlayed();

        if (_damagable != null)
            _damagable.TakeDamage(_damageValue);

        yield return new WaitUntil(() => _isSoundPlayed);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _damageRadius);
    }
}
