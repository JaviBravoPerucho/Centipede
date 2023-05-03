using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralMovement : MonoBehaviour
{
    private float _elapsedTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > 0.1f)
        {
            _elapsedTime = 0;
            for (int i = 0; i < GameManager.Instance.serpiente.Length; i++)
            {
                Debug.Log("Serpiente:" + GameManager.Instance.serpiente[i].Y + GameManager.Instance.serpiente[i].X);
                if (GameManager.Instance.serpiente[i].currentDirection == GameManager.Direction.Right)
                {
                    if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X + 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;
                        
                    }
                    else if(GameManager.Instance.serpiente[i].X + 1 == 19 && !GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X + 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;
                        
                    }
                    else
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Right;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X + 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;

                    }
                }
                else if (GameManager.Instance.serpiente[i].currentDirection == GameManager.Direction.Left)
                {
                   
                    if (GameManager.Instance.serpiente[i].X - 1 == 1 /*&& !GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X - 1].haySeta*/)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;
                    }
                    else if (GameManager.Instance.serpiente[i].X - 1 >= 1 && GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X - 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;
                    }
                    else
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Left;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                }
                else if (GameManager.Instance.serpiente[i].currentDirection == GameManager.Direction.Down)
                {
                    if( GameManager.Instance.serpiente[i].X >= 18)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Left;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else if (GameManager.Instance.serpiente[i].X == 0)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Right;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X + 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X + 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Left;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X - 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Right;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X + 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y - 1, GameManager.Instance.serpiente[i].X + 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Left;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y - 1, GameManager.Instance.serpiente[i].X - 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Right;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X + 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Right;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }

                }
                else if (GameManager.Instance.serpiente[i].currentDirection == GameManager.Direction.Up)
                {
                    if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X + 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Left;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X - 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Right;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X + 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y + 1, GameManager.Instance.serpiente[i].X + 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Left;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y + 1, GameManager.Instance.serpiente[i].X - 1].haySeta)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Right;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X + 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Right;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X + 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                }
            }
            GameManager.Instance.ReloadBoard();                                                                                                                      
        }
    }
}
