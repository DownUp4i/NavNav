using UnityEngine;

public interface IDamageInteractable 
{
    public float Radius { get; set; }
    public void Interact(IDamagable idamagable);
}
