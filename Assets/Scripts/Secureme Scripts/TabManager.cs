using UnityEngine;

public class TabManager : MonoBehaviour
{
    private int tabCount;
    
    // Start is called before the first frame update
    void Start()
    {
        //closeWindow = new CloseWindow();        
    }

    // function to increase the tab count
    public void IncreaseTabCount() {
        tabCount += 1;
    }

}
