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
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (GameManager.Instance.CuadroDeJuego[i, j].hayCabeza)
                    {
                        switch (GameManager.Instance.CuadroDeJuego[i, j].currentDirection)
                        {
                            case GameManager.Direction.Right:
                                if (!GameManager.Instance.CuadroDeJuego[i, j + 1].haySeta && j < 20)
                                {
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCabeza = false;
                                    GameManager.Instance.CuadroDeJuego[i, j + 1].hayCabeza = true;
                                }
                                else
                                {
                                    GameManager.Instance.CuadroDeJuego[i, j].currentDirection = GameManager.Direction.Down;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCabeza = false;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].hayCabeza = true;
                                }
                                break;

                            case GameManager.Direction.Left:
                                if (!GameManager.Instance.CuadroDeJuego[i, j - 1].haySeta && j > 0)
                                {
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCabeza = false;
                                    GameManager.Instance.CuadroDeJuego[i, j - 1].hayCabeza = true;
                                }
                                else
                                {
                                    GameManager.Instance.CuadroDeJuego[i, j].currentDirection = GameManager.Direction.Down;
                                    GameManager.Instance.CuadroDeJuego[i, j].hayCabeza = false;
                                    GameManager.Instance.CuadroDeJuego[i + 1, j].hayCabeza = true;
                                }
                                break;
                        }
                    }
                }
            }
            _elapsedTime= 0;
        }
    }
}
