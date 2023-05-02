using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject browserGameWindow;
    [SerializeField] private GameObject windows;
    public bool browserExists = false;
    
    //function to open a game window
    public void OpenBrowserWindow() {
        if (!browserExists) {
            Instantiate(browserGameWindow,new Vector2(windows.transform.position.x - 220, windows.transform.position.y + 75),windows.transform.rotation,windows.transform);
            browserExists = true;        
        }
    }

    public void OpenWindow(GameObject window) {
        window.SetActive(true);
    }

    //function to close a window
    public void CloseWindow(GameObject obj) {
        obj.SetActive(false);
    }
}
