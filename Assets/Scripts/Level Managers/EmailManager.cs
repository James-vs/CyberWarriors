using UnityEngine;

public class EmailManager : MonoBehaviour
{
    [SerializeField] private GameObject dfault;
    [SerializeField] private GameObject email1;
    [SerializeField] private GameObject email2;
    [SerializeField] private GameObject email3;
    [SerializeField] private GameObject isScam1;
    [SerializeField] private GameObject isScam2;
    [SerializeField] private GameObject isScam3;
    [SerializeField] private GameObject instruction;
    [SerializeField] private bool showing1 = false;
    [SerializeField] private bool showing2 = false;
    [SerializeField] private bool showing3 = false;
    private bool emailDisplayed = false;
    [SerializeField] private bool email1Scam = false;
    [SerializeField] private bool email2Scam = false;
    [SerializeField] private bool email3Scam = false;
    [SerializeField] private bool done = false;
    [SerializeField] private GameObject sus2;
    [SerializeField] private GameObject sus3;
    [SerializeField] private GameObject sus4;
    [SerializeField] private GameObject sus5;
    [SerializeField] private GameObject sus6;
    [SerializeField] private GameObject sus7;
    [SerializeField] private GameObject success;
    [SerializeField] private GameObject fail;
    [SerializeField] private GameObject doneButton;





    // function to check answers
    public void Done() {
        isScam1.SetActive(false);
        isScam2.SetActive(false);
        isScam3.SetActive(false);
        instruction.SetActive(false);
        if (!email1Scam && email2Scam && email3Scam) {
            success.SetActive(true);
            doneButton.SetActive(false);
            sus2.SetActive(true);
            sus3.SetActive(true);
            sus4.SetActive(true);
            sus5.SetActive(true);
            sus6.SetActive(true);
            sus7.SetActive(true);
            done = true;
        } else {
            fail.SetActive(true);
        }
    }

    // functions to handle displaying email ui gameobjects
    public void OnClickEmail1() {
        fail.SetActive(false);
        if (!showing1 && !emailDisplayed) {
            email1.SetActive(true);
            isScam1.SetActive(true);
            dfault.SetActive(false);
            instruction.SetActive(false);
            showing1 = true;
            emailDisplayed =true;
        } else if (showing1 && emailDisplayed) {
            email1.SetActive(false);
            isScam1.SetActive(false);
            dfault.SetActive(true);
            instruction.SetActive(true);
            showing1 = false;
            emailDisplayed = false;
        }
        if (done) {
            isScam1.SetActive(false);
            instruction.SetActive(false);
        }
    }

    public void OnClickEmail2() {
        fail.SetActive(false);
        if (!showing2 && !emailDisplayed) {
            email2.SetActive(true);
            isScam2.SetActive(true);
            dfault.SetActive(false);
            instruction.SetActive(false);
            showing2 = true;
            emailDisplayed =true;
        } else if (showing2 && emailDisplayed) {
            email2.SetActive(false);
            isScam2.SetActive(false);
            dfault.SetActive(true);
            instruction.SetActive(true);
            showing2 = false;
            emailDisplayed = false;
        }
        if (done) {
            isScam2.SetActive(false);
            instruction.SetActive(false);
        }
    }

    public void OnClickEmail3() {
        fail.SetActive(false);
        if (!showing3 && !emailDisplayed) {
            email3.SetActive(true);
            isScam3.SetActive(true);
            dfault.SetActive(false);
            instruction.SetActive(false);
            showing3 = true;
            emailDisplayed =true;
        } else if (showing3 && emailDisplayed) {
            email3.SetActive(false);
            isScam3.SetActive(false);
            dfault.SetActive(true);
            instruction.SetActive(true);
            showing3 = false;
            emailDisplayed = false;
        }
        if (done) {
            isScam3.SetActive(false);
            instruction.SetActive(false);
        }
    }




    //functions to handle players choice for if email is a scam
    public void scamEmail1(bool value) {
        email1Scam = value;
    }

    public void scamEmail2(bool value) {
        email2Scam = value;
    }

    public void scamEmail3(bool value) {
        email3Scam = value;
    }
}
