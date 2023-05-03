using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    private float velocity; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            gameObject.transform.Translate(velocity * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            gameObject.transform.Translate(-velocity * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            gameObject.transform.Translate(0, velocity * Time.deltaTime, 0);
        }

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            gameObject.transform.Translate(0, -velocity * Time.deltaTime, 0);
        }
    }
}
