using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{
    [SerializeField]
    private Transform _bulletSpawner;
    [SerializeField]
    private GameObject _bullet;
    private float _time= 0.25f;
    private float _elapsedtime;
    private bool disparado_ = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!disparado_)
            {
                Instantiate(_bullet, _bulletSpawner.position, Quaternion.identity);
                disparado_ = true;
            }
            _elapsedtime += Time.deltaTime;
            if (_elapsedtime > _time)
            {
                disparado_ = false;
                _elapsedtime = 0;
            }

        }
    }

}
