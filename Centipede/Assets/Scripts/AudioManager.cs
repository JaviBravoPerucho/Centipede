using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource _myaudioSource;
    // Start is called before the first frame update
    void Start()
    {
        _myaudioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
