using UnityEngine;

public static class CheckPoint
{
    private static Vector3? lastPosition;

    public static void Save(Vector3 position)
    {
        lastPosition = position;
    }

    public static bool TryGetPosition(out Vector3 position)
    {
        if (lastPosition.HasValue)
        {
            position = lastPosition.Value;
            return true;
        }

        position = Vector3.zero;
        return false;
    }
}
