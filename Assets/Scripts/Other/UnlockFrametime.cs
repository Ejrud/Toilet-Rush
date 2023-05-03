using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockFrametime : MonoBehaviour
{
    private void Awake () {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 120;
    }
}
