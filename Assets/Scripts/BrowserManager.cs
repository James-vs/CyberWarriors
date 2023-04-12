using UnityEngine;
using UnityEngine.UI;

public class BrowserManager : MonoBehaviour
{
    [SerializeField] private GameObject tab1;
    [SerializeField] private GameObject tab2;
    [SerializeField] private Button tab1Button;
    [SerializeField] private Button tab2Button;


    //function to switch to tab 2
    public void SwitchToTab2() {
        tab1.SetActive(false);
        tab1Button.GetComponent<Button>().interactable = true;
        tab2.SetActive(true);
        tab2Button.GetComponent<Button>().interactable = false;
    }

    //function to switch to tab1
    public void SwitchToTab1(){
        tab2.SetActive(false);
        tab2Button.GetComponent<Button>().interactable = true;
        tab1.SetActive(true);
        tab1Button.GetComponent<Button>().interactable = false;
        
    }

    //function to destroy the current open browser window gameobject
    public void Close() {
        Destroy(gameObject);
    }


}
