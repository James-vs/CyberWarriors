using UnityEngine;
using UnityEngine.UI;

public class EnableLevels : MonoBehaviour
{
    [SerializeField] GameObject[] LevelUnlockList;
    [SerializeField] protected string pBProgress = "PBProgress";
    [SerializeField] protected string pBDevMode = "PBDevMode";


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Dev Mode: " + PlayerPrefs.GetInt(pBDevMode));
        if (!PlayerPrefs.HasKey(pBProgress))
        {
            PlayerPrefs.SetInt(pBProgress, 0);
        }
        
        if (PlayerPrefs.GetInt(pBDevMode) == 1)
        {
            UnlockLevelButtons(LevelUnlockList.Length);
        } 
        else
        {
            UnlockLevelButtons(PlayerPrefs.GetInt(pBProgress));
        }
        
    }

    /// <summary>
    /// function to enable level select buttons according to user progress or development mode status
    /// </summary>
    /// <param name="value">number of LS buttons to enable</param>
    private void UnlockLevelButtons(int value)
    {
        for (int i = 1; i <= value; i++)
        {
            if (i > LevelUnlockList.Length) break;
            Debug.Log("Unlocked level " + i);
            var element = LevelUnlockList[i - 1];
            if (element.GetComponent<Button>() != null)
            {
                element.SetActive(true);
            }
            else
            {
                element.SetActive(false);
            }
        }
    }
}
