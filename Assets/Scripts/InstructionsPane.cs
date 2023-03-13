using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsPane : MonoBehaviour
{

    [SerializeField] GameObject windows;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (windows.transform.childCount > 0) {
            for(int i = 0; i < windows.transform.childCount; i++) {
                //windows.transform.GetChild(i)
                //check if the child is a Level1 object
            }
        } */
    }

    public void BrowserExistsCheck(){
        if (windows.transform.GetChild(0).gameObject.CompareTag("BrowserWindow")) {
            //launch the game
        } else {
            //something else
        }
        
    }
}
