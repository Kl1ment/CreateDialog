
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void Start()
    {
        Screen.fullScreen = true;
    }

    public void ExitProgramm()
    {
        Application.Quit();
    }
}
