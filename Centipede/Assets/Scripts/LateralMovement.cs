using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralMovement : MonoBehaviour
{
    private float _elapsedTime = 0;
    public bool goesUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > 0.2f)
        {
            _elapsedTime = 0;
            for (int i = 0; i < GameManager.Instance.serpiente.Length; i++)
            {
                Debug.Log("Serpiente:" + GameManager.Instance.serpiente[i].Y + GameManager.Instance.serpiente[i].X);
                if (GameManager.Instance.serpiente[i].currentDirection == GameManager.Direction.Right)
                {
                    if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X + 1].haySeta)
                    {
                        if (!GameManager.Instance.serpiente[i].goesUp)
                        {
                            GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                            GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                            GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;
                        }
                        else
                        {
                            GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Up;
                            GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                            GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y - 1;

                        }
                    }
                    else if (GameManager.Instance.serpiente[i].X + 1 == 19 && !GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X + 1].haySeta)
                    {
                        if (!GameManager.Instance.serpiente[i].goesUp)
                        {
                            GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                            GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                            GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;
                        }
                        else
                        {
                            GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Up;
                            GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                            GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y - 1;
                        }

                    }                 
                    else
                    {
                        bool cambia = false;
                        for (int j = 0; j < GameManager.Instance.serpiente.Length; j++)
                        {
                            if(GameManager.Instance.serpiente[i].X + 1 == GameManager.Instance.serpiente[j].X && GameManager.Instance.serpiente[i].Y == GameManager.Instance.serpiente[j].Y && GameManager.Instance.serpiente[j].currentDirection == GameManager.Direction.Left)
                            {
                                cambia = true;
                            }
                        }
                        if(cambia)
                        {
                            if (!GameManager.Instance.serpiente[i].goesUp)
                            {
                                GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                                GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                                GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;
                            }
                            else
                            {
                                GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Up;
                                GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                                GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y - 1;
                            }
                        }
                        else
                        {
                            GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Right;
                            GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X + 1;
                            GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                        }
                       

                    }
                }
                else if (GameManager.Instance.serpiente[i].currentDirection == GameManager.Direction.Left)
                {
                   
                    if (GameManager.Instance.serpiente[i].X - 1 < 0 /*&& !GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X - 1].haySeta*/)
                    {
                        if (!GameManager.Instance.serpiente[i].goesUp)
                        {
                            GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                            GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                            GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;
                        }
                        else
                        {
                            GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                            GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y - 1;
                            GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Up;
                        }
                       
                    }
                    else if (GameManager.Instance.serpiente[i].X - 1 >= 1 && GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X - 1].haySeta)
                    {
                        if (!GameManager.Instance.serpiente[i].goesUp)
                        {
                            GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                            GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                            GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;
                        }
                        else
                        {
                            GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                            GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y - 1;
                            GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Up;
                        }
               
                    }
                    else
                    {
                        bool cambia = false;
                        for (int j = 0; j < GameManager.Instance.serpiente.Length; j++)
                        {
                            if (GameManager.Instance.serpiente[i].X - 1 == GameManager.Instance.serpiente[j].X && GameManager.Instance.serpiente[i].Y == GameManager.Instance.serpiente[j].Y && GameManager.Instance.serpiente[j].currentDirection == GameManager.Direction.Right)
                            {
                                cambia = true;
                            }
                        }
                        if (cambia)
                        {
                            if (!GameManager.Instance.serpiente[i].goesUp)
                            {
                                GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                                GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                                GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;
                            }
                            else
                            {
                                GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Up;
                                GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                                GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y - 1;
                            }
                        }
                        else
                        {
                            GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Left;
                            GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                            GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                        }
                    }
                    /*if (GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X - 1].haySeta)
                    {
                        if (!goesUp) GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                        else GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Up;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;

                    }
                    else if (GameManager.Instance.serpiente[i].X - 1 == 0 && !GameManager.Instance.CuadroDeJuego[GameManager.Instance.serpiente[i].Y, GameManager.Instance.serpiente[i].X - 1].haySeta)
                    {
                        if (!goesUp) GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                        else GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Up;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;

                    }
                    else
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Left;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;

                    }*/
                }
                else if (GameManager.Instance.serpiente[i].currentDirection == GameManager.Direction.Down)
                {
                    if(GameManager.Instance.serpiente[i].Y == 19)
                    {
                        GameManager.Instance.copia[i].goesUp = true;
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Up;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y - 1;
                    }
                    else if( GameManager.Instance.serpiente[i].X >= 18)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Left;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else if (GameManager.Instance.serpiente[i].X <= 0)
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
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X + 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }

                }
                else if (GameManager.Instance.serpiente[i].currentDirection == GameManager.Direction.Up)
                {
                    if (GameManager.Instance.serpiente[i].Y == 0)
                    {
                        GameManager.Instance.copia[i].goesUp = false;
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Down;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y + 1;

                    }
                    else if (GameManager.Instance.serpiente[i].X >= 18)
                    {
                        GameManager.Instance.copia[i].currentDirection = GameManager.Direction.Left;
                        GameManager.Instance.copia[i].X = GameManager.Instance.serpiente[i].X - 1;
                        GameManager.Instance.copia[i].Y = GameManager.Instance.serpiente[i].Y;
                    }
                    else if (GameManager.Instance.serpiente[i].X <= 0)
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
               /* if (GameManager.Instance.copia[i].isHead)
                {
                    if (GameManager.Instance.copia[i].Y > 15) GameManager.Instance.copia[i].goesUp = true;
                    else if (GameManager.Instance.copia[i].Y < 5) GameManager.Instance.copia[i].goesUp = false;
                } */
            }
            GameManager.Instance.ReloadBoard();                                                                                                                      
        }

        
    }
}
