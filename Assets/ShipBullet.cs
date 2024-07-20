using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("bullet start");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Game.IsInGameArea(transform.position))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
        Destroy(gameObject);
    }
}
