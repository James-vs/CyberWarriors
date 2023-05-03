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
    private int option;

    // Start is called before the first frame update
    void Start()
    {
        doneBtn.gameObject.SetActive(false);
        acceptAll.GetComponent<Toggle>().Select();
        OnToggleSelect3(true);

    }

    /// <summary>
    /// functions to handle toggle de/selection
    /// </summary>
    /// <param name="selected">bool value for de/select</param>
    public void OnToggleSelect1(bool selected) {
        if (selected == true) {
            acceptAll.GetComponent<Toggle>().interactable = false;
            strictlyNec.GetComponent<Toggle>().interactable = false;
            doneBtn.gameObject.SetActive(true);
            option = 1;
        } else {
            acceptAll.GetComponent<Toggle>().interactable = true;
            strictlyNec.GetComponent<Toggle>().interactable = true;
            doneBtn.gameObject.SetActive(false);
        }
    }
    public void OnToggleSelect2(bool selected) {
        if (selected == true) {
            acceptAll.GetComponent<Toggle>().interactable = false;
            rejectAll.GetComponent<Toggle>().interactable = false;
            doneBtn.gameObject.SetActive(true);
            option = 2;
        } else {
            acceptAll.GetComponent<Toggle>().interactable = true;
            rejectAll.GetComponent<Toggle>().interactable = true;
            doneBtn.gameObject.SetActive(false);
        }
    }
    public void OnToggleSelect3(bool selected) {
        if (selected == true) {
            strictlyNec.GetComponent<Toggle>().interactable = false;
            rejectAll.GetComponent<Toggle>().interactable = false;
            doneBtn.gameObject.SetActive(true);
            option = 0;
        } else {
            strictlyNec.GetComponent<Toggle>().interactable = true;
            rejectAll.GetComponent<Toggle>().interactable = true;
            doneBtn.gameObject.SetActive(false);
        }
    }

    public void SaveAndExit() {
        PlayerPrefs.SetInt(playerPrefsVarName,option);
        Debug.Log(playerPrefsVarName + " option selected: " + PlayerPrefs.GetInt(playerPrefsVarName));
        cookieOptions.SetActive(false);
    }
}
