using UnityEngine;

public class TabManager : MonoBehaviour
{
    private int tabCount;
    //private int windowWidth = 1500;
    //private CloseWindow closeWindow;
    
    // Start is called before the first frame update
    void Start()
    {
        //closeWindow = new CloseWindow();        
    }

    // function to increase the tab count
    public void IncreaseTabCount() {
        tabCount += 1;
    }

    /* function to close the current tab
    public void Close() {
        closeWindow.Close();
    } */
}
