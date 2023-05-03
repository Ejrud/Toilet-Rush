using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineController;

[RequireComponent(typeof(LineBuilder))]
public class InputController : MonoBehaviour
{
    private bool _isDraw;
    private LineBuilder _builder;
    private GameController _controller;

    private Character _selectedCharacter;
    private EndPoint _selectedPoint;


    public void Init(LineBuilder builder, GameController controller)
    {
        _builder = builder;
        _controller = controller;
    }
    
    public void PrepareLine(Character character)
    {
        _isDraw = true;
        _selectedCharacter = character;
        _builder.CreateLine(character.color);
    }

    public void AddEndPoint(EndPoint endPoint)
    {
        _selectedPoint = endPoint;
    }

    public void RemoveEndPoint()
    {
        _selectedPoint = null;
    }

    public void ResetComponent()
    {
        _selectedCharacter = null;
        _selectedPoint = null;
    }

    private void Update()
    {
        if (!_isDraw)
        {
            return;   
        }
        
        if (Input.GetMouseButton(0))
        {
            _builder.Draw();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _controller.CheckingForMatches(_selectedCharacter, _selectedPoint);
            ResetComponent();
            _isDraw = false;
        } 
    }
}
