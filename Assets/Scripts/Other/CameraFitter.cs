using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFitter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _fitArea;
    [SerializeField] private float _zPosition;

    private void Start()
    {
        FitOnScreen();
    }
    
    [ContextMenu("Fit")]
    private void FitOnScreen()
    {
        Bounds bound = GetBound(_fitArea);
        Vector3 boundSize = bound.size;
        float diagonal = Mathf.Sqrt(boundSize.x * boundSize.x + boundSize.y * boundSize.y + boundSize.z * boundSize.z);
        
        _camera.orthographicSize = diagonal / 1.2f;
        _camera.transform.position = new Vector3(bound.center.x, bound.center.y, _zPosition);
    }

    private Bounds GetBound(GameObject gameObj)
    {
        Bounds bounds = new Bounds(gameObj.transform.position, Vector3.zero);
        var rList = gameObj.GetComponentsInChildren(typeof(Renderer));
        foreach (Renderer r in rList)
        {
            bounds.Encapsulate(r.bounds);
        }
        return bounds;
    }
}
