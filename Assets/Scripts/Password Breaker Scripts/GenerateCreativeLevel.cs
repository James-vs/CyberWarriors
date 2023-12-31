using UnityEngine;
using UnityEngine.UI;

public class GenerateCreativeLevel : GenerateLevel
{
    [SerializeField] protected Button startButton;

    [SerializeField] protected CreativeBallInitialiser creativeBallInitialiser;
    [SerializeField] protected int passwordInputCount = 0;

    public void PasswordInputted()
    {
        passwordInputCount++;
        if (passwordInputCount == spawnCount)
        {
            startButton.interactable = true;
            creativeBallInitialiser.AllBricksCreated();
        }
    }

    new void Start()
    {
        base.Start();
        startButton.gameObject.SetActive(true);
        startButton.interactable = false;
    }
}
