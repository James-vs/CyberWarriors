// NOTE: the #if statements are intentional. These are "preprocessor directives". Leave these be.

// Example class to RECEIVE the sessionID:
// SessionController.cs

using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

// The GameObject that this is attached to MUST be called "SessionController".
public class SessionController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RequestWebSession();

    //[Header("Password Breaker Variables")]
    [SerializeField] protected string totalHighscore = "PBTotalHighscore";
    private static string sessionID = "";
    [SerializeField] private string playPrefSessionKey = "PBSessionKey";
    [SerializeField] protected string isUserDevString = "PBIsUserDev";
    [SerializeField] private string secretKey = "a19b9b6866c5422bd7a1753da27fd8afc8f5d139";
    [SerializeField] protected DevModeToggle toggle;
    [SerializeField] private string url = "https://cyber-warriors.soton.ac.uk";
    //remove below code when publishing game to website / make sure it is false
    [SerializeField] protected bool editorDevMode = false;
    private int userScore = 0;
    private int initialPPScore = 0;
    private static bool hasInitialScore = false;


    private void Start()
    {
        //remove below code when publishing game to website / make sure editorDevMode is false
        if (editorDevMode && toggle != null)
        {
            Debug.Log("editorDevMode detected");
            toggle.gameObject.SetActive(true);
            toggle.EnableDevMode();
            toggle.CheckForDevUser();
        }

        if (!hasInitialScore)
        {
            initialPPScore = PlayerPrefs.GetInt(totalHighscore);
            hasInitialScore = true;
        }


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
        SessionController.sessionID = sessionID;
        PlayerPrefs.SetString(playPrefSessionKey, SessionController.sessionID);
        Debug.Log($"Session received: {SessionController.sessionID}");
    }


    private IEnumerator MakeRequests()
    {
        // GET User Data
        var getUserDataRequest = CreateRequest(url + "/api/user", RequestType.GET);
        AttachHeader(getUserDataRequest, "secret", secretKey);
        AttachHeader(getUserDataRequest, "session", sessionID);
        AttachHeader(getUserDataRequest, "Content-Type", "application/json");

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
            userScore = userData.score;
            SetIsDeveloper(userData);

            if (toggle != null)
            {
                toggle.gameObject.SetActive(userData.isDeveloper);
                toggle.CheckForDevUser();
            }
        } 
        else
        {
            //unsuccessful
            Debug.Log("User Data not recieved; Response code: " + getUserDataRequest.responseCode);
            if (editorDevMode) toggle.gameObject.SetActive(true);
        }


        // GET Leaderboard Data
        var getLeaderboardDataRequest = CreateRequest(url + "/api/leaderboard", RequestType.GET);
        AttachHeader(getLeaderboardDataRequest, "secret", secretKey);
        AttachHeader(getLeaderboardDataRequest, "session", sessionID);
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
            Debug.Log("Leaderboard Data not recieved; Response code: " + getLeaderboardDataRequest.responseCode);
        }
    }

    private IEnumerator MakeScorePostRequest()
    {
        // POST User Score
        ScorePostData scorePostData = new ScorePostData() { score = (userScore - initialPPScore) + PlayerPrefs.GetInt(totalHighscore) };
        Debug.Log("userScore: " + userScore);
        Debug.Log("initialPPScore: " + initialPPScore);
        Debug.Log("totalHighScore string: " + totalHighscore);
        Debug.Log("totalHighScore value: " + PlayerPrefs.GetInt(totalHighscore));
        Debug.Log("{score: " + scorePostData.score + "}");
        var postUserScore = CreateRequest(url + "/api/score", RequestType.POST, scorePostData);
        AttachHeader(postUserScore, "secret", secretKey);
        AttachHeader(postUserScore, "session", sessionID);
        AttachHeader(postUserScore, "Content-Type", "application/json");
        Debug.Log("sessionID: " + sessionID);

        yield return postUserScore.SendWebRequest();

        if (postUserScore.responseCode == 200 )
        {
            //successful post
            Debug.Log(postUserScore.downloadHandler.text);
        }
        else
        {
            //unsuccessful
            Debug.Log("Score Post confirmation not recieved; Response code: " + postUserScore.responseCode);
        }
    }


    /// <summary>
    /// function to start coroutine to send post request to server
    /// </summary>
    public void UploadScore() => StartCoroutine(MakeScorePostRequest());



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
    /// <summary>
    /// function to create a UnityWebRequest GO 
    /// </summary>
    /// <param name="path">Target URL</param>
    /// <param name="type">Request Type (default == GET)</param>
    /// <param name="data">Data to send (defaut == null)</param>
    /// <returns>UnityWebRequest GO</returns>
    private UnityWebRequest CreateRequest(string path, RequestType type = RequestType.GET, object data = null)
    {
        var request = new UnityWebRequest(path, type.ToString());

        if (data != null)
        {
            var bodyRaw =  Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        }

        request.downloadHandler = new DownloadHandlerBuffer();

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

    /// <summary>
    /// New enum data type for type of request
    /// </summary>
    public enum RequestType
    {
        GET = 0,
        POST = 1
    }

    /// <summary>
    /// class for user data GET request
    /// </summary>
    public class UserData
    {
        public string id;
        public string username;
        public bool isDeveloper;
        public int score;
    }


    /// <summary>
    /// class for POST score data
    /// </summary>
    public class ScorePostData
    {
        public int score;
    }
}

