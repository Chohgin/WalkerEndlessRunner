using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
   
    public enum eState
    {
        RUNNING,
        JUMPING,
        DASHING,
        DEAD
    }
    public eState state;
    public float jumpForce = 300;
    Rigidbody body;
    public bool isGrounded;
    //public float movementSpeed = 10;

    //public GameObject objJumpEffect;
    public int maxJumps = 2;
    public int curJump;
    private float timeLeft = 3;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        curJump = 0;
        state = eState.RUNNING;
    }

    void ChangeState(eState p_state)
    {
        switch (state)
        {
            case eState.RUNNING:
                break;
            case eState.JUMPING:
                break;
            case eState.DASHING:
                GameManager.instance.baseSpeed = 1;
                break;
            case eState.DEAD:
                break;

        }

        state = p_state;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.state != GameManager.eState.PLAY)
            return;
        /*
        if(Input.GetKey(KeyCode.RightArrow))//comment out later
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow))//comment out later
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
        */

        StateSwitch();

        

       // Debug.Log(state);

    }

    void Jump()
    {
        ChangeState(eState.JUMPING);
        body.velocity = new Vector3(body.velocity.x, 0, body.velocity.z);
        body.AddForce(Vector3.up * jumpForce);

        //Instantiate(objJumpEffect, transform.position, Quaternion.identity);

        curJump++;

        GameManager.instance.scoreManager.AddScore(500);
    }
    void AcceptJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            AcceptDashInput();
            Jump();
        }
    }

    void AcceptDashInput()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Inside DashInputDown");
            timeLeft = 3;
            Dash();
            AcceptJumpInput();

        }
    }
    void ProcessJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isGrounded)
            {
                if (curJump > 0 && curJump < maxJumps)
                {
                    Jump();
                }
            }
        }
        if (!Input.GetButton("Jump"))
        {
            if (isGrounded)
            {
                curJump = 0;
                //ChangeState(eState.RUNNING);
            }
        }
    }

    void ProcessDash()
    {

        timeLeft -= Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.D))
        {
            GameManager.instance.baseSpeed = 1.0f;
            //movementSpeed = 10;
        }
        if (timeLeft < 0)
        {
            //movementSpeed = 10;
            GameManager.instance.baseSpeed = 1.0f;
        }


    }
    void Dash()
    {
        ChangeState(eState.DASHING);
        //Debug.Log("Inside Dash");
        //movementSpeed = 20;
        GameManager.instance.baseSpeed = 2.0f;
        //Debug.Log("multipler: " + GameManager.instance.baseSpeed);
        if (timeLeft < 0)
        {
            //movementSpeed = 10;
            GameManager.instance.baseSpeed = 1.0f;
        }
    }

    void StateSwitch()
    {
        switch (state)
        {
            case eState.RUNNING:
                if (isGrounded)
                {
                    AcceptJumpInput();
                    AcceptDashInput();
                }
                ProcessDash();
                ProcessJump();
                break;
            case eState.DASHING:
                if (curJump < maxJumps)
                    AcceptJumpInput();
                ProcessDash();
                ProcessJump();

                if (!Input.GetButton("Jump"))
                {
                    if (isGrounded)
                    {
                        curJump = 0;
                        if (timeLeft < 0)
                            ChangeState(eState.RUNNING);
                    }
                }
                break;
            case eState.JUMPING:
                ProcessJump();
                AcceptDashInput();
                ProcessDash();
                if (!Input.GetButton("Jump"))
                {
                    if (isGrounded)
                    {
                        curJump = 0;
                        ChangeState(eState.RUNNING);
                    }
                }
                break;
            case eState.DEAD:
                break;
        }
        return;
    }
}
