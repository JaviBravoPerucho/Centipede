using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    [SerializeField]
    public int vida = 4;
    // Start is called before the first frame update

 
    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            if(!GetComponent<DamageComponent>())
            UIManager.Instance.Points(4);
            Destroy(gameObject);
        }
    }
}
