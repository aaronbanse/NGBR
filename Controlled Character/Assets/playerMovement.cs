using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //floats
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    public float dashCooldown = 3f;
    public float dashLength = 100f;
    private float cooldownTime = 3;
    private float nextDashTime = 0;


    //updates constantly
        void Update()
        {

        //ensures that velocity resets on hitting ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
        
        //manages dash detection and cooldown
        int dashMultiplier = 1;
        if (Time.time > nextDashTime)
            if (Input.GetKeyDown("q"))
            {
                print("cooldown started");
                nextDashTime = Time.time + cooldownTime;
                dashMultiplier = ToInt32(dashLength)*20;
                print(dashMultiplier);
            }

        //moves character
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime * dashMultiplier);


        //detects jumps, performs y moves
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //converts floats to ints
    public static int ToInt32(float value)
    {
        return ToInt32((double)value);
    }

    //converts doubles to ints
    public static int ToInt32(double value)
    {
        if (value >= 0)
        {
            if (value < 2147483647.5)
            {
                int result = (int)value;
                double dif = value - result;
                if (dif > 0.5 || dif == 0.5 && (result & 1) != 0) result++;
                return result;
            }
        }
        return -1;

    }
}
