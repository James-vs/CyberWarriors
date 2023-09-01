// NOTE: the #if statements are intentional. These are "preprocessor directives". Leave these be.

// Example class to RECEIVE the sessionID:
// SessionController.cs

using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Networking;
using System.Collections;

// The GameObject that this is attached to MUST be called "SessionController".
public class SessionController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RequestWebSession();
    [SerializeField] private string pBSessionID = "";
    [SerializeField] private string pBPlayPrefSessionKey = "PBSessionKey";
    [SerializeField] private string pBSecretKey = "a19b9b6866c5422bd7a1753da27fd8afc8f5d139";
    [SerializeField] private string pBUrl = "https://cybersec-web-app-frontend-production.up.railway.app/";

    // Call THIS function at the start of your game to request that the frontend sends a sessionID
    public void RequestSession()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
    	RequestWebSession();
#endif
        // below code used for testing purposes, should be deleted later
        StartCoroutine(MakeRequests(RequestType.USERDATA));
    }

    // This method is called when a sessionID is sent by the frontend
    // Do NOT rename this function.
    public void OnSessionReceived(string sessionID)
    {
        // You can do what you want with the sessionID here. Ideally you should store it somewhere so that you can use it to make calls to the API later.
        pBSessionID = sessionID;
        PlayerPrefs.SetString(pBPlayPrefSessionKey, pBSessionID);
        Debug.Log($"Session received: {pBSessionID}");
    }

    private UnityWebRequest GetUserInformation() 
    {
        var request = new UnityWebRequest(pBUrl + "api/user", "GET");

        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("secret", pBSecretKey);
        request.SetRequestHeader("session", pBSessionID);

        return request;
    }


    private IEnumerator MakeRequests(RequestType type)
    {
        // NOTE: you cannot convert JsonUtility.FromJson... data to string using .ToString()
        string deserialisedData = null;
        switch (type)
        {
            case RequestType.USERDATA:
                // this chunk doesn't work!...

                Debug.Log("Attempting request for user data");
                var userDataRequest = GetUserInformation();
                yield return userDataRequest.SendWebRequest();
                deserialisedData = JsonUtility.FromJson<string>(userDataRequest.downloadHandler.text);
                Debug.Log("data recieved: "+JsonUtility.FromJson<string>(userDataRequest.downloadHandler.text));
                break;
            
            default:
                Debug.Log("Incorrect RequestType value given to MakeRequests() function");
                break;  
        }

        if (deserialisedData != null) 
        {
            Debug.Log("User Data Recieved");
            /*Debug.Log("id: " + deserialisedData.id +
                "\nusername: " + deserialisedData.username +
                "\nisDeveloper: " + deserialisedData.isDeveloper +
                "\nscore: " + deserialisedData.score);*/
        }
        else
        {
            Debug.Log("Bombaclart");
        }
    }

    public enum RequestType
    {
        USERDATA = 0,
        LEADERBOARD = 1,
        SCOREPOST = 2
    }

    /// <summary>
    /// class for recieving data from user data get request
    /// </summary>
    public class UserData
    {
        public string id;
        public string username;
        public bool isDeveloper;
        public int score;
    }


}
