// NOTE: the #if statements are intentional. These are "preprocessor directives". Leave these be.

// Example class to RECEIVE the sessionID:
// SessionController.cs

using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using System;

// The GameObject that this is attached to MUST be called "SessionController".
public class SessionController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RequestWebSession();
    [SerializeField] private string pBSessionID = "";
    [SerializeField] private string pBPlayPrefSessionKey = "PBSessionKey";
    [SerializeField] protected string isUserDevString = "PBIsUserDev";
    [SerializeField] protected DevModeToggle toggle;
    [SerializeField] private string pBSecretKey = "a19b9b6866c5422bd7a1753da27fd8afc8f5d139";
    [SerializeField] private string pBUrl = "https://cybersec-web-app-backend-production.up.railway.app";

    private void Start()
    {
        
    }

    // Call THIS function at the start of your game to request that the frontend sends a sessionID
    public void RequestSession()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
    	RequestWebSession();
#endif
        // below code used for testing purposes, should be deleted later
        StartCoroutine(MakeRequests());
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


    private IEnumerator MakeRequests()
    {
        // GET User Data
        // var request = new UnityWebRequest(path, type.ToString());
        var getUserDataRequest = CreateRequest(pBUrl + "/api/user", RequestType.GET);
        AttachHeader(getUserDataRequest, "secret", pBSecretKey);
        AttachHeader(getUserDataRequest, "session", pBSessionID);
        AttachHeader(getUserDataRequest, "Content-Type", "application/json");
        //getRequest.SetRequestHeader("Content-Type", "application/json");
        //request.SetRequestHeader("secret", pBSecretKey);
        //request.SetRequestHeader("session", pBSessionID);

        //getRequest.downloadHandler = new DownloadHandlerBuffer();

        yield return getUserDataRequest.SendWebRequest();
        //var deserialisedGetData = JsonUtility.FromJson<UserData>(System.Text.Encoding.UTF8.GetString(getRequest.downloadHandler.data, 3, getRequest.downloadHandler.data.Length - 3));
        UserData userData = JsonUtility.FromJson<UserData>(getUserDataRequest.downloadHandler.text);

        if (getUserDataRequest.responseCode == 200 )
        {
            //successful request
            Debug.Log(getUserDataRequest.downloadHandler.text);
            Debug.Log("User Data Recieved");
            Debug.Log("id: " + userData.id +
                "\nusername: " + userData.username +
                "\nisDeveloper: " + userData.isDeveloper +
                "\nscore: " + userData.score);
            SetIsDeveloper(userData);
            toggle.CheckForDevUser();
        } 
        else
        {
            //unsuccessful
            Debug.Log("Bombaclart User Data");
        }


        // GET Leaderboard Data
        var getLeaderboardDataRequest = CreateRequest(pBUrl + "/api/leaderboard", RequestType.GET);
        AttachHeader(getLeaderboardDataRequest, "secret", pBSecretKey);
        AttachHeader(getLeaderboardDataRequest, "session", pBSessionID);
        AttachHeader(getLeaderboardDataRequest, "Content-Type", "application/json");

        yield return getLeaderboardDataRequest.SendWebRequest();

        if (getLeaderboardDataRequest .responseCode == 200 ) 
        {
            //successful request
            Debug.Log(getLeaderboardDataRequest.downloadHandler.text);
        }
        else
        {
            //unsuccessful
            Debug.Log("Bombaclart Leaderboard Data");
        }
        

    }

    /// <summary>
    /// method to set the isDeveloper playerprefs value according to the userdata given
    /// </summary>
    /// <param name="userData">user data recieved from website</param>
    private void SetIsDeveloper(UserData userData)
    {
        if (userData.isDeveloper)
        {
            PlayerPrefs.SetInt(isUserDevString, 1);
        } 
        else
        {
            PlayerPrefs.SetInt(isUserDevString, 0);
        }
    }


    //attempting method to send web requests from youtube
    private UnityWebRequest CreateRequest(string path, RequestType type = RequestType.GET, object data = null)
    {
        var request = new UnityWebRequest(path, type.ToString());

        if (data != null)
        {
            var bodyRaw =  Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        }

        request.downloadHandler = new DownloadHandlerBuffer();
        
        //request.SetRequestHeader("Accept", "application/json");

        return request;
    }


    /// <summary>
    /// method to attach a header to a web request
    /// </summary>
    /// <param name="request">the UnityWebRequest object</param>
    /// <param name="key">the header name</param>
    /// <param name="value">the header value/data</param>
    private void AttachHeader(UnityWebRequest request, string key, string value)
    {
        request.SetRequestHeader(key, value);
    }


    /*
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
                "\nscore: " + deserialisedData.score);//
        }
        else
        {
            Debug.Log("Bombaclart");
        }
    } */

    public enum RequestType
    {
        GET = 0,
        POST = 1,
        PUT = 2
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

