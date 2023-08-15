using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using Unity.VisualScripting;

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

        // need to double check that these are the correct colours (same as the normal bricks)
        //weak = Color.red;
        //medium = Color.yellow;
        //strong = Color.green;
    }

    /// <summary>
    /// function that 'opens' the input window once a brick is selected
    /// </summary>
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
            InputWindow.GetComponent<InputWindow>().GetBlankInputBrick(this);
        }
    }

    /// <summary>
    /// function handling what happens to the blank brick once it recieves a password
    /// </summary>
    public void CloseInputWindow()
    {
        Time.timeScale = 1.0f;
        InputWindow.GetComponentInChildren<TMP_InputField>().text = "";

        for (int i = 0; i < InputWindow.transform.childCount; i++)
        {
            InputWindow.transform.GetChild(i).gameObject.SetActive(false);
        }

        if (inputPassword != null)
        {
            if (inputPassword.Length >= 12 && Regex.IsMatch(inputPassword, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!£$%^&\*()_+\-={}\[\];'#:@~,\./<>?|\\`¬""]).{12,}$")) //inputPassword.Length >= 8 && 
            {
                GetComponent<SpriteRenderer>().color = strong;
                this.AddComponent<StrongPassDestroyer>();
                ValidInput();

            } 
            else if (Regex.IsMatch(inputPassword, @"^(?=.*?[a-z])((?=.*?[A-Z])|(?=.*?[0-9])|(?=.*?[!£$%^&\*()_+\-={}\[\];'#:@~,\./<>?|\\`¬""])).{8,}$")) //inputPassword.Length >= 8 && 
            {
                //^(?=.*?[a-z])((?=.*?[A-Z])|(?=.*?[0-9])|(?=.*?[!£$%^&\*()_+\-={}\[\];'#:@~,\./<>?|\\`¬""])).{8,}$
                // ^ regex matches case where password uses either capital letters, OR digits OR special characters as well as all of them at once
                GetComponent<SpriteRenderer>().color = medium;
                this.AddComponent<MediumPassDestroyer>();
                ValidInput();

            }
            else if (Regex.IsMatch(inputPassword, @"^[a-zA-Z0-9]+$"))
            {
                GetComponent<SpriteRenderer>().color = weak;
                this.AddComponent<SimplePassDestroyer>();
                ValidInput();

            } else if (Regex.IsMatch(inputPassword, @"^\s*"))
            {
                Debug.Log("Invalid input");

            }
        }

        //InputWindow.GetComponentInChildren<InputField>().text = "";

    }

    public void ValidInput()
    {
        brickText.text = inputPassword;
        brickText.color = Color.white;
        hasNewPassword = true;
        Debug.Log("Inputted text: " + inputPassword);
    }

    /// <summary>
    /// function to set the textUI global var to a new input
    /// </summary>
    /// <param name="newPassword">the new password string</param>
    public void SetInputString(string newPassword)
    {
        inputPassword = newPassword;
    }
}
