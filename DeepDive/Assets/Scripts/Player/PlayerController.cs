using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// movement derived from https://www.youtube.com/watch?v=J6QR4KzNeJU

public class PlayerController : MonoBehaviour
{
    // Movement variables
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeFowardSpeed, activestrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration  = 2f;
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDist;
    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    // Health and Oxygen game objects
    public HealthBarOperator HealthBarOperator;
    public OxygenBarOperator OxygenBarOperator;

    // Game ending reference
    public GameEnding gameEnding;

    // Audio source reference
    AudioSource audioSrc;

    // Flashlight reference
    public GameObject flashlight;
    public Flashlight flash;
    // Start is called before the first frame update
    void Start()
    {
        // adjusting screen size to player's computer screen sematics
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        // lock the mouse inside the game screen
        Cursor.lockState = CursorLockMode.Confined;

        // Instantiate the player's health and oxygen
        HealthBarOperator.SetHealthBarVal(1.0f);
        OxygenBarOperator.SetOxygenBarVal(1.0f);

        // Get audio source component
        audioSrc = GetComponent <AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // player is constantly losing oxygen
        OxygenBarOperator.SetOxygenBarVal(OxygenBarOperator.GetOxygenBarVal() - 0.00005f);
        if (OxygenBarOperator.GetOxygenBarVal() <= 0.0f)
        {
            HealthBarOperator.SetHealthBarVal(HealthBarOperator.GetHealthBarVal() - 0.00005f);
        }
        // If player is too high up, to simulate the "bends" the player will begin to lose health to simulate the damage taken, this also restricts playable area
        // Gentleish reminder to stay below Y = 300
        if (transform.position.y >= 300f)
        {
            HealthBarOperator.SetHealthBarVal(HealthBarOperator.GetHealthBarVal() - 0.0001f);
            // Harsh penalty if player tries to reach Y = 400
            if (transform.position.y >= 400f)
            {
                HealthBarOperator.SetHealthBarVal(HealthBarOperator.GetHealthBarVal() - 0.001f);
            }
        }

        // If player's health reaches 0, end the game
        if (HealthBarOperator.GetHealthBarVal() <= 0.0f)
        {
            gameEnding.PlayerDied();
        }
        
        // how to subrtract from player health
        // HealthBarOperator.SetHealthBarVal(HealthBarOperator.GetHealthBarVal() - 0.00005f);

        // set lookInput based on mouse position
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        // calculate the distance between the center of the screen and where the mouse
        // is and adjust coordinates
        mouseDist.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDist.y = (lookInput.y - screenCenter.y) /  screenCenter.y;

        // set limits
        mouseDist = Vector2.ClampMagnitude(mouseDist, 1f);

        // set roll input
        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        // actually rotate the player
        transform.Rotate(-mouseDist.y * lookRateSpeed * Time.deltaTime, mouseDist.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        // set active speeds using base speeds and axises 
        activeFowardSpeed = Mathf.Lerp(activeFowardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activestrafeSpeed = Mathf.Lerp(activestrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||  
            Input.GetAxisRaw("Roll") == 1|| Input.GetAxisRaw("Roll") == -1)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
        }
        else
        {
            audioSrc.Stop();
        }

        // move the player
        transform.position += transform.forward * activeFowardSpeed * Time.deltaTime;
        transform.position += transform.right * activestrafeSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // If player picks up health, increase health by 25 hit points or restore them to full if over 75 hit points
        // Note: Full HP = 100 hit points
        if (other.gameObject.CompareTag("HealthPickUp"))
        {
            if (HealthBarOperator.GetHealthBarVal() <= 0.75f)
            {
                HealthBarOperator.SetHealthBarVal(HealthBarOperator.GetHealthBarVal() + 0.25f);
            }
            else if (HealthBarOperator.GetHealthBarVal() <= 0.75f)
            {
                HealthBarOperator.SetHealthBarVal(1.0f);
            }
            other.gameObject.SetActive(false);
        }

        // If player picks up oxygen tank, increase oxygen by 50 points or restore to full if over 75 oxygen points
        // Note: Full OP = 100 points
        if (other.gameObject.CompareTag("OxygenPickUp"))
        {
            if (OxygenBarOperator.GetOxygenBarVal() <= 0.75f)
            {
                OxygenBarOperator.SetOxygenBarVal(OxygenBarOperator.GetOxygenBarVal() + 0.50f);
            }
            else if (OxygenBarOperator.GetOxygenBarVal() <= 0.50f)
            {
                OxygenBarOperator.SetOxygenBarVal(1.0f);
            }
            other.gameObject.SetActive(false);
        }

        // If the player reaches the submarine, end the game and display score
        if (other.gameObject.CompareTag("Submarine"))
        {
            gameEnding.PlayerAtSubmarine();
        }

       // If flashlight is picked up, enable it 
        if (flashlight.gameObject.CompareTag("flashlight"))
        {
            flashlight.gameObject.SetActive(false);
            flash.foundFlashLight();
        }
    }
}
