using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [Header("Player velocity")]
    //Ox
    public int xVelocity = 5;
    // Oy
    public int yVelocity = 8;

    //
    private Rigidbody2D rigidBody;
    //========================================
    private void Start()
    {
        // 
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    //========================================
    private void Update()
    {
        updatePlayerPosition();
    }
    //=======================================


    private void updatePlayerPosition()
    {
        // 
        float moveInput = Input.GetAxis("Horizontal");
        // 
        float jumpInput = Input.GetAxis("Jump");

        // 


        rigidBody.velocity = new Vector2(xVelocity* moveInput, rigidBody.velocity.y);

        {
            ContactPoint2D[] col;
            col = new ContactPoint2D[100];
            int i = rigidBody.GetContacts(col);
            Debug.Log(i);
            if (jumpInput > 0 && i > 0)
            { //Тип прыгает
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
            }
        }
    }
}