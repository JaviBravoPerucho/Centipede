using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spewnerenemigo : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spawner;
    private int _random;
    private float _time = 8;
    private float _elapsedtime;
    [SerializeField]
    private GameObject _enemigo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedtime += Time.deltaTime;
        if(_elapsedtime> _time)
        {
            Instantiate(_enemigo, _spawner[Random.Range(0, 7)].position, Quaternion.identity);
            _elapsedtime = 0;
        }
        
    }
}
