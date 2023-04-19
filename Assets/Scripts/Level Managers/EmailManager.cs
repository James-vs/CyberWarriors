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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // functions to handle displaying email ui gameobjects
    public void OnClickEmail1() {
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
    }

    public void OnClickEmail2() {
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
    }

    public void OnClickEmail3() {
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
    }
}
