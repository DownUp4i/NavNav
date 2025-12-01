using UnityEngine;

public class Bomb : MonoBehaviour, IDamageInteractable
{
    [SerializeField] private int _damage;
    [SerializeField] private float _damageRadius;


    public float Damage => _damage;
    public float DamageRadius => _damageRadius;

    public void Interact(IDamagable idamagable)
    {
        idamagable.TakeDamage(_damage);
        Destroy(this.gameObject);
    }
}
