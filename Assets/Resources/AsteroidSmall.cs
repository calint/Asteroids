using UnityEngine;

public class AsteroidSmall : MonoBehaviour
{
    void Start()
    {
        Game.asteroidCount++;
    }

    void Update()
    {
        transform.position = Game.RollOver(transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Game.asteroidCount--;
    }
}
