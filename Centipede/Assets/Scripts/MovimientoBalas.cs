using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBalas : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    [SerializeField]
    private float velocidad;
    [SerializeField]
    private GameObject seta;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _rigidBody2D.AddForce(transform.up * velocidad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<LifeComponent>())
        {
            collision.gameObject.GetComponent<LifeComponent>().vida--;
        }
        if (collision.gameObject.tag=="Cuerpo"|| collision.gameObject.tag == "Cabeza")
        {
            Destroy(collision.gameObject);
            Instantiate(seta, collision.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}