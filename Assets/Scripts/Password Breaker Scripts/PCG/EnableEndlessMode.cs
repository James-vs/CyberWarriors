using UnityEngine;
using UnityEngine.UI;

public class EnableEndlessMode : MonoBehaviour
{
    [SerializeField] Button endlessButton;
    [SerializeField] GameObject blocker;
    [SerializeField] protected string normalModeComplete = "PBNormModeComplete";
    [SerializeField] protected string devModeString = "PBDevMode";

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(devModeString) == 1)
        {
            endlessButton.enabled = true;
            blocker.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(normalModeComplete) == 0)
        {
            endlessButton.enabled = false;
            blocker.SetActive(true);
        } 
        else if (PlayerPrefs.GetInt(normalModeComplete) == 1 || PlayerPrefs.GetInt(normalModeComplete) == 2)
        {
            endlessButton.enabled = true;
            blocker.SetActive(false);
        } 
        else
        {
            Debug.Log("Error with PlayerPrefs " + normalModeComplete + " variable in EnableEndlessMode Script");
        }
    }
}
