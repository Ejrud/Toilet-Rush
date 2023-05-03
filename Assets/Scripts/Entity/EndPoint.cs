using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public Gender gender;
    public bool routeIsPaved;
    private InputController _inputController;

    public void Init(InputController controller)
    {
        _inputController = controller;
    }

    private void OnMouseEnter()
    {
        if (routeIsPaved)
        {
            return;
        }

        _inputController.AddEndPoint(this);
    }

    private void OnMouseExit()
    {
        if (routeIsPaved)
        {
            return;
        }

        _inputController.RemoveEndPoint();
    }
}
