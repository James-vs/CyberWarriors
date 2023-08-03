using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessGameResetter : GameResetter
{
    [SerializeField] EndlessManager endlessManager;

    public new void OnCollisionEnter2D(Collision2D other)
    {
        float ballsLeft = gameObject.GetComponent<BallManager>().ballCount;
        if (other.gameObject.CompareTag("Ball") && ballsLeft == 1 && lives < 2)
        {
            endlessManager.EndGame();

        }
        else if (other.gameObject.CompareTag("Ball") && ballsLeft == 1 && lives > 1)
        {
            Debug.Log("Detected life lost");
            LifeLost(gameObject.GetComponent<BallManager>());
            gameObject.GetComponent<BallManager>().DecreaseBallCount();
            Destroy(other.gameObject);

        }
        else
        {
            // livesLost is in the wrong place in this if statement!!!!
            gameObject.GetComponent<BallManager>().DecreaseBallCount();
            Destroy(other.gameObject);
        }
    }

}
