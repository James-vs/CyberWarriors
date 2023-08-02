using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessManager : LevelEnd
{
    [SerializeField] private GameObject pmManager;
    [SerializeField] private ScoreManagerEndless smEndless;
    private bool initialBlocksCreated = false;
    [SerializeField] private string playerPrefsVariable;
    private static bool resetPlayerPrefsValue = true;

    // Start is called before the first frame update
    void Start()
    {
        if (resetPlayerPrefsValue && PlayerPrefs.HasKey(playerPrefsVariable)) PlayerPrefs.SetInt(playerPrefsVariable, 0);
        resetPlayerPrefsValue = false;
        smEndless.SetBaseScore(PlayerPrefs.GetInt(playerPrefsVariable));
        Debug.Log("smEndless initial value: " + smEndless.GetScore());

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
            smEndless.PMExists(true);
        }

        if (blockCount == totalBlocks && initialBlocksCreated && !levelEnded)
        {
            EndLevel();
        }
    }

    /// <summary>
    /// function to set the total number of blocks
    /// </summary>
    /// <param name="total">totalBlocks var set to this value (int)</param>
    public void SetTotalBlocks(int total)
    {
        this.totalBlocks = total;
        initialBlocksCreated = true;
    }

    public void AddToTotalBlocks(int num)
    {
        this.totalBlocks += num;
    }

    /// <summary>
    /// override for parent class function EndLevel()
    /// </summary>
    public override void EndLevel()
    {
        base.EndLevel();
        Debug.Log("smEndless end value: " + smEndless.GetOverallScore());
    }

    /// <summary>
    /// override for parent function IncreaseBlockCount()
    /// </summary>
    public override void IncreaseBlockCount()
    {
        this.blockCount += 1f;
        smEndless.UpdateBricksBrokenScore(((int)blockCount));
    }
}
