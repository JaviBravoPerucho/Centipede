using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioManager : MonoBehaviour
{
    AudioSource _myaudioSource;
    static private AudioManager _audio;

    [SerializeField]
    AudioClip _myshotClip;
    [SerializeField]
    AudioClip _myexplosionClip;
    [SerializeField]
    AudioClip _mydeathClip;

    Disparos _shotAvailable;
    GameManager _playerLifes;

    static public AudioManager Instance { get { return _audio; } }
    int vidas;
    private void Awake()
    {
        _audio = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myaudioSource= GetComponent<AudioSource>();
        vidas = _playerLifes.playerLifes;
    }

    // Update is called once per frame
    void Update()
    {
       /* if (_shotAvailable.disparado_)
        {
            _myaudioSource.PlayOneShot(_myshotClip);
        }

        if (vidas != _playerLifes.playerLifes)
        {
            _myaudioSource.PlayOneShot(_myexplosionClip);
            vidas = _playerLifes.playerLifes;
        }

        if (_playerLifes.playerLifes == 0)
        {
            Invoke("DeathClip", 2.0f);
        }*/
    }

    public void DeathClip()
    {
        _myaudioSource.PlayOneShot(_mydeathClip);
    }
    public void Shot()
    {
        _myaudioSource.PlayOneShot(_myshotClip);
    }
    public void Explosion()
    {
        _myaudioSource.PlayOneShot(_myexplosionClip);
    }
}
