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
        _rigidBody2D.AddForce(transform.up * velocidad, ForceMode2D.Impulse);
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<LifeComponent>())
        {
            collision.gameObject.GetComponent<LifeComponent>().vida--;
        }
        if (collision.gameObject.tag== "Cuerpo")
        {
            Destroy(collision.gameObject);
            GameManager.Instance.snakeLifes--;
            Instantiate(seta, collision.transform.position, Quaternion.identity);
            GameManager.Instance.EliminatePartPlantMushroom((int)collision.transform.position.x, (int)collision.transform.position.y);
            UIManager.Instance.Points(10);
          //  GameManager.Instance.CuadroDeJuego[(int)collision.transform.position.x, (int)collision.transform.position.y].seta = Instantiate(seta, collision.transform.position, Quaternion.identity);
        }
        else if(collision.gameObject.tag == "Cabeza")
        {
            Destroy(collision.gameObject);
            GameManager.Instance.snakeLifes--;          
            GameManager.Instance.EliminatePartPlantMushroom((int)collision.transform.position.x, (int)collision.transform.position.y);
            UIManager.Instance.Points(100);
           // GameManager.Instance.CuadroDeJuego[(int)collision.transform.position.x, (int)collision.transform.position.y].seta = Instantiate(seta, collision.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
