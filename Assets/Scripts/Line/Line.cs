using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LineController
{
    public class Line : MonoBehaviour
    {
        [SerializeField] private float _positionOffset = .15f;
        private LineRenderer _lineRenderer;
        private float _distance = 0;

        public void Init(Color lineColor)
        {
            if(!TryGetComponent<LineRenderer>(out LineRenderer line))
            {
                Debug.LogError("Failed to find LineRenderer component");
                return;
            }

            _lineRenderer = line;
            _lineRenderer.startColor = lineColor;
            _lineRenderer.endColor = lineColor;
            _lineRenderer.positionCount = 0;
        }

        public void AddPosition(Vector3 position)
        {
            Vector3 cursorPosition = new Vector3(position.x, position.y, 0);

            if (_lineRenderer.positionCount != 0)
            {
                if (Vector3.Distance(_lineRenderer.GetPosition(_lineRenderer.positionCount - 1), cursorPosition) < _positionOffset)
                {
                    return;
                }
                
                _distance += Vector3.Distance(_lineRenderer.GetPosition(_lineRenderer.positionCount - 1), cursorPosition);
            }

            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, cursorPosition);
        }

        public int GetCount()
        {
            return _lineRenderer.positionCount;
        }

        public float GetDistance()
        {
            return _distance;
        }

        public Vector3 GetPositionByIndex(int index)
        {
            return _lineRenderer.GetPosition(index);
        }
    }
}

