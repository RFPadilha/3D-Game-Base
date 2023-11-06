using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TwoDimensionalAnimationStateController : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0f;
    float velocityX = 0f;

    public float acceleration = 2f;
    public float deceleration = 2f;

    public float maxWalkVelocity = .5f;
    public float maxRunVelocity = 2f;

    int velocityZHash;
    int velocityXHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        velocityXHash = Animator.StringToHash("VelocityX");
        velocityZHash = Animator.StringToHash("VelocityZ");
    }

    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        //ternary operator = "if run is pressed, return maxRunVelocity, else return maxWalkVelocity"
        float currentMaxVelocity = runPressed ? maxRunVelocity : maxWalkVelocity;

        ChangeVelocity(forwardPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);
        ClampOrResetVelocity(forwardPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);

        animator.SetFloat(velocityXHash, velocityX);
        animator.SetFloat(velocityZHash, velocityZ);
    }
    void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {
        //Forward movement----------------------------------------------------------
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        if (!forwardPressed && velocityZ > 0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }

        //Left-Right Movement----------------------------------------------------------
        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        if (!leftPressed && velocityX < 0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }
        if (!rightPressed && velocityX > 0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }
    }

    void ClampOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {
        //Velocity Reset-------------------------------------------------------------
        if (!forwardPressed && velocityZ < 0f)
        {
            velocityZ = 0f;
        }
        if (!leftPressed && !rightPressed && velocityX != 0f && (velocityX > -.05f && velocityX < .05f))
        {
            velocityX = 0f;
        }

        //Velocity Clamping Forward--------------------------------------------------
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + .05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - .05f))
        {
            velocityZ = currentMaxVelocity;
        }

        //Velocity Clamping Left--------------------------------------------------
        if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        else if (leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - .05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + .05f))
        {
            velocityX = -currentMaxVelocity;
        }

        //Velocity Clamping Right--------------------------------------------------
        if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        else if (rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + .05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - .05f))
        {
            velocityX = currentMaxVelocity;
        }
    }
}
