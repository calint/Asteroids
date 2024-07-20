using UnityEngine;

public class AsteroidMedium : MonoBehaviour
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
        Rigidbody rb = GetComponent<Rigidbody>();
        for (int i = 0; i < Game.asteroidMediumSplitNum; i++)
        {
            GameObject o = Instantiate(Game.prefabAsteroidSmall);
            Vector3 rnd = Random.insideUnitSphere.normalized;
            rnd.y = 0;
            Vector3 pos = transform.position + 0.5f * transform.localScale.x * rnd;
            o.transform.position = pos;
            o.transform.rotation = Random.rotation;
            Rigidbody orb = o.GetComponent<Rigidbody>();
            orb.velocity = rb.velocity + Game.asteroidMediumSplitVelocity * rnd;
            orb.angularVelocity = Game.asteroidMediumSplitRandomRotationScale * rnd;
        }
        Destroy(gameObject);
        Game.asteroidCount--;
    }
}
