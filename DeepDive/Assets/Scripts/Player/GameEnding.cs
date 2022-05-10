using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;

    bool player_at_submarine;
    bool player_died;
    float m_Timer;

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
            EndLevel();
            Debug.Log("player is at exit!");
        }
        else if (player_died)
        {
            EndLevel();
            Debug.Log("player is dead!");
        }

    }

    // End level function for ending the game
    void EndLevel()
    {
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            Debug.Log("Game over!");
        }
    }
}
