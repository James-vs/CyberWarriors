using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject browserGameWindow;
    [SerializeField] private GameObject windows;
    public bool browserExists = false;
    [SerializeField] private GameObject browserInstructions;
    [SerializeField] private string emailsEnabled = "SMEmailsUnlocked";
    [SerializeField] private GameObject emailsMask;
    [SerializeField] private GameObject emailsInstructions;
    [SerializeField] private GameObject antiMask;


    private void Start()
    {
        if (PlayerPrefs.HasKey(emailsEnabled))
        {
            if (PlayerPrefs.GetInt(emailsEnabled) == 1)
            {
                //unlock the emails level
                //disable blocker
                emailsMask.SetActive(false);
                browserInstructions.SetActive(false);
                emailsInstructions.SetActive(true);
            } 
            else if (PlayerPrefs.GetInt(emailsEnabled) == 0)
            {
                //lock emails level
                //enable blocker
                emailsMask.SetActive(true);
                browserInstructions.SetActive(true);
                emailsInstructions.SetActive(false);
            }
        } else
        {
            PlayerPrefs.SetInt(emailsEnabled, 0);
            emailsMask.SetActive(true);
            browserInstructions.SetActive(true);
            emailsInstructions.SetActive(false);
        }

    }

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
