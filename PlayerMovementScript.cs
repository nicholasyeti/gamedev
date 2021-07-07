using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementScript : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 3f;
    public float gravity = -9.81f;
    public float StaminaDecrease = 1f;


    Vector3 velocity;

    // ^^^ Main Movement 




    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown("left shift"))
        {
            speed = speed * 2;
        }

        if (Input.GetKeyUp("left shift"))
        {
            speed = 3f;
            StaminaDecrease = 1f;
        }




        if (Input.GetKeyDown("left shift"))
        {
            
            

        }
    }

}
