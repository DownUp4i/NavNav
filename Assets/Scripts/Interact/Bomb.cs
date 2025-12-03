using UnityEngine;

public class Bomb : MonoBehaviour, IDamageInteractable
{
    [SerializeField] private int _damage;
    [SerializeField] private float _damageRadius;

    private SphereCollider _sphereCollider;

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = _damageRadius;
    }

    public void Interact(IDamagable idamagable)
    {
        idamagable.TakeDamage(_damage);

        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _damageRadius);
    }
}
