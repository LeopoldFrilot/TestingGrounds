using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Buffer;

public class AerialOptions : MonoBehaviour
{
    public bool isAerial;
    private bool isJumping = false;
    private float apex;
    public float gravity = .2f;
    public float groundHeight = -76f;
    public float groundedThreshold = .001f;
    PlayerController PC;
    //InputBufferSystem buffer;

    private void Start()
    {
        PC = GetComponent<PlayerController>();
        //buffer = GetComponent<InputBufferSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        float storeHeight = transform.position.y;

        if (isJumping)
        {
            float resultantHeight = Mathf.Lerp(storeHeight, apex, .1f);
            if (apex - resultantHeight < 3f) resultantHeight = apex;
            
            if (resultantHeight == apex)
            {
                isJumping = false;
            }
            transform.position = new Vector3(transform.position.x, resultantHeight, 0);
        }
        else
        {
            float resultantHeight = transform.position.y - gravity;

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
    private void ApplyGravity()
    {
        transform.position -= new Vector3(0, gravity, 0);
    }
}
