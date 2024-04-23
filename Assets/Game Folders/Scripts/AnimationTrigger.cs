using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private PlayerAttack _playerAttack;

    private void Start()
    {
        _playerAttack = GetComponentInParent<PlayerAttack>();
    }

    public void GetAnimationEvent()
    {
        _playerAttack.Attack();
    }
}
