using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cuerpo")
        {
            GameManager.Instance.LoseLife();
        
        }
        else if (collision.gameObject.tag == "Cabeza")
        {
            GameManager.Instance.LoseLife();
            
        }
        else if(collision.gameObject.GetComponent<DamageComponent>())
        {
            GameManager.Instance.LoseLife();
        }

    }
}
