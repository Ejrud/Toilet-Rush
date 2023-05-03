using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineController;

[RequireComponent(typeof(LineBuilder))]
[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(SceneReloader))]
[RequireComponent(typeof(MoveController))]

public class GameController : MonoBehaviour
{
    // Links
    [SerializeField] private VictoryUI _victoryUI;
    [SerializeField] private Character[] _characters;
    [SerializeField] private EndPoint[] _endPoints; 


    // Components
    private LineBuilder _lineBuilder;
    private InputController _inputController;
    private SceneReloader _sceneReloader;
    private MoveController _moveController;


    public void CheckingForMatches(Character character, EndPoint endPoint)
    {
        if (character == null || endPoint == null)
        {
            _lineBuilder.DeleteLine();
            return;
        }

        if (character.gender != endPoint.gender && endPoint.gender != Gender.NoneBinary)
        {
            _lineBuilder.DeleteLine();
            return;
        }

        character.line = _lineBuilder.GetCurrentLine();
        character.routeIsPaved = true;
        endPoint.routeIsPaved = true;

        DidAllMakeTheRoad();
    }


    private void Start()
    {
        InitializeComponents();
        GlobalEventManager.OnEndGame.AddListener(EndGame);
    }

    private void EndGame(bool success)
    {
        if (!success)
        {
            _moveController.StopMove();
            _victoryUI.SetWindowVictory(false);
            Debug.Log("Loose");
            return;
        }

        int count = 0;
        foreach (EndPoint endPoint in _endPoints)
        {
            if (endPoint.routeIsPaved)
                count++;
        }

        if (count >= _endPoints.Length)
        {
            _victoryUI.SetWindowVictory(true);
        }
    }
    
    private void DidAllMakeTheRoad()
    {
        int maxValue = _characters.Length; 
        int counter = 0;

        foreach (Character unit in _characters)
        {
            if(unit.routeIsPaved)
                counter++;
        }

        if (counter >= maxValue)
        {
            Debug.Log("Start");
            _moveController.Move();

            // Start walk
        }
    }

    private void InitializeComponents()
    {
        _lineBuilder = GetComponent<LineBuilder>();
        _sceneReloader = GetComponent<SceneReloader>();
        _inputController = GetComponent<InputController>(); // 
        _moveController = GetComponent<MoveController>(); // 

        _inputController.Init(_lineBuilder, this);
        _lineBuilder.Init(_inputController);
        _moveController.Init(_characters);

        foreach (Character character in _characters)
        {
            character.Init(_inputController, _moveController);
        }

        foreach (EndPoint endPoint in _endPoints)
        {
            endPoint.Init(_inputController);
        }
    }

    private void OnDisable()
    {
        GlobalEventManager.OnEndGame.RemoveListener(EndGame);
    }
}
