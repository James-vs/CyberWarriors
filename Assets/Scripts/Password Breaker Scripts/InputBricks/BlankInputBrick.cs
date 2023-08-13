using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlankInputBrick : MonoBehaviour
{
    protected GameObject InputWindow;
    protected BoxCollider2D boxCollider;
    protected string inputPassword;
    protected bool hasNewPassword = false;
    [SerializeField] protected TextMeshPro brickText;

    // Start is called before the first frame update
    void Start()
    {
        InputWindow = GameObject.FindGameObjectWithTag("Input Window");
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
        hasNewPassword = true;
        Debug.Log("Inputted text: " + inputPassword);
    }

    public void GetInputString(string newPassword)
    {
        inputPassword = newPassword;
    }
}
