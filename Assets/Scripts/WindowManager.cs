using UnityEngine;
using TMPro;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject browserWindow;
    [SerializeField] private GameObject windows;
    
    //function to open a game window
    public void OpenBrowserWindow() {
        //obj.SetActive(true);
        Instantiate(browserWindow,windows.transform.position,windows.transform.rotation,windows.transform);
    }

    public void OpenWindow(GameObject window) {
        window.SetActive(true);
    }

    //function to close a window
    public void CloseWindow(GameObject obj) {
        obj.SetActive(false);
    }
}
