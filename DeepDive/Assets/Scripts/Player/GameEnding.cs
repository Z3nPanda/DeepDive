using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup gameOver;
    public CanvasGroup finalScore;

    // Game status
    bool player_at_submarine;
    bool player_died;
    bool restart;
    float m_Timer;

    // End game UI information/tools
    public SphereCast sphereCast;
    public TMP_Text finalScoreText;
    int finalScoreInt;
    bool scoreExists;

    // Public functions for if the player dies
    public void PlayerDied()
    {
        player_died = true;
    }

    public void PlayerAtSubmarine()
    {
        player_at_submarine = true;
    }

    // If player has triggered an ending, end the game
    void Update()
    {
        if(player_at_submarine)
        {
            if (!scoreExists)
            {
                finalScoreInt = sphereCast.GetScore();
                finalScoreText.text = "Final Score: " + finalScoreInt.ToString();
            }
            EndLevel();
            if (Input.GetKeyDown("r"))
            {
                restart = true;
            }
            // Debug.Log("player is at exit!");
        }
        else if (player_died)
        {
            if (!scoreExists)
            {
                finalScoreInt = sphereCast.GetScore();
                finalScoreText.text = "Final Score: " + finalScoreInt.ToString();
            }
            EndLevel();
            if (Input.GetKeyDown("r"))
            {
                restart = true;
            }
            // Debug.Log("player is dead!");
        }

    }

    // End level function for ending the game
    void EndLevel()
    {
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
        gameOver.alpha = m_Timer / fadeDuration;
        finalScore.alpha = m_Timer / fadeDuration;
        

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if (restart)
            {
                SceneManager.LoadScene(0);
            }
            // Debug.Log("Game over!");
        }
    }
}
