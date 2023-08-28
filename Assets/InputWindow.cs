using UnityEngine;

public class InputWindow : MonoBehaviour
{
    [SerializeField] protected BlankInputBrick brick;
    [SerializeField] protected GenerateCreativeLevel generate;
    [SerializeField] protected GameObject AutoFillButton;
    protected string password;
    protected bool listenForEnter = false;

    private void Start()
    {
        AutoFillButton.SetActive(false);
    }

    /// <summary>
    /// override function to pass the new inputted password from the input window to the blank brick's script
    /// </summary>
    /// <param name="inputString">string being transfered between scripts</param>
    /// <param name="blank">the script attached to the input brick</param>
    public void PassInputString(string inputString, BlankInputBrick blank) 
    { 
        password = inputString;
        blank.SetInputString(inputString);
        blank.CloseInputWindow(gameObject);
    }

    /// <summary>
    /// function to pass the new inputted password from the input window to the blank brick's script
    /// </summary>
    /// <param name="inputString">string being transfered between scripts</param>
    public void PassInputString(string inputString) => brick.SetInputString(inputString);


    /// <summary>
    /// function to get the script from the blank brick GO in order to share the input with it
    /// </summary>
    /// <param name="blank"></param>
    public void GetBlankInputBrick(BlankInputBrick blank)
    {
        brick = blank;
    }


    /// <summary>
    /// function to handle closing off the input window
    /// </summary>
    public void Close()
    {
        AutoFillButton.SetActive(false);
        brick.CloseInputWindow(null);

    }

    private void Update()
    {
        if (listenForEnter && Input.GetKey(KeyCode.Return))
        {
            Close();
            listenForEnter = false;
            generate.PasswordInputted();
        }
    }

    public void ListenForEnter()
    {
        listenForEnter = true;
    }


    /// <summary>
    /// method to auto-fill any remaining empty password bricks
    /// </summary>
    public void AutoFillBricks()
    {
        GameObject[] blankList = GameObject.FindGameObjectsWithTag("Blank Brick");

        foreach (var item in blankList)
        {
            Debug.Log("blank brick detected");
            //if (brick.GetPassword() == null) 
            PassInputString(password, item.GetComponent<BlankInputBrick>());
        }

        AutoFillButton.SetActive(false);
    }

    public void DisplayAutoFillButton()
    {
        AutoFillButton.SetActive(true);
    }
}
