using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BehaviorController : MonoBehaviour
{
    public GameObject shark;
    public TMP_Text danger;
    bool fixTransform = false;
    bool follow;
    public float maxTime = 100f;
    float followTime;

    void Start()
    {
        follow = false;
        followTime = maxTime;
        GetComponent<AgressiveFish>().enabled = false;
        GetComponent<BasicFishMovement>().enabled = true;
        danger.enabled = false;
    }

    void FixedUpdate()
    {
        // If the player is in range or the follow time is less than its max, follow player until either
        // out of range or follow time is 0 since player has escaped their range and the aggressive fish
        // has lost interest. 
        if ((follow || followTime < maxTime) && followTime > 0f)
        {
            fixTransform = true;
            if (GetComponent<AgressiveFish>().enabled == false)
            {
                GetComponent<BasicFishMovement>().enabled = false;
                GetComponent<AgressiveFish>().enabled = true;
                danger.enabled = true;
            }
            followTime = followTime - .25f;
            Debug.Log(followTime);
        }
        else
        {
            // If the player is not in range or the followTime is over, set fish to wander
            if (GetComponent<BasicFishMovement>().enabled == false && followTime == 0f)
            {
                GetComponent<AgressiveFish>().enabled = false;
                GetComponent<BasicFishMovement>().enabled = true;
                danger.enabled = false;
                resetFollowTime(maxTime);
                Debug.Log("Player Escaped");
            }

            // Fix rotation for basic fish movement script because it assumes x and z rotations are 0
            if (GetComponent<BasicFishMovement>().enabled == true && fixTransform)
            {
                if (transform.rotation != new Quaternion(0, 0, 0, 1))
                {
                    transform.rotation = new Quaternion(0, 0, 0, 1);
                    shark.transform.rotation = transform.rotation;
                }
                else 
                {
                    fixTransform = false;
                }
            }
        }
    }

    // Functions for accessing class variables

    public float getMaxTime()
    {
        return maxTime;
    }

    public void resetFollowTime(float time)
    {
        followTime = time;
    }

    public void setFollowTrue()
    {
        follow = true;
    }

     public void setFollowFalse()
    {
        follow = false;
    }

    public bool getFollow()
    {
        return follow;
    }
}
