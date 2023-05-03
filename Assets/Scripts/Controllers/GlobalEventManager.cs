using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<bool> OnEndGame = new UnityEvent<bool>();

    public static void EndGame(bool success)
    {
        OnEndGame?.Invoke(success);
    }
}
