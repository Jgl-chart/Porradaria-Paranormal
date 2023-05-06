using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController characterController;

    private float speed = 12f;

    Vector3 curVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    void Start()
    {
        if(characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }

        if(speed == 0)
        {
            speed = GameManager.instance.FichaDoPlayer.Deslocamento / 15 * 20;
        }
        

    }

    public float jumpHeight = 3f;

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && curVelocity.y < 0)
        {
            curVelocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) + (transform.forward * z);

        characterController.Move(move * speed * Time.deltaTime);

        curVelocity += Physics.gravity;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            curVelocity += Mathf.Sqrt(jumpHeight) * -2 * Physics.gravity;
        }

        characterController.Move(curVelocity * Time.deltaTime * Time.deltaTime);

    }
}
