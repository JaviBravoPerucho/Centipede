using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region references
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public enum Direction { Left, Right, Up, Down }
    public enum ColorJuego { Normal, Rojo, Amarillo }
    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject Cabeza;
    [SerializeField]
    private GameObject Cuerpo;
    [SerializeField]
    private GameObject Seta;
    [SerializeField]
    private GameObject Player;
    public Propiedades[,] CuadroDeJuego = new Propiedades[20, 20];
    public Serpiente[] serpiente = new Serpiente[13];
    public Serpiente[] copia = new Serpiente[13];
    private ColorJuego currentColor;
    #endregion

    #region properties
    public int playerLifes;
    public int snakeLifes = 13;
    [SerializeField]
    private float _respawnTime;
    private float _elapsedTime = 0;
    private bool _dead = false;

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
        public bool isHead, isSnake, goesUp;
    }
    #endregion

    #region methods

    public void LoseLife()
    {
        if (playerLifes > 1)
        {
            playerLifes--;
            Player.SetActive(false);
            _dead = true;
            UIManager.Instance.UpdateHud(playerLifes);
        }
        else if(playerLifes == 1)
        {
            playerLifes--;
            Player.SetActive(false);
            _dead = true;
            UIManager.Instance.gameOver.SetActive(true);
            UIManager.Instance.ResetPoints();
            UIManager.Instance.RegenerateLifes();
            //currentColor = (ColorJuego)Random.Range(0, 4);
        }
        Instantiate(explosion, Player.transform.position, Quaternion.identity);
        
    }

    private void MushroomBoolSetting(int probY, int probX)
    {
        for(int i = 2; i < 18; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (Random.Range(0, probY) == 0 && i < 10) CuadroDeJuego[i, j].haySeta = true;
                else if (Random.Range(0, probX) == 0 && i > 10) CuadroDeJuego[i, j].haySeta = true;
            }
        }
    }
    private void MushroomRearange()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (CuadroDeJuego[i, j].haySeta && CuadroDeJuego[i,j].seta && CuadroDeJuego[i, j].seta.GetComponent<LifeComponent>().vida < 4)
                {
                    CuadroDeJuego[i, j].seta.GetComponent<LifeComponent>().vida = 4;
                }
                else if(!CuadroDeJuego[i, j].haySeta && CuadroDeJuego[i, j].seta && i > 5 && Random.Range(0,50) == 0)CuadroDeJuego[i, j].haySeta = true;
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
                if (CuadroDeJuego[i, j].haySeta && CuadroDeJuego[i, j].seta == null)
                {
                    Vector2 coordenadas = new Vector2(CuadroDeJuego[i, j].coordenadaX, CuadroDeJuego[i, j].coordenadaY);
                    CuadroDeJuego[i, j].seta = Instantiate(Seta, coordenadas, Quaternion.identity);
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

        for (int i = 0; i < serpiente.Length; i++)
        {
            serpiente[i].currentDirection = Direction.Right;
            serpiente[i].X = i;
            serpiente[i].Y = 0;
            serpiente[i].isHead = false;
            serpiente[i].isSnake = true;
            serpiente[i].goesUp = false;
        }
        
    }
    public void EliminatePartPlantMushroom(int x, int y)
    {
        for (int i = 0; i < serpiente.Length; i++)
        {
            if(x == serpiente[i].X && y == 19 - serpiente[i].Y )
            {
                copia[i].isSnake = false;
                serpiente[i].isSnake = false;
                CuadroDeJuego[19 - y, x].haySeta = true;
                Vector2 coordenadas = new Vector2(CuadroDeJuego[19 - y, x].coordenadaX, CuadroDeJuego[19 - y, x].coordenadaY);
                if(CuadroDeJuego[19 - y, x].seta == null)CuadroDeJuego[19 - y, x].seta = Instantiate(Seta, coordenadas, Quaternion.identity);
            }
        }
    }
    /*private void Tests()
    {
        Vector2 vector2 = new Vector2(CuadroDeJuego[0, 0].coordenadaX, CuadroDeJuego[0, 0].coordenadaY);
        Instantiate(Cabeza, vector2, Quaternion.identity);
        vector2 = new Vector2(CuadroDeJuego[0, 5].coordenadaX, CuadroDeJuego[0, 5].coordenadaY);
        Instantiate(Cabeza, vector2, Quaternion.identity);
    }*/

    public void CopiaASerpiente()
    {

        for (int i = 0; i < serpiente.Length; i++)
        {
            serpiente[i].currentDirection = copia[i].currentDirection;
            serpiente[i].X = copia[i].X;
            serpiente[i].Y = copia[i].Y;
            serpiente[i].isHead = copia[i].isHead;
            serpiente[i].goesUp = copia[i].goesUp;
        }
    }
    private void InitCopia()
    {
        for (int i = 0; i < copia.Length; i++)
        {
            copia[i].isSnake = true;
        }
    }
    public void SetCabezas()
    {
        for (int i = serpiente.Length - 2; i > 0; i--)
        {
            if (copia[i + 1].isSnake == false)
            {
                copia[i].isHead = true;
            }
            else copia[i].isHead = false;
        }
        if (copia[serpiente.Length - 1].isSnake) { copia[copia.Length - 1].isHead = true; }
    }
    public void SetCabezasSnake()
    {
        for (int i = serpiente.Length - 2; i > 0; i--)
        {
            if (serpiente[i + 1].isSnake == false)
            {
                serpiente[i].isHead = true;
                copia[i].isHead = true;
            }
            else
            {
                copia[i].isHead = false;
                serpiente[i].isHead = false;
            }
        }
        if (serpiente[serpiente.Length - 1].isSnake) { serpiente[copia.Length - 1].isHead = true; copia[copia.Length - 1].isHead = true; }
    }
    private void EliminaSerpiente()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (CuadroDeJuego[j, i].cabeza)
                {
                    Destroy(CuadroDeJuego[j, i].cabeza);
                }
                if (CuadroDeJuego[j, i].cuerpo)
                {
                    Destroy(CuadroDeJuego[j, i].cuerpo);
                }
            }
        }
    }
    public void ReloadBoard()
    {
        EliminaSerpiente();
        SetCabezas();
        CopiaASerpiente();
        bool muerta = true;
        for (int i = 0; i < serpiente.Length; i++)
        {
            if (serpiente[i].isSnake)
            {
                muerta = false;
            }
        }
        if (muerta || _dead)
        {
            currentColor = (ColorJuego)Random.Range(0, 3);
            SnakeInit();
            // SetCabezasSnake();
        }

        for (int i = 0; i < serpiente.Length; i++)
        {
            if (serpiente[i].isSnake)
            {
                if (serpiente[i].isHead/* && !CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza*/)
                {
                    if (CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo)
                    {
                        Destroy(CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo);
                    }
                    Vector2 vector = new Vector2(CuadroDeJuego[serpiente[i].Y, serpiente[i].X].coordenadaX, CuadroDeJuego[serpiente[i].Y, serpiente[i].X].coordenadaY);
                    CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza = Instantiate(Cabeza, vector, Quaternion.identity);
                    switch (serpiente[i].currentDirection)
                    {
                        case Direction.Left:
                            CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza.transform.Rotate(0, 0, 180);
                            break;
                        case Direction.Right:
                            CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza.transform.Rotate(0, 0, 0);
                            break;
                        case Direction.Up:
                            CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza.transform.Rotate(0, 0, 90);
                            break;
                        case Direction.Down:
                            CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza.transform.Rotate(0, 0, 270);
                            break;
                    }
                }
                else if (!serpiente[i].isHead/* && !CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo*/)
                {
                    if (CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza)
                    {
                        Destroy(CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cabeza);
                    }
                    Vector2 vector = new Vector2(CuadroDeJuego[serpiente[i].Y, serpiente[i].X].coordenadaX, CuadroDeJuego[serpiente[i].Y, serpiente[i].X].coordenadaY);
                    CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo = Instantiate(Cuerpo, vector, Quaternion.identity);
                    switch (serpiente[i].currentDirection)
                    {
                        case Direction.Left:
                            CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo.transform.Rotate(0, 0, 180);
                            break;
                        case Direction.Right:
                            CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo.transform.Rotate(0, 0, 0);
                            break;
                        case Direction.Up:
                            CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo.transform.Rotate(0, 0, 90);
                            break;
                        case Direction.Down:
                            CuadroDeJuego[serpiente[i].Y, serpiente[i].X].cuerpo.transform.Rotate(0, 0, 270);
                            break;
                    }

                }
            }

        }
    }
    #endregion

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CoordinateSetting();
        MushroomBoolSetting(10, 25);
        MushroomInstance();
        SnakeInit();
        InitCopia();
        // Tests();
        currentColor = ColorJuego.Normal;
        Player = Instantiate(Player, _spawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(_dead)
        {
            _elapsedTime += Time.deltaTime;
            if(_elapsedTime > _respawnTime)
            {
                MushroomRearange();
                MushroomInstance();
                Player.SetActive(true);
                Player.transform.position = _spawnPoint.position;
                _dead = false;
                _elapsedTime = 0;
                UIManager.Instance.gameOver.SetActive(false);
               
            }
            
        }
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                switch (currentColor)
                { 
                    case ColorJuego.Normal:
                        if (CuadroDeJuego[i, j].cabeza != null) CuadroDeJuego[i, j].cabeza.GetComponent<SpriteRenderer>().color = Color.green;
                        if (CuadroDeJuego[i, j].seta != null) CuadroDeJuego[i, j].seta.GetComponent<SpriteRenderer>().color = Color.green;
                        if (CuadroDeJuego[i, j].cuerpo != null) CuadroDeJuego[i, j].cuerpo.GetComponent<SpriteRenderer>().color = Color.green;
                        if (Player != null) Player.GetComponent<SpriteRenderer>().color = Color.green;
                        break;
                    /*case ColorJuego.Cyan:
                        if(CuadroDeJuego[i, j].cabeza != null) CuadroDeJuego[i, j].cabeza.GetComponent<SpriteRenderer>().color = Color.cyan;
                        if (CuadroDeJuego[i, j].seta != null) CuadroDeJuego[i, j].seta.GetComponent<SpriteRenderer>().color = Color.cyan;
                        if (CuadroDeJuego[i, j].cuerpo != null) CuadroDeJuego[i, j].cuerpo.GetComponent<SpriteRenderer>().color = Color.cyan;
                        if (Player != null) Player.GetComponent<SpriteRenderer>().color = Color.cyan;
                        break;*/
                    case ColorJuego.Rojo:
                        if (CuadroDeJuego[i, j].cabeza != null) CuadroDeJuego[i, j].cabeza.GetComponent<SpriteRenderer>().color = Color.red;
                        if (CuadroDeJuego[i, j].seta != null) CuadroDeJuego[i, j].seta.GetComponent<SpriteRenderer>().color = Color.red;
                        if (CuadroDeJuego[i, j].cuerpo != null) CuadroDeJuego[i, j].cuerpo.GetComponent<SpriteRenderer>().color = Color.red;
                        if (Player != null) Player.GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    case ColorJuego.Amarillo:
                        if (CuadroDeJuego[i, j].cabeza != null) CuadroDeJuego[i, j].cabeza.GetComponent<SpriteRenderer>().color = Color.yellow;
                        if (CuadroDeJuego[i, j].seta != null) CuadroDeJuego[i, j].seta.GetComponent<SpriteRenderer>().color = Color.yellow;
                        if (CuadroDeJuego[i, j].cuerpo != null) CuadroDeJuego[i, j].cuerpo.GetComponent<SpriteRenderer>().color = Color.yellow;
                        if (Player != null) Player.GetComponent<SpriteRenderer>().color = Color.yellow;
                        break;
                }
            }
        }
      
    }

    
}
