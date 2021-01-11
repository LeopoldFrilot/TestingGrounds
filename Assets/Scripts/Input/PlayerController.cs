using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputManagement;
using InputManagement.Buffer;

public class PlayerController : MonoBehaviour
{
    FightingGameInputs inputs;
    InputBufferSystem buffer;

    public float horizSpeed = 3f;
    public float jumpHeight;
    private float xMove;
    private bool isStopped = false;

    // Input Management
    public string curDirectionalOption;
    public List<string> usedInputs;
    [SerializeField] string prevDirectionalOption;
    [SerializeField] string prevPrevDirectionalOption;

    public Animator animator;

    // Lag
    private int lagFrames = 0;

    // States
    public bool isAerial;
    public bool isFacingRight;
    public bool isInLag = false;

    public void Start()
    {
        buffer = GetComponent<InputBufferSystem>();
        inputs = new FightingGameInputs();
        animator = GetComponent<Animator>();
        // Make character face right
        FlipCharacterRight();
    }
    public void Update()
    {
        if(isInLag)
        {
            lagFrames--;
            if(lagFrames <= 0)
            {
                isInLag = false;
            }
        }
        usedInputs.Clear();
        xMove = 0f;
        UpdateFacingDirection();

        CheckNormalInputs();
        if (buffer)
        {
            // Horizontal Movement
            if (buffer.buffer[0][0].inputName == "Right")
            {
                xMove += Time.deltaTime * horizSpeed;
                animator.SetBool("IsRunning", true);
                if (!isStopped) FlipCharacterRight();
            }
            else if (buffer.buffer[0][0].inputName == "Left")
            {
                xMove -= Time.deltaTime * horizSpeed;
                animator.SetBool("IsRunning", true);
                if (!isStopped) FlipCharacterLeft();
            }
            else
            {
                animator.SetBool("IsRunning", false);
            }

            // Other Actions
            var options = buffer.GetUnusedOptions();

            if (options.Contains("Jump"))
            {
                bool result = GetComponent<AerialOptions>().Jump();
                if (result) buffer.UseOption("Jump");
                usedInputs.Add("Jump");
            }
            if(!isInLag)
            {
                if (options.Contains("Dash"))
                {
                    bool result = GetComponent<MovementOptions>().Dash();
                    if (result) buffer.UseOption("Dash");
                    usedInputs.Add("Dash");
                }
                if (options.Contains("LightAttack"))
                {
                    bool result = GetComponent<AttackOptions>().LightAttack();
                    if (result) buffer.UseOption("LightAttack");
                    usedInputs.Add("LightAttack");
                }
                if (options.Contains("MediumAttack"))
                {
                    //buffer.UseOption("MediumAttack");
                    usedInputs.Add("MediumAttack");
                }
                if (options.Contains("HeavyAttack"))
                {
                    //buffer.UseOption("HeavyAttack");
                    usedInputs.Add("HeavyAttack");
                }
            }
        }
    
        if(!isStopped)transform.position += new Vector3(xMove, 0, 0);
    }

    private void CheckNormalInputs()
    {
        string potentialInput;
        string[] firstTwoOptions = { buffer.buffer[0][0].inputName, buffer.buffer[0][1].inputName };
        if (firstTwoOptions[0] == inputs.ForwardNeutral()[0] && firstTwoOptions[1] == inputs.ForwardNeutral()[1])
        {
            if (inputs.facingRight == true)
            {
                if (prevDirectionalOption == "DownRight" && prevPrevDirectionalOption == "Down") potentialInput = "QCRBottom";
                else if (prevDirectionalOption == "UpRight" && prevPrevDirectionalOption == "Up") potentialInput = "QCRTop";
                else potentialInput = "Right";
            }
            else
            {
                if (prevDirectionalOption == "DownLeft" && prevPrevDirectionalOption == "Down") potentialInput = "QCLBottom";
                else if (prevDirectionalOption == "UpLeft" && prevPrevDirectionalOption == "Up") potentialInput = "QCLTop";
                else potentialInput = "Left";
            }
        }
        else if (firstTwoOptions[0] == inputs.ForwardDown()[0] && firstTwoOptions[1] == inputs.ForwardDown()[1]) potentialInput = (inputs.facingRight == true) ? "DownRight" : "DownLeft";
        else if (firstTwoOptions[0] == inputs.NeutralDown()[0] && firstTwoOptions[1] == inputs.NeutralDown()[1]) potentialInput = "Down";
        else if (firstTwoOptions[0] == inputs.BackDown()[0] && firstTwoOptions[1] == inputs.BackDown()[1]) potentialInput = (inputs.facingRight == true) ? "DownLeft" : "DownRight";
        else if (firstTwoOptions[0] == inputs.BackNeutral()[0] && firstTwoOptions[1] == inputs.BackNeutral()[1])
        {
            if (inputs.facingRight == false)
            {
                if (prevDirectionalOption == "DownRight" && prevPrevDirectionalOption == "Down") potentialInput = "QCRBottom";
                else if (prevDirectionalOption == "UpRight" && prevPrevDirectionalOption == "Up") potentialInput = "QCRTop";
                else potentialInput = "Right";
            }
            else
            {
                if (prevDirectionalOption == "DownLeft" && prevPrevDirectionalOption == "Down") potentialInput = "QCLBottom";
                else if (prevDirectionalOption == "UpLeft" && prevPrevDirectionalOption == "Up") potentialInput = "QCLTop";
                else potentialInput = "Left";
            }
        }
        else if (firstTwoOptions[0] == inputs.BackUp()[0] && firstTwoOptions[1] == inputs.BackUp()[1]) potentialInput = (inputs.facingRight == true) ? "UpLeft" : "UpRight";
        else if (firstTwoOptions[0] == inputs.NeutralUp()[0] && firstTwoOptions[1] == inputs.NeutralUp()[1]) potentialInput = "Up";
        else if (firstTwoOptions[0] == inputs.ForwardUp()[0] && firstTwoOptions[1] == inputs.ForwardUp()[1]) potentialInput = (inputs.facingRight == true) ? "UpRight" : "UpLeft";
        else potentialInput = "Neutral";
        if(potentialInput != curDirectionalOption)
        {
            //Debug.Log(curDirectionalOption);
            prevPrevDirectionalOption = prevDirectionalOption;
            prevDirectionalOption = curDirectionalOption;
            curDirectionalOption = potentialInput;
        }
    }
    public void UpdateFacingDirection()
    {
        if (gameObject.transform.localScale.x > 0) // Characters are facing left by default
        {
            inputs.facingRight = false;
            isFacingRight = false;
        }
        else
        {
            inputs.facingRight = true;
            isFacingRight = true;
        }
    }
    public void FlipCharacterRight()
    {
        if (gameObject.transform.localScale.x < 0) inputs.facingRight = true;
        else FlipCharacter();
    }
    public void FlipCharacterLeft()
    {
        if (gameObject.transform.localScale.x > 0) inputs.facingRight = false;
        else FlipCharacter();
    }
    public void FlipCharacter()
    {
        inputs.facingRight = !inputs.facingRight;
        transform.localScale = new Vector3(-gameObject.transform.localScale.x,
            gameObject.transform.localScale.y,
            gameObject.transform.localScale.z);
    }
    public void StartLagDrames(int frames)
    {
        lagFrames = frames;
        isInLag = true;
    }
    public void StartMovement()
    {
        isStopped = false;
    }
    public void StopMovement()
    {
        isStopped = true;
    }
}
