using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSmall : MonoBehaviour
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
        Destroy(gameObject);
    }
}
