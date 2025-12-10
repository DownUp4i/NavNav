using UnityEngine;

public class FlagSpawner : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Flag _correctFlagPrefab;
    [SerializeField] private Flag _wrongFlagPrefab;

    private Flag _currentFlag;

    private void Update()
    {
        bool isPathAvailable = _character.IsPossibleWay == true && _character.IsDead == false && _character.CanMove() == true;

        if (_character.IsRightMouseDown())
        {
            if(isPathAvailable)
                _currentFlag = Instantiate(_correctFlagPrefab, _character.MouseHitPoint + new Vector3(0, 0.05f, 0), Quaternion.Euler(90, 0, 0));
            else 
                _currentFlag = Instantiate(_wrongFlagPrefab, _character.MouseHitPoint + new Vector3(0, 0.05f, 0), Quaternion.Euler(90, 0, 0));
        }

        if (_currentFlag != null)
            Destroy(_currentFlag.gameObject, 0.1f);
    }
}
