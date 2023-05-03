using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Serpiente[] serpiente = new Serpiente[13];
    public Serpiente[] copia = new Serpiente[13];


    public struct Propiedades
    {
        public Direction currentDirection;
        public float coordenadaX, coordenadaY;
        public bool haySeta, hayCabeza, hayCuerpo, actualizado;
        public GameObject cabeza, cuerpo, seta;
    }
    public struct Serpiente
    {
        public Direction currentDirection;
        public int X, Y;
        public bool isHead;
        public bool isSnake;
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
        serpiente[0].currentDirection = Direction.Right;
        serpiente[0].Y = 0;
        serpiente[0].X = 13;
        serpiente[0].isHead= true;
        serpiente[0].isSnake= true;
        for (int i = 1; i < serpiente.Length; i++)
        {
            serpiente[i].currentDirection = Direction.Right;
            serpiente[i].X = i;
            serpiente[i].Y = 0;
            serpiente[i].isHead = false;
            serpiente[i].isSnake = true;
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
       // Tests();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void CopiaASerpiente()
    {
   
        for (int i = 0; i < serpiente.Length; i++)
        {
            serpiente[i].currentDirection = copia[i].currentDirection;
            serpiente[i].X = copia[i].X;
            serpiente[i].Y = copia[i].Y;
            serpiente[i].isHead= copia[i].isHead;
            
             
        }       
    }
    public void SetCabezas()
    {
        for (int i = serpiente.Length -2; i > 1; i--)
        {
            if (copia[i + 1].isSnake == false)
            {
                copia[i].isHead = true;
            }
            else copia[i].isHead = false;
        }
        if (copia[0].isSnake) { copia[0].isHead = true; }
    }
    public void ReloadBoard()
    {
       // Debug.Log("Actualizado");
       SetCabezas();
       CopiaASerpiente();
        for (int i = 0; i < serpiente.Length; i++)
        {
            if (serpiente[i].isSnake)
            {
                if (serpiente[i].isHead && !CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza)
                {
                    Vector2 vector = new Vector2(CuadroDeJuego[serpiente[i].Y, serpiente[i].X].coordenadaX, CuadroDeJuego[serpiente[i].Y, serpiente[i].X].coordenadaY);
                    CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza = Instantiate(Cabeza, vector, Quaternion.identity);                   
                }
                else if (!serpiente[i].isHead && !CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo)
                {
                    Vector2 vector = new Vector2(CuadroDeJuego[serpiente[i].Y, serpiente[i].X].coordenadaX, CuadroDeJuego[serpiente[i].Y, serpiente[i].X].coordenadaY);
                    CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo = Instantiate(Cuerpo, vector, Quaternion.identity);
                }
            }
            else
            {             
                    CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza.gameObject.SetActive(false);                              
                    CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo.gameObject.SetActive(false);            
            }
        } 
        
           
                  
    }
}
