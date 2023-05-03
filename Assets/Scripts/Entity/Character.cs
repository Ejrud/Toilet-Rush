using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineController;
public class Character : MonoBehaviour
{
    public float moveSpeed { get; set; } 
    public Line line { get; set; }
    public int currentWaypoint { get; set; }

    public bool routeIsPaved;
    public Gender gender;
    public Color color;
    private CharacterAnimation _characterAnimation;
    private InputController _inputController;
    private MoveController _moveController;
    
    public void Animate(string state, float speed, float xDirection)
    {  
        _characterAnimation.Animate(state, speed, xDirection);
    }

    public void Init(InputController inputController, MoveController moveController)
    {
        _characterAnimation = GetComponent<CharacterAnimation>();
        _inputController = inputController;
        _moveController = moveController;
    }

    private void OnMouseDown()
    {
        if (routeIsPaved)
        {
            return;
        }

        Debug.Log("Draw line");
        _inputController.PrepareLine(this);
    }
}
