using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    public float speed = 15f;
    public Rigidbody rb;
    public bool isMoving = false;
    PhotonView view;
    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }

    private void Start()
    {

    }

    void Update()
    {
        if (view.IsMine)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

            if (movementDirection.magnitude > 0)
            {
                isMoving = true;
                rb.MovePosition(transform.position + movementDirection * speed * Time.deltaTime);
                playerAnim.SetBool("isMoving", true);
            }
            else
            {
                isMoving = false;
                playerAnim.SetBool("isMoving", false);
            }

            if (movementDirection.magnitude > 0)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 700f * Time.deltaTime);
            }
        }
    }
}
