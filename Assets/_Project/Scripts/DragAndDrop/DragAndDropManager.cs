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
        private Vector3 mousePositionWorld;
        private Vector3 mousePositionScreen;

        private Vector3 _currentVelocity;
        private Vector3 _lastPosition;


        public float drag_hight;
        public float _coefVelocity;

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
                //_initialY = _currentObject.transform.position.y;
                //_currentObject.transform.position = new Vector3(
                //    _currentObject.transform.position.x,
                //    _initialY + 5,
                //    _currentObject.transform.position.z);

                //_plane = new Plane(_camera.transform.forward, _currentObject.transform.position);
                Vector3 new_pos = _currentObject.transform.position;
                new_pos.y = drag_hight;
                //new_pos -= drag_hight * _camera.transform.forward;
                _plane = new Plane(_camera.transform.forward, new_pos); 

                float distance;

                _plane.Raycast(cameraRay, out distance);
                _currentObject.transform.position = cameraRay.GetPoint(distance);

                _offset = _currentObject.transform.position - cameraRay.GetPoint(distance);
                _lastPosition = _currentObject.transform.position;
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
            newPosition.y = _initialY + drag_hight;
            _currentObject.transform.position = newPosition;

            _currentVelocity = (newPosition - _lastPosition) / Time.deltaTime;
            _lastPosition = newPosition;
        }

        private void Drop()
        {
            if (_currentObject == null)
                return;

            //_currentObject.transform.position = new Vector3(
            //    _currentObject.transform.position.x,
            //    _currentObject.transform.position.y,
            //    _currentObject.transform.position.z
            //);
            _currentObject.GetComponent<Rigidbody>().velocity = _currentVelocity * _coefVelocity;


            _currentObject = null;
        }
    }
}