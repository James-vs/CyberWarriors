using UnityEngine;
using UnityEngine.UI;

public class DevModeToggle : MonoBehaviour
{
    [SerializeField] protected Toggle devToggle;
    [SerializeField] protected LevelEnd levelEnd;
    [SerializeField] protected string devModeString = "PBDevMode";
    [SerializeField] protected string isUserDevString = "PBIsUserDev";
    [SerializeField] protected static bool devModeEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!devModeEnabled) devToggle.gameObject.SetActive(false);
        CheckForDevMode();
        devToggle = GetComponent<Toggle>();
        // add listener for when the state of the toggle changes and output this to levelEnd DevModeOn() function
        devToggle.onValueChanged.AddListener(delegate
        {
            levelEnd.DevModeOn(devToggle);
        });
    }



    /// <summary>
    /// function that checks if the user has permission to use dev mode toggle (UserData isDeveloper variable == true)
    /// </summary>
    public void CheckForDevUser()
    {
        if (PlayerPrefs.GetInt(isUserDevString) == 1)
        {
            devModeEnabled = true;
            PlayerPrefs.SetInt(devModeString, 0);
            CheckForDevMode();
        }
    }


    /// <summary>
    /// function that checks the status of Dev Mode (on/off) and adjusts the toggle accordingly
    /// </summary>
    protected void CheckForDevMode()
    {
        if (PlayerPrefs.GetInt(devModeString) == 1)
        {
            devToggle.isOn = true;
        } else
        {
            devToggle.isOn = false;
        }
    }


    /// <summary>
    /// Setter function for devModeEnabled variable
    /// </summary>
    public void EnableDevMode ()
    {
        devModeEnabled = true;
    }
}
