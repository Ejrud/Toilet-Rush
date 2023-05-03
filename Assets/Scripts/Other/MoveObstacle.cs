using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _endPosition;

    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, _endPosition, _speed * Time.deltaTime);

        if (transform.localPosition == _endPosition)
            transform.localPosition = _startPosition;
    }
}
