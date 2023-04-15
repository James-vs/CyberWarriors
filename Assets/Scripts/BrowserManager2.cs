using UnityEngine;
using UnityEngine.UI;

public class BrowserManager2 : BrowserManager
{
    [SerializeField] protected GameObject settings;
    [SerializeField] protected Button settingsBtn;


    //function to switch to tab 2
    public override void SwitchToTab2() {
        tab1.SetActive(false);
        tab1Button.GetComponent<Button>().interactable = true;
        tab2.SetActive(true);
        tab2Button.GetComponent<Button>().interactable = false;
        settings.SetActive(false);
        settingsBtn.GetComponent<Button>().interactable = true;
    }

    //function to switch to tab1
    public override void SwitchToTab1(){
        tab2.SetActive(false);
        tab2Button.GetComponent<Button>().interactable = true;
        tab1.SetActive(true);
        tab1Button.GetComponent<Button>().interactable = false;
        settings.SetActive(false);
        settingsBtn.GetComponent<Button>().interactable = true;
    }

    public virtual void SwitchToSettings() {
        tab2.SetActive(false);
        tab2Button.GetComponent<Button>().interactable = true;
        tab1.SetActive(false);
        tab1Button.GetComponent<Button>().interactable = true;
        settings.SetActive(true);
        settingsBtn.GetComponent<Button>().interactable = false;
    }
}
