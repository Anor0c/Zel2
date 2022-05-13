using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator _animator;
    PlayerMove playerSpeed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        playerSpeed = GetComponent<PlayerMove>();
    }
    private void Update()
    {
        _animator.SetFloat("RealSpeed", playerSpeed.stickDirection.magnitude);
    }
}
