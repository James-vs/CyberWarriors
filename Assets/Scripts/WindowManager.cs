using UnityEngine;
using TMPro;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject browserWindow;
    [SerializeField] private GameObject windows;
    
    //function to open a game window
    public void OpenBrowserWindow() {
        //obj.SetActive(true);
        Instantiate(browserWindow,new Vector2(windows.transform.position.x - 220, windows.transform.position.y + 75),windows.transform.rotation,windows.transform);
    }

    public void OpenWindow(GameObject window) {
        window.SetActive(true);
    }

    //function to close a window
    public void CloseWindow(GameObject obj) {
        obj.SetActive(false);
    }
}
