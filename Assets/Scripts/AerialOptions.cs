using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialOptions : MonoBehaviour
{
    public bool isAerial;
    private bool isJumping = false;
    private float apex;
    public float gravity = 800f;
    public float groundHeight = -76f;
    public float groundedThreshold = .5f;
    PlayerController PC;

    private void Start()
    {
        PC = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        float storeHeight = transform.position.y;

        if (isJumping)
        {
            float resultantHeight = Mathf.Lerp(storeHeight, apex, 10f * Time.deltaTime);
            if (apex - resultantHeight < 3f) resultantHeight = apex; // threshold of 3 to reach the apex of the jump
            if (resultantHeight == apex)
            {
                isJumping = false;
            }
            transform.position = new Vector3(transform.position.x, resultantHeight, 0);
        }
        else
        {
            float resultantHeight = transform.position.y - gravity * Time.deltaTime;

            transform.position = new Vector3(transform.position.x, resultantHeight, 0);
        }
        if (transform.position.y < groundHeight) transform.position = new Vector3(transform.position.x, groundHeight, 0);
        UpdateGroundedState();
    }

    private void UpdateGroundedState()
    {
        if (Mathf.Abs(transform.position.y - groundHeight) < groundedThreshold)
        {
            isAerial = false;
            PC.animator.SetBool("IsAerial", false);
        }
        else
        {
            isAerial = true;
            PC.animator.SetBool("IsAerial", true);
        }
    }

    public bool Jump()
    {
        if (!isAerial) // No double jumps
        {
            isJumping = true;
            apex = transform.position.y + PC.jumpHeight;
            return true;
        }
        return false;
    }
}
