using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOptions : MonoBehaviour
{
    PlayerController PC;

    public float dashDistance;
    public float dashTime;
    public float dashThreshold = .5f;

    private bool isDashing = false;
    private float targetPosition;

    private void Start()
    {
        PC = GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (isDashing)
        {
            float frameDistance = Mathf.Lerp(transform.position.x, targetPosition, 10f * Time.deltaTime * dashTime);
            transform.position = new Vector3(frameDistance, transform.position.y, transform.position.z);
            if (Mathf.Abs(transform.position.x - targetPosition) < dashThreshold)
            {
                transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
                isDashing = false;
                PC.animator.SetBool("IsDashing", false);
            }
        }
    }
    public bool Dash()
    {
        if(!PC.isAerial && !isDashing)
        {
            isDashing = true;
            targetPosition = transform.position.x + (PC.isFacingRight ? 1 : -1) * dashDistance;
            PC.animator.SetBool("IsDashing", true);
            return true;
        }
        return false;
    }
}
