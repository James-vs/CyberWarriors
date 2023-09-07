using UnityEngine;
using UnityEngine.UI;

public class BrowserManager2 : BrowserManager
{
    [SerializeField] protected GameObject settings;
    [SerializeField] protected Button settingsBtn;


    private void Start()
    {
        SwitchToSettings();
    }

    //function to switch to tab 2
    public override void SwitchToTab2() {
        tab1.SetActive(false);
        //tab1Button.GetComponent<Button>().interactable = true;
        tab1Button.GetComponent<Image>().color = new Color32(200, 200, 200, 128);
        tab2.SetActive(true);
        //tab2Button.GetComponent<Button>().interactable = false;
        tab2Button.GetComponent<Image>().color = new Color32(255, 255, 255, 255);        
        settings.SetActive(false);
        //settingsBtn.GetComponent<Button>().interactable = true;
        settingsBtn.GetComponent<Image>().color = new Color32(200, 200, 200, 128);
    }

    //function to switch to tab 1
    public override void SwitchToTab1(){
        settings.SetActive(false);
        //settingsBtn.GetComponent<Button>().interactable = true;
        settingsBtn.GetComponent<Image>().color = new Color32(200, 200, 200, 128);
        tab2.SetActive(false);
        //tab2Button.GetComponent<Button>().interactable = true;
        tab2Button.GetComponent<Image>().color = new Color32(200, 200, 200, 128);
        tab1.SetActive(true);
        //tab1Button.GetComponent<Button>().interactable = false;
        tab1Button.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public virtual void SwitchToSettings() {
        tab2.SetActive(false);
        //tab2Button.GetComponent<Button>().interactable = true;
        tab2Button.GetComponent<Image>().color = new Color32(200, 200, 200, 128);
        tab1.SetActive(false);
        //tab1Button.GetComponent<Button>().interactable = true;
        tab1Button.GetComponent<Image>().color = new Color32(200, 200, 200, 128);
        settings.SetActive(true);
        //settingsBtn.GetComponent<Button>().interactable = false;
        settingsBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

    }
}
