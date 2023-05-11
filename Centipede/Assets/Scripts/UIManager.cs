using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text points;
    [SerializeField]
    private GameObject[] _lifes;
    [SerializeField]
    public GameObject gameOver;
    private int _points = 0;
    static private UIManager uIManager;
    static public UIManager Instance { get { return uIManager; } }
    
    // Start is called before the first frame update
    void Awake()
    {
        uIManager = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        points.SetText("" + _points);
    }
    public void Points(int points)
    {
        _points += points;
    }
    public void ResetPoints()
    {
        _points = 0;
    }
    public void UpdateHud(int lifes)
    {
        _lifes[lifes].SetActive(false);
    }
    public void RegenerateLifes()
    {
        for (int i = 0; i < _lifes.Length; i++)
        {
            _lifes[i].SetActive(true);
        }
        GameManager.Instance.playerLifes = 3;
    }
}
