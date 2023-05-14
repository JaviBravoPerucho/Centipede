using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaAnimacion : MonoBehaviour
{
    private Animator _animator;
    private int _vida;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _vida= GetComponent<LifeComponent>().vida;
        _animator.SetInteger("vida", _vida);
    }
}
