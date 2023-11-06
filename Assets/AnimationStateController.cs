using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    float velocity = 0f;
    public float acceleration = .1f;
    public float deceleration = .5f;
    int velocityHash;
    private void Start()
    {
        animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
    }
    private void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if (forwardPressed && velocity < 1f)
        {
            velocity += Time.deltaTime * acceleration;
        }
        if(!forwardPressed && velocity > 0)
        {
            velocity -= Time.deltaTime * deceleration;
        }
        if (!forwardPressed && velocity < 0)
        {
            velocity = 0;
        }

        animator.SetFloat(velocityHash, velocity);
    }











    /*Using Booleans to control animation states
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        //Walk logic-----------------------------------------------
        if(!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if(isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
        //Run logic-----------------------------------------------
        if(!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        if(isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
    */
}
