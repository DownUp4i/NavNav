using UnityEngine;

public class InjuredMoveAnimation : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private string _layerName = "Injured";

    [SerializeField] private Animator _animator;
    [SerializeField] private AgentCharacter _character;

    private void Update()
    {
        if (_character.CurrentHealth <= _character.MaxHealth * 0.30)
            SetLayerWeight(1);
        else
            SetLayerWeight(0);
    }

    public void SetLayerWeight(int weight)
    {
        int layerIndex = _animator.GetLayerIndex(_layerName);

        if (layerIndex != -1)
        {
            _animator.SetLayerWeight(layerIndex, weight);
        }
    }
}
