using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] protected GameObject background;
    protected Color backgroundOriginal;
    protected Color incBackground;
    [SerializeField] protected Text dNTText;
    [SerializeField] protected Text incText;
    [SerializeField] protected Text pSText;
    [SerializeField] protected string level;



    // Start is called before the first frame update
    void Start()
    {
        backgroundOriginal = background.GetComponent<Image>().color;
        incBackground = new Color32(72,82,113,255);
        PlayerPrefs.SetInt(level+"DNT",0);
        PlayerPrefs.SetInt(level+"Inc",0);
        PlayerPrefs.SetInt(level+"PS",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // functions to handle browser settings changed
    public void DNTToggle(bool enabled) {
        if (enabled) {
            dNTText.text = "Enabled";
            PlayerPrefs.SetInt(level+"DNT",1);
        } else {
            dNTText.text = "Disabled";
            PlayerPrefs.SetInt(level+"DNT",0);
        }
    }

    public void IncToggle(bool enabled) {
        if (enabled) {
            incText.text = "Enabled";
            PlayerPrefs.SetInt(level+"Inc",1);
            background.GetComponent<Image>().color = incBackground;
        } else {
            incText.text = "Disabled";
            PlayerPrefs.SetInt(level+"Inc",0);
            background.GetComponent<Image>().color = backgroundOriginal;
        }
    }

    public void PSToggle(bool enabled) {
        if (enabled) {
            pSText.text = "Enabled";
            PlayerPrefs.SetInt(level+"PS",1);
        } else {
            pSText.text = "Disabled";
            PlayerPrefs.SetInt(level+"PS",0);
        }
    }
}
