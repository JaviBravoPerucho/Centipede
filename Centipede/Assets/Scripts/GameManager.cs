using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public enum Direction { Left, Right, Up, Down }
    [SerializeField]
    private GameObject Cabeza;
    [SerializeField]
    private GameObject Cuerpo;
    [SerializeField]
    private GameObject Seta;
    public Propiedades[,] CuadroDeJuego = new Propiedades[20, 20];


    public struct Propiedades
    {
        public Direction currentDirection;
        public float coordenadaX, coordenadaY;
        public bool haySeta, hayCabeza, hayCuerpo, actualizado;
        public GameObject cabeza, cuerpo, seta;
    }

    private void MushroomBoolSetting()
    {
        for(int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (Random.Range(0, 10) == 0 && i > 10) CuadroDeJuego[i, j].haySeta = true;
                else if (Random.Range(0, 20) == 0) CuadroDeJuego[i, j].haySeta = true;
            }
        }
    }

    private void CoordinateSetting()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                CuadroDeJuego[i, j].coordenadaX = j+0.5f;
                CuadroDeJuego[i, j].coordenadaY =19 - i +0.5f;
            }
        }
    }
    private void MushroomInstance()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {              
                if (CuadroDeJuego[i, j].haySeta)
                {
                    Vector2 coordenadas = new Vector2(CuadroDeJuego[i, j].coordenadaX, CuadroDeJuego[i, j].coordenadaY);
                    Instantiate(Seta, coordenadas, Quaternion.identity);
                }
            }
        }
    }
    public void ActualizadoFalse()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                CuadroDeJuego[i, j].actualizado = false;
            }
        }
    }

    private void SnakeInit()
    {
        CuadroDeJuego[0, 13].hayCabeza = true;
        CuadroDeJuego[0, 13].currentDirection = Direction.Right;
        for (int i = 2; i < 13; i++)
        {
            CuadroDeJuego[0, i].hayCuerpo = true;
            CuadroDeJuego[0, i].currentDirection = Direction.Right;
        }
    }
    private void Tests()
    {
        Vector2 vector2 = new Vector2(CuadroDeJuego[0, 0].coordenadaX, CuadroDeJuego[0, 0].coordenadaY);
        Instantiate(Cabeza, vector2, Quaternion.identity);
        vector2 = new Vector2(CuadroDeJuego[0, 5].coordenadaX, CuadroDeJuego[0, 5].coordenadaY);
        Instantiate(Cabeza, vector2, Quaternion.identity);
    }

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CoordinateSetting();
        MushroomBoolSetting();
        MushroomInstance();
        SnakeInit();
        ActualizadoFalse();
       // Tests();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ReloadBoard()
    {
       // Debug.Log("Actualizado");
        ActualizadoFalse();
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (CuadroDeJuego[i, j].hayCabeza)
                {
                   // Debug.Log("Pintado antes:" + i + "-" + j);
                  //  if (CuadroDeJuego[i, j].cabeza == null)
                    {
                        Vector2 coordenadas = new Vector2(CuadroDeJuego[i, j].coordenadaX, CuadroDeJuego[i, j].coordenadaY);
                        CuadroDeJuego[i, j].cabeza = Instantiate(Cabeza, coordenadas, Quaternion.identity);
 
                    }
                }
                else if(CuadroDeJuego[i, j].cabeza != null && !CuadroDeJuego[i, j].hayCabeza)
                {
                    Destroy(CuadroDeJuego[i, j].cabeza);
                }               
                if(CuadroDeJuego[i, j].hayCuerpo)
                {

                    Debug.Log("pintado");
                    Vector2 coordenadas = new Vector2(CuadroDeJuego[i, j].coordenadaX, CuadroDeJuego[i, j].coordenadaY);
                    CuadroDeJuego[i, j].cuerpo = Instantiate(Cuerpo, coordenadas, Quaternion.identity);
                }
                else if(CuadroDeJuego[i,j].cuerpo != null && !CuadroDeJuego[i, j].hayCuerpo)
                {
                    Destroy(CuadroDeJuego[i, j].cuerpo);
                }
            }
        }
    }
}
