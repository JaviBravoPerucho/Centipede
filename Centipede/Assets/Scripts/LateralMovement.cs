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

        if (_elapsedTime > 1)
        {
            _elapsedTime = 0;
            GameManager.Instance.ReloadBoard();
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
            }
            
        }
    }
}
