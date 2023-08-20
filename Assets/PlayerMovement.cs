using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float mouseSensitivity = 10f;
    public Transform cameraTrans;

    private Vector2 move;
    private Vector2 rot;

    private Rigidbody rb;
    private Collider col;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (cameraTrans is null)
            Debug.LogError("ERROR :: No camera transform assigned to Player Movement component.");

        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(move);
    }

    private void Update()
    {
        PollInput();
        Look(rot);
    }

    private void PollInput()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        rot.x = Input.GetAxis("Mouse X");
        rot.y = Input.GetAxis("Mouse Y");
    }

    private void Move(Vector2 move)
    {
        rb.AddForce((transform.forward * move.y).normalized * moveSpeed * Time.fixedDeltaTime , ForceMode.Impulse);
        rb.AddForce((transform.right * move.x).normalized * moveSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void Look(Vector2 look)
    {
        this.transform.Rotate(new Vector3(0f, look.x, 0f));
        
        cameraTrans.Rotate(new Vector3(-look.y, 0f, 0f));
    }
}
