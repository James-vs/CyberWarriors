using UnityEngine;

public class BrowserManager : MonoBehaviour
{
    [SerializeField] private GameObject tab1;
    [SerializeField] private GameObject tab2;

    //function to switch to tab 2
    public void SwitchToTab2() {
        tab1.SetActive(false);
        tab2.SetActive(true);
    }

    //function to switch to tab1
    public void SwitchToTab1(){
        tab1.SetActive(true);
        tab2.SetActive(false);
    }

    //function to destroy the current open browser window gameobject
    public void Close() {
        Destroy(gameObject);
    }


}
