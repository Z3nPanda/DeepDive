using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script derived from https://www.youtube.com/watch?v=J6QR4KzNeJU

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeFowardSpeed, activestrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration  = 2f;
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDist;
    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        // adjusting screen size to player's computer screen sematics
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        // lock the mouse inside the game screen
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
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

        // move the player
        transform.position += transform.forward * activeFowardSpeed * Time.deltaTime;
        transform.position += transform.right * activestrafeSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
        
    }
}
