using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMLinkToServer : MonoBehaviour
{
    [SerializeField] protected static bool GameStarted = false;
    //[SerializeField] protected bool ResetPlayerPrefs = false;
    [SerializeField] protected SessionController sessionController;
     

    // Start is called before the first frame update
    void Start()
    {
        if (!GameStarted)
        {
            if (sessionController != null)
            {
                sessionController.GetComponent<SessionController>().RequestSession();
                GameStarted = true;
                //if (ResetPlayerPrefs) PlayerPrefs.DeleteAll();
                //ResetPlayerPrefs = false;
            }
        }
    }
}
