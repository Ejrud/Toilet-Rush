using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace LineController
{
    public class LineBuilder : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _linePrefab;

        private InputController _inputController;

        private Line _currentLine;
        private List<Line> _lines = new List<Line>();

        public void Init(InputController controller)
        {
            _inputController = controller;
        }

        public void CreateLine(Color lineColor)
        {
            if (_currentLine != null)
            {
                _lines.Add(_currentLine);
            }

            _currentLine = Instantiate(_linePrefab).GetComponent<Line>();
            _currentLine.Init(lineColor);
        }

        public void Draw()
        {
            if (!_currentLine)
            {
                return;
            }
            
            _currentLine.AddPosition(_camera.ScreenToWorldPoint(Input.mousePosition));
        }

        public Line GetCurrentLine()
        {
            return _currentLine;
        }

        public void DeleteLine()
        {
            Destroy(_currentLine.gameObject);
        }

        public void ResetComponent()
        {
            if (_currentLine != null)
            {
                Destroy(_currentLine.gameObject);
            }

            foreach (Line line in _lines)
            {
                Destroy(line.gameObject);
            }
        }
    }
}