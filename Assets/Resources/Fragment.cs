using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("fragment");
        Destroy(gameObject, Game.fragmentLifetime);
    }

}
