using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _maxSpeed = 3f;

    public void Animate(string state, float speed, float xDirection)
    {
        FlipByXDirection(xDirection);
        
        _animator.speed = (speed > _maxSpeed) ? _maxSpeed : speed;
        
        switch (state)
        {
            case "idle":
                _animator.SetTrigger("idle");
                break;

            case "run":
                _animator.SetTrigger("run");
                break;

            default:
                _animator.SetTrigger("idle");
                break;
        }
    }

    private void FlipByXDirection(float xDirection)
    {
        if (xDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (xDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
