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
        public bool haySeta, hayCabeza, hayCuerpo;
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
        for (int i = 19; i > 0; i--)
        {
            for (int j = 0; j < 20; j++)
            {
                CuadroDeJuego[i, j].coordenadaX = j+0.5f;
                CuadroDeJuego[i, j].coordenadaY = i-0.5f;
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

    private void SnakeInit()
    {
        CuadroDeJuego[19, 13].hayCabeza = true;
        CuadroDeJuego[19, 13].currentDirection = Direction.Right;
        for (int i = 0; i < 12; i++)
        {
            CuadroDeJuego[19, i].hayCuerpo = true;
        }
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
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 19; i > 0; i--)
        {
            for (int j = 0; j < 20; j++)
            {
                if (CuadroDeJuego[i, j].hayCabeza)
                {
                    if(CuadroDeJuego[i, j].cabeza == null)
                    {
                        Vector2 coordenadas = new Vector2(CuadroDeJuego[i, j].coordenadaX, CuadroDeJuego[i, j].coordenadaY);
                        CuadroDeJuego[i, j].cabeza = Instantiate(Cabeza, coordenadas, Quaternion.identity);
                    }
                }
                else Destroy(CuadroDeJuego[i, j].cabeza);
            }
        }
    }
}
