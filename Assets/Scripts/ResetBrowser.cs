using UnityEngine;
using TMPro;

public class ResetBrowser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI placeholder;
    [SerializeField] private TextMeshProUGUI typedText;


    //function to reset the contents of the browser search bar
    public void Reset(){
        typedText.text = null;
        placeholder.text = "Type a URL...";
        //placeholder.text = null;
        Debug.Log("browser reset");
    }
}
