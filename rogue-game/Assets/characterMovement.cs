using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control the movement speed.
    public float rotationSpeed = 5f;


    private Rigidbody2D rb;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnMove(InputValue value)
    {
       
        rb.velocity = value.Get<Vector2>() * moveSpeed;

    }

    private void OnLook(InputValue value)
    {

        float angle = Mathf.Atan2(value.Get<Vector2>().y, value.Get<Vector2>().x) * Mathf.Rad2Deg;

        // Create a rotation based on the angle.
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Apply the rotation to your character.
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        if (angle != 0f)
        {

            transform.rotation = rotation;

        }

    }

    void Update()
    {
        /*
        // Get input values for horizontal and vertical movement.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction.
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Move the character based on the input and speed.
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        */
    }

}

