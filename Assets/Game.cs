using UnityEngine;

public static class Game
{
    public static float gameAreaZ = 11;
    public static float gameAreaX = 18;
    public static int asteroidMediumSplitNum = 4;
    public static float asteroidMediumSplitVelocity = 4;
    public static float asteroidMediumSplitRandomRotationScale = 1;
    public static int asteroidLargeSplitNum = 4;
    public static float asteroidLargeSplitVelocity = 2;
    public static float asteroidLargeSplitRandomRotationScale = 0.5f;

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