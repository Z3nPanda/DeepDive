using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SphereCast : MonoBehaviour
{
    private static Rigidbody rb;
    public CameraSwap rayCamActive;

    // Score tracker
    public TMP_Text scoreText;
    public static int score = 0;

    // Fish announcement
    public TMP_Text announcementText;
    static string announcement = "";

    // Score system
    static int rare = 500;
    static int uncommon = 250;
    static int common = 100;

    // Booleans to track if the fish has been photographed
    static bool carp = false;
    static bool catfish = false;
    static bool clownfish = false;
    static bool cod = false;
    static bool discus = false;
    static bool emperor = false;
    static bool koifish = false;
    static bool moorfish = false;
    static bool octopus = false;
    static bool peacock = false;
    static bool perch = false;
    static bool redeye = false;
    static bool shark = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreText.text = score.ToString();
        announcementText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (rayCamActive.camActive)
        {
            if (Input.GetKeyDown("v"))
            {
                CastSphere();
            }
        }

        scoreText.text = score.ToString();
        announcementText.text = announcement;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int new_score)
    {
        score = new_score;
    }

    public void SetText(string new_txt)
    {
        announcement = new_txt;
    }

    public void ResetCapture()
    {
        carp = false;
        catfish = false;
        clownfish = false;
        cod = false;
        discus = false;
        emperor = false;
        koifish = false;
        moorfish = false;
        octopus = false;
        peacock = false;
        perch = false;
        redeye = false;
        shark = false;
    }

    public static void CastSphere()
    {
        RaycastHit hit;
        Vector3 start = rb.transform.position;

        /* 
        Cast a sphere everytime a photo is taken to detect new fish.
        See if the fish has yet to be captured then improve player's score if they have found a newly discovered fish.
        Scoring is as follows:
        Rare = 500 pts
        Uncommon = 250 pts
        Common = 100 pts
        */ 

        // Carp - common
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Carp" && carp == false)
        {
            carp = true;
            score += common;
            announcement = "I saw a carp!";
            Debug.Log("I saw a carp!");
            Debug.Log("Score = " + score);
        }
        // Catfish - uncommon
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Catfish" && catfish == false)
        {
            catfish = true;
            score += uncommon;
            announcement = "I saw a catfish!";
            Debug.Log("I saw a catfish!");
            Debug.Log("Score = " + score);
        }
        // Clownfish - uncommon
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Clownfish" && clownfish == false)
        {
            clownfish = true;
            score += uncommon;
            announcement = "I saw a clownfish!";
            Debug.Log("I saw a clownfish!");
            Debug.Log("Score = " + score);
        }
        // Cod - common
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Cod" && cod == false)
        {
            cod = true;
            score += common;
            announcement = "I saw a cod!";
            Debug.Log("I saw a cod!");
            Debug.Log("Score = " + score);
        }
        // Discus - uncommon
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Discus" && discus == false)
        {
            discus = true;
            score += uncommon;
            announcement = "I saw a discus!";
            Debug.Log("I saw a discus!");
            Debug.Log("Score = " + score);
        }
        // Emperor - uncommon
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Emperor" && emperor == false)
        {
            emperor = true;
            score += uncommon;
            announcement = "I saw an emperor fish!";
            Debug.Log("I saw an emperor!");
            Debug.Log("Score = " + score);
        }
        // Koifish - uncommon
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Koifish" && koifish == false)
        {
            koifish = true;
            score += uncommon;
            announcement = "I saw a koi fish!";
            Debug.Log("I saw a koi fish!");
            Debug.Log("Score = " + score);
        }
        // Moorfish - uncommon
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Moorfish" && moorfish == false)
        {
            moorfish = true;
            score += uncommon;
            announcement = "I saw a moorfish!";
            Debug.Log("I saw a moorfish!");
            Debug.Log("Score = " + score);
        }
        // Octopus - rare
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Octopus" && octopus == false)
        {
            octopus = true;
            score += rare;
            announcement = "I saw an octopus!";
            Debug.Log("I saw an octopus!");
            Debug.Log("Score = " + score);
        }
        // Peacock - common
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Peacock" && peacock == false)
        {
            peacock = true;
            score += common;
            announcement = "I saw a peacock fish!";
            Debug.Log("I saw a peacock fish!");
            Debug.Log("Score = " + score);
        }
        // Perch - common
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Perch" && perch == false)
        {
            perch = true;
            score += common;
            announcement = "I saw a perch!";
            Debug.Log("I saw a perch!");
            Debug.Log("Score = " + score);
        }
        // RedEye - common
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "RedEye" && redeye == false)
        {
            redeye = true;
            score += common;
            announcement = "I saw a red eye fish!";
            Debug.Log("I saw a red eye!");
            Debug.Log("Score = " + score);
        }
        // Shark - rare
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20) && hit.transform.tag == "Shark" && shark == false)
        {
            shark = true;
            score += rare;
            announcement = "I saw a shark!";
            Debug.Log("I saw a shark!");
            Debug.Log("Score = " + score);
        }
    }
}
