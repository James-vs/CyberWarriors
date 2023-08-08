using UnityEngine;
using UnityEngine.UI;

public class EnableLevels : MonoBehaviour
{
    /*[SerializeField] GameObject blockerL2;
    [SerializeField] GameObject blockerL3;
    [SerializeField] Button Level4;
    [SerializeField] GameObject blockerL5;
    [SerializeField] Button Level6;
    [SerializeField] GameObject blockerL7;
    [SerializeField] Button Level8;
    [SerializeField] GameObject blockerL9;
    [SerializeField] Button Level10;
    [SerializeField] Button Level11;*/
    [SerializeField] GameObject[] LevelUnlockList;


    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("PBProgress")) 
        {
            PlayerPrefs.SetInt("PBProgress", 0);
        }
        else 
        {
            for (int i = 1; i <= PlayerPrefs.GetInt("PBProgress"); i++)
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
}
