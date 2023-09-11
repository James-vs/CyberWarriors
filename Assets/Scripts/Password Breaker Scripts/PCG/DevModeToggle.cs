using UnityEngine;
using UnityEngine.UI;

public class DevModeToggle : MonoBehaviour
{
    [SerializeField] protected Toggle devToggle;
    [SerializeField] protected LevelEnd levelEnd;
    [SerializeField] protected string devModeString = "PBDevMode";
    [SerializeField] protected string isUserDevString = "PBIsUserDev";

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Dev Mode Value: " + PlayerPrefs.GetInt(devModeString));
        //CheckForDevUser();
        devToggle.gameObject.SetActive(false);

        
    }

    public void CheckForDevUser()
    {
        if (PlayerPrefs.GetInt(isUserDevString) == 1)
        {
            devToggle.gameObject.SetActive(true);
            CheckForDevMode();
            devToggle = GetComponent<Toggle>();
            // add listener for when the state of the toggle changes and output this to levelEnd DevModeOn() function
            devToggle.onValueChanged.AddListener(delegate
            {
                levelEnd.DevModeOn(devToggle);
            });
        } 
        else
        {
            devToggle.gameObject.SetActive(false);
        }
    }

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
}
