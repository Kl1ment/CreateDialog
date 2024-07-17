
using UnityEngine;

[RequireComponent (typeof(CreatorReplicas))]
public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private CreatorReplicas _creatorReplica;

    private Camera _camera;
    private Vector2 _scale = Vector2.one;
    private Vector2 _position;

    private void Start()
    {
        _camera = Camera.main;
        _scale = _scale / _camera.orthographicSize;

        _creatorReplica = GetComponent<CreatorReplicas>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _position = _camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = _position;
            transform.localScale = _scale * _camera.orthographicSize;
            _menu.transform.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _menu.transform.gameObject.SetActive(false);
        }
    }

    public void CreateReplica()
    {
        _creatorReplica.CreateNewReplica(_position);
    }
}
