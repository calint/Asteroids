using UnityEngine;

public class Ship : MonoBehaviour
{
    public float engineThrustFactor = 2;
    public float turnSpeed = 90.0f;
    public GameObject model1;
    public GameObject model2;
    public GameObject prefabBullet;
    private Vector3 velocity;
    public float fireInterval = 1;
    public float bulletVelocity = 10;
    private float nextFireTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        model1.SetActive(true);
        model2.SetActive(false);
    }

    void Update()
    {
        // Accelerate the ship in the direction it is currently facing
        if (Input.GetKey(KeyCode.W))
        {
            model1.SetActive(false);
            model2.SetActive(true);
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.up * engineThrustFactor, ForceMode.Impulse);
        }
        else
        {
            model1.SetActive(true);
            model2.SetActive(false);
        }

        // Rotate the ship left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
        }

        // Rotate the ship right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.J) && Time.realtimeSinceStartup > nextFireTime)
        {
            nextFireTime = Time.realtimeSinceStartup + fireInterval;
            GameObject blt = Instantiate(prefabBullet, transform.position + 1.5f * transform.up, transform.rotation);
            Rigidbody rb = blt.GetComponent<Rigidbody>();
            rb.AddForce(transform.up * bulletVelocity, ForceMode.Impulse);
        }

        // Move the ship according to its velocity
        transform.position += velocity * Time.deltaTime;
        transform.position = Game.RollOver(transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " OnCollisionEnter " + collision.gameObject.name);
    }
}
