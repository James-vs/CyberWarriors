using UnityEngine;

public class InfoPageManager : MonoBehaviour
{
    [SerializeField] protected GameObject malwareSelectPage;
    [SerializeField] protected GameObject virusInfoPage;
    [SerializeField] protected GameObject trojanInfoPage;
    [SerializeField] protected GameObject ransomInfoPage;
    



    // function to take player back to info page select 
    public void Back() {
        malwareSelectPage.SetActive(true);
        virusInfoPage.SetActive(false);
        trojanInfoPage.SetActive(false);
        ransomInfoPage.SetActive(false);
    }




    // functions to open associated info pages
    public void OpenVirusInfo() {
        malwareSelectPage.SetActive(false);
        virusInfoPage.SetActive(true);
    }
    public void OpenTrojanInfo() {
        malwareSelectPage.SetActive(false);
        trojanInfoPage.SetActive(true);
    }
    public void OpenRansomInfo() {
        malwareSelectPage.SetActive(false);
        ransomInfoPage.SetActive(true);
    }




    // function to return to the game from the info pages
    public void BackToGame() {
        this.transform.gameObject.SetActive(false);
    }
}