using UnityEngine;
using UnityEngine.UI;

public class DevModeToggle : MonoBehaviour
{
    [SerializeField] protected Toggle devToggle;
    [SerializeField] protected LevelEnd levelEnd;
    [SerializeField] protected string devModeString = "PBDevMode";

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Dev Mode Value: " + PlayerPrefs.GetInt(devModeString));
        CheckForDevMode();

        devToggle = GetComponent<Toggle>();
        // add listener for when the state of the toggle changes and output this to levelEnd DevModeOn() function
        devToggle.onValueChanged.AddListener(delegate
        {
            levelEnd.DevModeOn(devToggle);
        });
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
