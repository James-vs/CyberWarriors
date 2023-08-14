using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class BlankInputBrick : MonoBehaviour
{
    protected GameObject InputWindow;
    protected BoxCollider2D boxCollider;
    protected string inputPassword;
    protected bool hasNewPassword = false;
    [SerializeField] protected TextMeshPro brickText;
    [SerializeField] protected Color32 weak;
    [SerializeField] protected Color32 medium;
    [SerializeField] protected Color32 strong;

    // Start is called before the first frame update
    void Start()
    {
        InputWindow = GameObject.FindGameObjectWithTag("Input Window");
        weak = Color.red;
        medium = Color.yellow;
        strong = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!hasNewPassword)
        {
            InputWindow.SetActive(true);
            Time.timeScale = 0f;
            for (int i = 0; i < InputWindow.transform.childCount; i++) 
            { 
                InputWindow.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void CloseInputWindow()
    {
        Time.timeScale = 1.0f;
        for (int i = 0; i < InputWindow.transform.childCount; i++)
        {
            InputWindow.transform.GetChild(i).gameObject.SetActive(false);
        }

        brickText.text = inputPassword;
        brickText.color = Color.white;
        hasNewPassword = true;

        if (inputPassword.Length >= 12 && Regex.IsMatch(inputPassword, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!�$%^&\*()_+\-={}\[\];'#:@~,\./<>?|\\`�""]).{12,}$")) //inputPassword.Length >= 8 && 
        {
            
            
            this.GetComponent<SpriteRenderer>().color = strong;
            
        } 
        else if (Regex.IsMatch(inputPassword, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$")) //inputPassword.Length >= 8 && 
        {
            //@"^([a-zA-Z0-9]+[!�$%^&\*()_+\-={}\[\];'#:@~,\./<>?|\\`�""]+)$"


            this.GetComponent<SpriteRenderer>().color = medium;

        }
        else if (Regex.IsMatch(inputPassword, @"^[a-zA-Z0-9]+$"))
        {
            //@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"
            //

            this.GetComponent<SpriteRenderer>().color = weak;
            
        }
        
        
        Debug.Log("Inputted text: " + inputPassword);
    }

    public void GetInputString(string newPassword)
    {
        inputPassword = newPassword;
    }
}
