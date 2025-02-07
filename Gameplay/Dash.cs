using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform PlayerCam;
    public Rigidbody rb;
    public Move pm;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardsForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        pm.GetComponent<Move>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dashKey))
            Dashing();

        if (dashCdTimer > 0)
            dashCdTimer -= Time.deltaTime;
    }

    void Dashing()
    {
        if (dashCdTimer > 0) return;
        else dashCdTimer = dashCd;

        pm.dashing = true;

        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardsForce;

        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDashForce), 0.025f);

        Invoke(nameof(ResetDash), dashDuration);    
    }

    private Vector3 delayedForceToApply;

    private void DelayedDashForce()
    {
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    void ResetDash()
    {
        pm.dashing = false;
    }
}
