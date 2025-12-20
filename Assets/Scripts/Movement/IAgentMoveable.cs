using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgentMoveable : IMoveable
{
    bool isAvailablePath(Vector3 position);
}
