using UnityEngine;
using UnityEngine.AI;

public static class NavMeshUtils
{
    public static float GetPathLength(NavMeshPath path)
    {
        float pathLength = 0f;

        if (path.corners.Length > 1)
        {
            for (int i = 1; i < path.corners.Length; i++)
                pathLength += Vector3.Distance(path.corners[i - 1], path.corners[i]);
        }

        return pathLength;
    }
}
