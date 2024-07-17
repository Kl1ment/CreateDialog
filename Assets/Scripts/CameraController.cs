
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    private float _scrollStep = 20;
    private float _minScrol = 20;
    private float _maxScrol = 2000;

    private Vector3 _lastPos;
    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            float cameraSize = _camera.orthographicSize - scroll * _scrollStep;
            cameraSize = Mathf.Clamp(cameraSize, _minScrol, _maxScrol);
            _camera.orthographicSize = cameraSize;
        }

        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(2))
        {
            _lastPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pos = _camera.transform.position;
            pos += _lastPos - mousePos;
            pos.z = -10;
            _camera.transform.position = pos;
        }       
    }
}
