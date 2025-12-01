using UnityEngine;

public interface IControllable
{
    void Controll(Vector3 direction);
    void StopMove();
    void ResumeMove();

}
