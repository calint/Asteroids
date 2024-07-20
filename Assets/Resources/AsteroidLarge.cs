using UnityEngine;

public class AsteroidLarge : MonoBehaviour
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
        for (int i = 0; i < Game.asteroidLargeSplitNum; i++)
        {
            GameObject o = Instantiate(Game.prefabAsteroidMedium);
            Vector3 rnd = Random.insideUnitSphere.normalized;
            rnd.y = 0;
            o.transform.position = transform.position + transform.localScale.x * rnd;
            o.transform.rotation = Random.rotation;
            Rigidbody orb = o.GetComponent<Rigidbody>();
            orb.velocity = rb.velocity + Game.asteroidLargeSplitVelocity * rnd;
            orb.angularVelocity = Game.asteroidLargeSplitRandomRotationScale * rnd;
        }
        Destroy(gameObject);
        Game.asteroidCount--;
    }
}
