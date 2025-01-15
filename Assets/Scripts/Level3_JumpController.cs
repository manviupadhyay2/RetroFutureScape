using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_JumpController : MonoBehaviour
{
    public float turnCalmTime = 0.1f;
    float turnCalmVelocity;
    public float jumpRange = 1f;
    Vector3 velocity;
    public Transform surfaceCheck;
    bool onSurface;
    public float gravity = -1000f;
    public float surfaceDistance = 0.4f;
    public LayerMask surfaceMask;
    public CharacterController cC;

    private void Update()
    {
        onSurface = Physics.CheckSphere(surfaceCheck.position, surfaceDistance, surfaceMask);
        if(onSurface && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        cC.Move(velocity*Time.deltaTime);

        Jump();
    }

   private void Jump()
    {
        if(Input.GetButtonDown("Jump") && onSurface)
        {
            velocity.y = Mathf.Sqrt(jumpRange * -2 * gravity);
        }
    }
}
