using UnityEngine;

public class AsteroidMedium : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Game.RollOver(transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
        Vector3 position = transform.position;
        for (int i = 0; i < Game.asteroidMediumSplitNum; i++)
        {
            Vector3 v = Random.insideUnitSphere.normalized;
            v.y = 0;
            Vector3 p = 0.5f * transform.localScale.x * v + transform.position;
            GameObject o = Instantiate(Game.prefabAsteroidSmall, p, Random.rotation);
            Rigidbody rb = o.GetComponent<Rigidbody>();
            rb.velocity = GetComponent<Rigidbody>().velocity + Game.asteroidMediumSplitVelocity * v;
            rb.angularVelocity = Game.asteroidMediumSplitRandomRotationScale * v;
            Destroy(gameObject);
        }
    }
}
