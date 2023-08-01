using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessManager : LevelEnd
{
    [SerializeField] private ScoreManagerwPM scoreManagerwPM;
    [SerializeField] private GameObject pmManager;
    private bool initialBlocksCreated = false;
    [SerializeField] private string playerPrefsVariable;
    [SerializeField] private bool resetPlayerPrefsValue = false;

    // Start is called before the first frame update
    void Start()
    {
        if (resetPlayerPrefsValue && PlayerPrefs.HasKey(playerPrefsVariable)) PlayerPrefs.SetInt(playerPrefsVariable, 0);
        resetPlayerPrefsValue = false;
        scoreManager.SetBaseScore(PlayerPrefs.GetInt(playerPrefsVariable));
        scoreManagerwPM.SetBaseScore(PlayerPrefs.GetInt(playerPrefsVariable));
        Debug.Log("scoreManager initial value: " + scoreManager.GetScore());
        Debug.Log("scoreManagerwPM initial value: " + scoreManagerwPM.GetScore());
        scoreManager.enabled = true;
        scoreManagerwPM.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pmManager == null)
        {
            pmManager = GameObject.FindGameObjectWithTag("PassMan");
        }
        else
        {
            scoreManager.enabled = false;
            scoreManagerwPM.enabled = true;
        }

        if (blockCount == totalBlocks && initialBlocksCreated)
        {
            EndLevel();
        }
    }

    public void SetTotalBlocks(int total)
    {
        this.totalBlocks = total;
        initialBlocksCreated = true;
    }

    public void AddToTotalBlocks(int num)
    {
        this.totalBlocks += num;
    }

    public override void EndLevel()
    {
        base.EndLevel();
        if (scoreManager.enabled == true) PlayerPrefs.SetInt(playerPrefsVariable, scoreManager.GetOverallScore());
        if (scoreManagerwPM.enabled == true) PlayerPrefs.SetInt(playerPrefsVariable, scoreManagerwPM.GetOverallScore());
        Debug.Log("scoreManager end value: " + scoreManager.GetOverallScore());
        Debug.Log("scoreManagerwPM end value: " + scoreManagerwPM.GetOverallScore());
    }
}
