using TMPro;
using UnityEngine;

public class SaveFile : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_InputField _path;

    public string Name => $"{_name.text}.json";

    public void SetActive()
    {
        _name.text = "";
        _path.text = "";

        _panel.SetActive(true);
    }

    public void DisActive()
    {
        _panel.SetActive(false);
    }

    public void StartWriting()
    {
        _path.image.color = Color.white;
    }

    public void WrongPath()
    {
        _path.image.color = Color.red;
    }

    public string GetPath()
    {
        string path = _path.text.Replace('\\', '/');

        return $"{path}";
    }
}
