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

        if (_elapsedTime > 0.1)
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
                    else if (GameManager.Instance.serpiente[i].X == 1)
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
            /*GameManager.Instance.ReloadBoard();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (!GameManager.Instance.CuadroDeJuego[i, j].actualizado && GameManager.Instance.CuadroDeJuego[i, j].hayCabeza)
                    {
                        Debug.Log(i + ":" + j);
                        switch (GameManager.Instance.CuadroDeJuego[i, j].currentDirection)
                        {
                            case GameManager.Direction.Right:
                                if (j < 19 && !GameManager.Instance.CuadroDeJuego[i, j + 1].haySeta)
                                {
                                    GameManager.Instance.CuadroDeJuego[i, j + 1].currentDirection = GameManager.Direction.Right;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCabeza = false;
                                    GameManager.Instance.CuadroDeJuego[i, j + 1].hayCabeza = true;
                                    GameManager.Instance.CuadroDeJuego[i, j + 1].actualizado = true;
                                }
                                else if (j == 18 && !GameManager.Instance.CuadroDeJuego[i, j + 1].haySeta)
                                {
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].currentDirection = GameManager.Direction.Down;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCabeza = false;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].hayCabeza = true;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].actualizado = true;
                                }
                                else
                                {
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].currentDirection = GameManager.Direction.Down;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCabeza = false;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].hayCabeza = true;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].actualizado = true;

                                }
                                break;

                            case GameManager.Direction.Left:
                                if (!GameManager.Instance.CuadroDeJuego[i, j - 1].haySeta && j > 0)
                                {
                                    GameManager.Instance.CuadroDeJuego[i, j - 1].currentDirection = GameManager.Direction.Left;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCabeza = false;
                                    GameManager.Instance.CuadroDeJuego[i, j - 1].hayCabeza = true;
                                }
                                else
                                {
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].currentDirection = GameManager.Direction.Down;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCabeza = false;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].hayCabeza = true;
                                }
                                break;
                        }
                    }
                    else if (!GameManager.Instance.CuadroDeJuego[i, j].actualizado && GameManager.Instance.CuadroDeJuego[i, j].hayCuerpo)
                    {
                        Debug.Log(i + ":" + j);
                        switch (GameManager.Instance.CuadroDeJuego[i, j].currentDirection)
                        {
                            case GameManager.Direction.Right:
                                if (j < 19 && !GameManager.Instance.CuadroDeJuego[i, j + 1].haySeta)
                                {
                                    GameManager.Instance.CuadroDeJuego[i, j + 1].currentDirection = GameManager.Direction.Right;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCuerpo = false;
                                    GameManager.Instance.CuadroDeJuego[i, j + 1].hayCuerpo = true;
                                    GameManager.Instance.CuadroDeJuego[i, j + 1].actualizado = true;
                                }
                                else if (j == 18 && !GameManager.Instance.CuadroDeJuego[i, j + 1].haySeta)
                                {
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].currentDirection = GameManager.Direction.Down;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCuerpo = false;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].hayCabeza = true;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].actualizado = true;
                                }
                                else
                                {
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].currentDirection = GameManager.Direction.Down;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCuerpo = false;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].hayCuerpo = true;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].actualizado = true;

                                }
                                break;

                            case GameManager.Direction.Left:
                                if (!GameManager.Instance.CuadroDeJuego[i, j - 1].haySeta && j > 0)
                                {
                                    GameManager.Instance.CuadroDeJuego[i, j - 1].currentDirection = GameManager.Direction.Left;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCuerpo = false;
                                    GameManager.Instance.CuadroDeJuego[i, j - 1].hayCuerpo = true;
                                }
                                else
                                {
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].currentDirection = GameManager.Direction.Down;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCuerpo = false;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].hayCuerpo = true;
                                }
                                break;
                        }
                    }
                }
            }*/
            
        }
    }
}
