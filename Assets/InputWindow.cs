using UnityEngine;

public class InputWindow : MonoBehaviour
{
    [SerializeField] protected BlankInputBrick brick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PassInputString(string password) => brick.SetInputString(password);

    public void GetBlankInputBrick(BlankInputBrick blank)
    {
        brick = blank;
    }


    public void Close()
    {
        brick.CloseInputWindow();
    }
}
