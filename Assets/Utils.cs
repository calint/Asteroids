using UnityEngine;

public static class Utils
{
    public static float gameAreaZ = 11;
    public static float gameAreaX = 18;
    public static Vector3 RollOver(Vector3 position)
    {
        if (position.z > gameAreaZ)
        {
            position.z -= 2 * gameAreaZ;
        }
        else if (position.z < -gameAreaZ)
        {
            position.z += 2 * gameAreaZ;
        }
        if (position.x > gameAreaX)
        {
            position.x -= 2 * gameAreaX;
        }
        else if (position.x < -gameAreaX)
        {
            position.x += 2 * gameAreaX;
        }
        return position;
    }

    public static bool IsInGameArea(Vector3 position)
    {
        return position.x > -gameAreaX && position.x < gameAreaX && position.z > -gameAreaZ && position.z < gameAreaZ;
    }
}