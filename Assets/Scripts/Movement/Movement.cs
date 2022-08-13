using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    float MoveSpeed = 5f;

    public Rigidbody rb;

    Vector3 Inp;
    Vector3 forward;
    Vector3 right;

    private void Start()
    {
        
    }
    private void Update()
    {
        Infoo();
        Mov();
    }

    private void FixedUpdate()
    {
       
    }

    void Infoo()
    {
        Inp = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

    }

    void Mov()
    {
        rb.MovePosition(transform.position + transform.forward * MoveSpeed * Time.deltaTime);
    }
}
