using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 12f;
    public float gravity = -5f;
    public float groundDistance = 1f;
    public bool isGrounded;
    public float jumpHeiger = 10f;

    Vector3 velocity;

    public Transform groundCheck;

    public LayerMask ground;

    CharacterController Character;

    void Start()
    {
        Character = GetComponent<CharacterController>();
    }

   
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move = transform.TransformDirection(move);
        Character.Move(move * speed * Time.deltaTime);

        Character.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeiger * -2 * gravity);
        }
    }

}
