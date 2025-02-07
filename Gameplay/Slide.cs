using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Slide : MonoBehaviour
{    [Header("References")]
    public Transform orientation;
    public Transform PlayerObj;
    private Rigidbody rb;
    private Move pm;

    [Header("Sliding")]
    public float maxSlideTime;
    public float slideForce;
    private float slideTimer;

    public float slideYScale;
    private float startYScale;

    [Header("Input")]
    public KeyCode slideKey = KeyCode.LeftControl;
    private float horizontalInput;
    private float verticalInput;

    private bool sliding;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<Move>();

        startYScale = PlayerObj.localScale.y;
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput != 0))
            StartSlide();

        if(Input.GetKeyUp(slideKey) && sliding)
            StopSlide();
    }

    private void FixedUpdate()
    {
        if(sliding)
            SlideMovement();
    }

    void StartSlide()
    {
        sliding = true;

        PlayerObj.localScale = new Vector3(PlayerObj.localScale.x, slideYScale, PlayerObj.localScale.z);

        slideTimer = maxSlideTime;
    }

    void SlideMovement()
    {
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(inputDirection.normalized * slideForce, ForceMode.Force);

        slideTimer -= Time.deltaTime;

        if (slideTimer <= 0)
            StopSlide();
    }

    void StopSlide()
    {
        sliding = false;

        PlayerObj.localScale = new Vector3(PlayerObj.localScale.x, startYScale, PlayerObj.localScale.z);
    }
}


