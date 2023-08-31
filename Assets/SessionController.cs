// NOTE: the #if statements are intentional. These are "preprocessor directives". Leave these be.

// Example class to RECEIVE the sessionID:
// SessionController.cs

using UnityEngine;
using System.Runtime.InteropServices;

// The GameObject that this is attached to MUST be called "SessionController".
public class SessionController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RequestWebSession();
    [SerializeField] private string pBSessionID = "";

    // Call THIS function at the start of your game to request that the frontend sends a sessionID
    public void RequestSession()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
    	RequestWebSession();
#endif
    }

    // This method is called when a sessionID is sent by the frontend
    // Do NOT rename this function.
    public void OnSessionReceived(string sessionID)
    {
        // You can do what you want with the sessionID here. Ideally you should store it somewhere so that you can use it to make calls to the API later.
        pBSessionID = sessionID;

        Debug.Log($"Session received: {pBSessionID}");
    }
}

