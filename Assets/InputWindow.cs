using UnityEngine;

public class InputWindow : MonoBehaviour
{
    [SerializeField] protected BlankInputBrick brick;
    [SerializeField] protected GenerateCreativeLevel generate;
    protected bool listenForEnter = false;

    /// <summary>
    /// function to pass the new inputted password from the input window to the blank brick's script
    /// </summary>
    /// <param name="password">string being transfered between scripts</param>
    public void PassInputString(string password) => brick.SetInputString(password);


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
        brick.CloseInputWindow();

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
}
