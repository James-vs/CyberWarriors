using UnityEngine;
using UnityEngine.UI;

public class CookieManager : MonoBehaviour
{
    [SerializeField] private GameObject cookieOptions;
    [SerializeField] private GameObject acceptAll;
    [SerializeField] private GameObject rejectAll;
    [SerializeField] private GameObject strictlyNec;
    [SerializeField] private Button doneBtn;
    [SerializeField] private string playerPrefsVarName;
    //[SerializeField] private Color normal;
    //[SerializeField] private Color notSelected = new Color(125, 125, 125, 128);
    private int option;

    // Start is called before the first frame update
    void Start()
    {
        doneBtn.gameObject.SetActive(false);
        acceptAll.GetComponent<Toggle>().Select();
        //normal = acceptAll.GetComponent<Toggle>().colors.normalColor;
        OnToggleSelect3(true);

    }

    /// <summary>
    /// functions to handle toggle de/selection
    /// </summary>
    /// <param name="selected">bool value for de/select</param>
    public void OnToggleSelect1(bool selected) {
        if (selected == true) {
            Activate(1);
        } else {
            //acceptAll.GetComponent<Toggle>().interactable = true;
            /*var aColors = acceptAll.GetComponent<Toggle>().colors;
            aColors.normalColor = normal;
            acceptAll.GetComponent<Toggle>().colors = aColors;
            //strictlyNec.GetComponent<Toggle>().interactable = true;
            var sColors = strictlyNec.GetComponent<Toggle>().colors;
            sColors.normalColor = normal;
            strictlyNec.GetComponent<Toggle>().colors = sColors;*/
            doneBtn.gameObject.SetActive(false);
        }
    }
    public void OnToggleSelect2(bool selected) {
        if (selected == true) {
            Activate(2);
        } else {
            //acceptAll.GetComponent<Toggle>().interactable = true;
            /*var aColors = acceptAll.GetComponent<Toggle>().colors;
            aColors.normalColor = normal;
            acceptAll.GetComponent<Toggle>().colors = aColors;
            //rejectAll.GetComponent<Toggle>().interactable = true;
            var rColors = rejectAll.GetComponent<Toggle>().colors;
            rColors.normalColor = normal;
            rejectAll.GetComponent<Toggle>().colors = rColors;*/
            doneBtn.gameObject.SetActive(false);
        }
    }
    public void OnToggleSelect3(bool selected) {
        if (selected == true) {
            Activate(3);
        } else {
            //strictlyNec.GetComponent<Toggle>().interactable = true;
            /*var sColors = strictlyNec.GetComponent<Toggle>().colors;
            sColors.normalColor = normal;
            strictlyNec.GetComponent<Toggle>().colors = sColors;*/
            //rejectAll.GetComponent<Toggle>().interactable = true;
            /*var rColors = rejectAll.GetComponent<Toggle>().colors;
            rColors.normalColor = normal;
            rejectAll.GetComponent<Toggle>().colors = rColors;*/
            doneBtn.gameObject.SetActive(false);
        }
    }

    public void SaveAndExit() {
        PlayerPrefs.SetInt(playerPrefsVarName,option);
        Debug.Log(playerPrefsVarName + " option selected: " + PlayerPrefs.GetInt(playerPrefsVarName));
        cookieOptions.SetActive(false);
    }

    private void Activate(int option)
    {
        if (option == 1)
        {
            //acceptAll.GetComponent<Toggle>().interactable = false;
            /*var aColors = acceptAll.GetComponent<Toggle>().colors;
            aColors.normalColor = notSelected;
            acceptAll.GetComponent<Toggle>().colors = aColors;*/
            acceptAll.GetComponent<Toggle>().isOn = false;
            //strictlyNec.GetComponent<Toggle>().interactable = false;
            /*var sColors = strictlyNec.GetComponent<Toggle>().colors;
            sColors.normalColor = notSelected;
            strictlyNec.GetComponent<Toggle>().colors = sColors;*/
            strictlyNec.GetComponent<Toggle>().isOn = false;


            doneBtn.gameObject.SetActive(true);
            this.option = 1;
        } 
        else if (option == 2)
        {
            //acceptAll.GetComponent<Toggle>().interactable = false;
            /*var aColors = acceptAll.GetComponent<Toggle>().colors;
            aColors.normalColor = notSelected;
            acceptAll.GetComponent<Toggle>().colors = aColors;*/
            acceptAll.GetComponent<Toggle>().isOn = false;
            //rejectAll.GetComponent<Toggle>().interactable = false;
            /*var rColors = rejectAll.GetComponent<Toggle>().colors;
            rColors.normalColor = notSelected;
            rejectAll.GetComponent<Toggle>().colors = rColors;*/
            rejectAll.GetComponent<Toggle>().isOn = false;

            doneBtn.gameObject.SetActive(true);
            this.option = 2;
        }
        else if (option == 3)
        {
            //strictlyNec.GetComponent<Toggle>().interactable = false;
            /*var sColors = strictlyNec.GetComponent<Toggle>().colors;
            sColors.normalColor = notSelected;
            strictlyNec.GetComponent<Toggle>().colors = sColors;*/
            strictlyNec.GetComponent<Toggle>().isOn = false;

            //rejectAll.GetComponent<Toggle>().interactable = false;
            /*var rColors = rejectAll.GetComponent<Toggle>().colors;
            rColors.normalColor = notSelected;
            rejectAll.GetComponent<Toggle>().colors = rColors;*/
            rejectAll.GetComponent<Toggle>().isOn = false;

            doneBtn.gameObject.SetActive(true);
            this.option = 0;
        }
        else
        {
            Debug.Log("Cookie Selection Error");
        }
    }
}
