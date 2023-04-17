using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] protected Text dNTText;
    [SerializeField] protected Text incText;
    [SerializeField] protected Text pSText;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // functions to handle browser settings changed
    public void DNTToggle(bool enabled) {
        if (enabled) {
            dNTText.text = "Enabled";
        } else {
            dNTText.text = "Disabled";
        }
    }

    public void IncToggle(bool enabled) {
        if (enabled) {
            incText.text = "Enabled";
        } else {
            incText.text = "Disabled";
        }
    }

    public void PSToggle(bool enabled) {
        if (enabled) {
            pSText.text = "Enabled";
        } else {
            pSText.text = "Disabled";
        }
    }
}
