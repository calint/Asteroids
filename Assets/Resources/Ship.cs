using UnityEngine;

public class Ship : MonoBehaviour
{
    public float engineThrustFactor = 2;
    public float turnSpeed = 90.0f;
    public GameObject model1;
    public GameObject model2;
    private Vector3 velocity;
    public float fireInterval = 1;
    public float bulletVelocity = 10;
    private float nextFireTime = 0;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;

        model1.SetActive(true);
        model2.SetActive(false);
    }

    void FixedUpdate()
    {
        // Reset rotation on the X and Z axes
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.x = -90;
        currentRotation.z = 0;
        transform.eulerAngles = currentRotation;

        // Reset angular velocity on the X and Z axes
        Vector3 currentAngularVelocity = rb.angularVelocity;
        currentAngularVelocity.x = 0;
        currentAngularVelocity.z = 0;
        rb.angularVelocity = currentAngularVelocity;

        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
    }

    void Update()
    {
        // Accelerate the ship in the direction it is currently facing
        if (Input.GetKey(KeyCode.W))
        {
            model1.SetActive(false);
            model2.SetActive(true);
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
            GameObject blt = Instantiate(Game.prefabShipBullet, transform.position + 1.5f * transform.up, transform.rotation);
            Rigidbody brb = blt.GetComponent<Rigidbody>();
            brb.velocity = transform.up * bulletVelocity;
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
