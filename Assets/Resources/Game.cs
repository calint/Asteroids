using UnityEngine;
using UnityEngine.Assertions;

public static class Game
{
    public static float gameAreaZ = 11;
    public static float gameAreaX = 18;
    public static int asteroidMediumSplitNum = 4;
    public static float asteroidMediumSplitVelocity = 3;
    public static float asteroidMediumSplitRandomRotationScale = 1;
    public static int asteroidLargeSplitNum = 4;
    public static float asteroidLargeSplitVelocity = 2;
    public static float asteroidLargeSplitRandomRotationScale = 0.5f;
    public static float fragmentLifetime = 0.5f;

    public static GameObject prefabAsteroidLarge;
    public static GameObject prefabAsteroidMedium;
    public static GameObject prefabAsteroidSmall;
    public static GameObject prefabShip;
    public static GameObject prefabShipThrust;
    public static GameObject prefabShipBullet;
    public static GameObject prefabFragment;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        Debug.Log("* initializing");
        prefabAsteroidLarge = Resources.Load<GameObject>("AsteroidLarge");
        Assert.IsNotNull(prefabAsteroidLarge);

        prefabAsteroidMedium = Resources.Load<GameObject>("AsteroidMedium");
        Assert.IsNotNull(prefabAsteroidMedium);

        prefabAsteroidSmall = Resources.Load<GameObject>("AsteroidSmall");
        Assert.IsNotNull(prefabAsteroidSmall);

        prefabShipBullet = Resources.Load<GameObject>("ShipBullet");
        Assert.IsNotNull(prefabShipBullet);

        prefabFragment = Resources.Load<GameObject>("Fragment");
        Assert.IsNotNull(prefabFragment);
    }

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