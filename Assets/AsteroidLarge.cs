using UnityEngine;

public class AsteroidLarge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Utils.RollOver(transform.position);
    }
}
