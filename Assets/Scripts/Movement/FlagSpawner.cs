using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSpawner : MonoBehaviour
{
    [SerializeField] private Flag _correctFlagPrefab;
    [SerializeField] private Flag _wrongFlagPrefab;

    [SerializeField] private PlayerMovement _playerMovement;

    private InputController _positionController;

    private readonly int RightMouseInput = 1;

    private Flag _currentFlag;

    private void Awake()
    {
        _positionController = new InputMousePositionController();
    }

    private void Update()
    {
        _positionController.UpdateLogic(Time.deltaTime);

        bool isPossibleWay = _playerMovement.IsPossibleWay;

        if (Input.GetMouseButtonDown(RightMouseInput))
        {
            if(isPossibleWay == true)
                _currentFlag = Instantiate(_correctFlagPrefab, _positionController.GetDirection + new Vector3(0, 0.05f, 0), Quaternion.Euler(90, 0, 0));
            else 
                _currentFlag = Instantiate(_wrongFlagPrefab, _positionController.GetDirection + new Vector3(0, 0.05f, 0), Quaternion.Euler(90, 0, 0));
        }

        if (_currentFlag != null)
            Destroy(_currentFlag.gameObject, 0.1f);
    }
}
