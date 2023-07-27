using UnityEngine;
using UnityEngine.UI;

public class BrowserManager : MonoBehaviour
{
    [SerializeField] protected GameObject tab1;
    [SerializeField] protected GameObject tab2;
    [SerializeField] protected Button tab1Button;
    [SerializeField] protected Button tab2Button;


    //function to switch to tab 2
    public virtual void SwitchToTab2() {
        tab1.SetActive(false);
        //tab1Button.GetComponent<Button>().interactable = true;
        tab1Button.GetComponent<Image>().color = new Color32(200,200,200,128);
        tab2.SetActive(true);
        //tab2Button.GetComponent<Button>().interactable = false;
        tab2Button.GetComponent<Image>().color = new Color32(255,255,255,255);
    }

    //function to switch to tab1
    public virtual void SwitchToTab1(){
        tab2.SetActive(false);
        //tab2Button.GetComponent<Button>().interactable = true;
        tab2Button.GetComponent<Image>().color = new Color32(200,200,200,128);
        tab1.SetActive(true);
        //tab1Button.GetComponent<Button>().interactable = false;
        tab1Button.GetComponent<Image>().color = new Color32(255,255,255,255);
        
    }

    //function to destroy the current open browser window gameobject
    public void Close() {
        Destroy(gameObject);
    }

}
