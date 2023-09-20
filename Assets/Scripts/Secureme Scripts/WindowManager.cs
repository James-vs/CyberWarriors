using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject browserGameWindow;
    [SerializeField] private GameObject windows;
    public bool browserExists = false;
    [SerializeField] private GameObject browserInstructions;
    //[SerializeField] private string emailsEnabled = "SMEmailsUnlocked";
    [SerializeField] private GameObject emailsMask;
    [SerializeField] private GameObject emailsInstructions;
    //[SerializeField] private string antiEnabled = "SMAntiUnlocked";
    [SerializeField] private GameObject antiMask;
    [SerializeField] private GameObject antiInstructions;
    [SerializeField] private GameObject completeInstructions;
    [SerializeField] private string gameProgression = "SMProgression";


    private void Start()
    {
        CheckPlayerProgression();
    }


    /// <summary>
    /// function to handle unlocking levels according to player progress
    /// </summary>
    public void CheckPlayerProgression()
    {
        InitialisePlayerPrefsVariables();

        if (PlayerPrefs.GetInt(gameProgression) == 3)
        {
            antiMask.SetActive(false);
            emailsMask.SetActive(false);
            browserInstructions.SetActive(false);
            emailsInstructions.SetActive(false);
            antiInstructions.SetActive(false);
            completeInstructions.SetActive(true);
        }
        if (PlayerPrefs.GetInt(gameProgression) == 2)
        {
            //unlock malware level
            antiMask.SetActive(false);
            emailsMask.SetActive(false);
            browserInstructions.SetActive(false);
            emailsInstructions.SetActive(false);
            antiInstructions.SetActive(true);
        }
        else if (PlayerPrefs.GetInt(gameProgression) == 1)
        {
            //unlock emails level
            UnlockEmails(true);
        }
        else if (PlayerPrefs.GetInt(gameProgression) == 0)
        {
            //lock emails level
            UnlockEmails(false);
        }
        
    }


    /// <summary>
    /// function to initialise game progression playerPrefs variables
    /// </summary>
    public void InitialisePlayerPrefsVariables()
    {
        if (!PlayerPrefs.HasKey(gameProgression))
        {
            PlayerPrefs.SetInt(gameProgression, 0);
        }
    }

    /// <summary>
    /// function to un/lock the email button and ui
    /// </summary>
    /// <param name="value">true/false -> unlock/lock</param>
    public void UnlockEmails(bool value)
    {
        emailsMask.SetActive(!value);
        browserInstructions.SetActive(!value);
        emailsInstructions.SetActive(value);
    }



    /*
    /// <summary>
    /// function to open a game window
    /// </summary>
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
    }*/
}
