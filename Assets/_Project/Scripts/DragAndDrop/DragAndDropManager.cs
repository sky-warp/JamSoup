using _Project.Scripts.PauseMenu;
using UnityEngine;

namespace _Project.Scripts.DragAndDrop
{
    public class DragAndDropManager : MonoBehaviour
    {
        [SerializeField] private PauseMenuController _pauseMenuController;

        private Collider _currentObject;
        private Camera _camera;
        private Plane _plane;
        private bool _isDragging;
        private Vector3 _offset;
        private float _initialY;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_pauseMenuController.IsPaused)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
                Select();

            if (Input.GetMouseButtonUp(0))
                Drop();

            DragAndDrop();
        }

        private void Select()
        {
            RaycastHit hit;

            Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out hit, Mathf.Infinity, LayerMask.GetMask("Vegetables")))
            {
                _currentObject = hit.collider;
                
                _initialY = _currentObject.transform.position.y;
                _currentObject.transform.position = new Vector3(
                    _currentObject.transform.position.x, 
                    _initialY + 5, 
                    _currentObject.transform.position.z);
                
                _plane = new Plane(_camera.transform.forward, _currentObject.transform.position);
                float distance;
                _plane.Raycast(cameraRay, out distance);
                _offset = _currentObject.transform.position - cameraRay.GetPoint(distance);
            }
            else
            {
                _currentObject = null;
            }
        }

        private void DragAndDrop()
        {
            if (_currentObject == null)
            {
                Cursor.visible = true;
                return;
            }

            Cursor.visible = false;
            Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);

            float distance;
            _plane.Raycast(cameraRay, out distance);
            Vector3 newPosition = cameraRay.GetPoint(distance) + _offset;
            newPosition.y = _initialY + 5;
            _currentObject.transform.position = newPosition;
        }

        private void Drop()
        {
            if (_currentObject == null)
                return;

            _currentObject.transform.position = new Vector3(
                _currentObject.transform.position.x,
                _currentObject.transform.position.y,
                _currentObject.transform.position.z
            );

            _currentObject = null;
        }
    }
}