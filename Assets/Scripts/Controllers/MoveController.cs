using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float _moveTime;
    private bool _isMove;
    private Character[] _characters;
    private float _elapsedTime;

    public void Init(Character[] characters)
    {
        _characters = characters;
    }

    public void Move()
    {
        foreach (Character character in _characters)
        {
            character.moveSpeed = character.line.GetDistance() / _moveTime;
            character.currentWaypoint = 0;
        }

        _isMove = true;
    }

    public void StopMove()
    {
        foreach (Character character in _characters)
        {
            character.Animate("idle", 1, 1);
        }

        _isMove = false;
    }

    private void Update()
    {
        if (!_isMove)
        {
            StopMove();
            return;
        }

        int completeCount = 0;

        foreach (Character character in _characters)
        {
            if (character.currentWaypoint >= character.line.GetCount())
            {
                completeCount++;
                continue;
            }

            Vector3 target = character.line.GetPositionByIndex(character.currentWaypoint);
            character.transform.position = Vector3.MoveTowards(character.transform.position, target, character.moveSpeed * Time.deltaTime);

            if (character.transform.position == target)
            {
                character.currentWaypoint++;
            }
            

            Vector3 currentPosition = (character.currentWaypoint == 0) ? target : character.line.GetPositionByIndex(character.currentWaypoint - 1);
            Vector3 direction = currentPosition.normalized - target.normalized;
            character.Animate("run", character.moveSpeed, direction.x);
        }

        if (completeCount >= _characters.Length)
        {
            StopMove();
            GlobalEventManager.EndGame(true);
        }
    }
}
