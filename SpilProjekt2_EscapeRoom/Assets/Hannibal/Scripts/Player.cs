using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform CameraTrans;
    Rigidbody rb;
    public float Speed;
    public float MouseSens;
    public float JumpForce;
    public float jumpRay;
    bool Grounded = false;
    Raycast rayScript;
    public bool SpillerDød;


    // Start is called before the first frame update
    void Start()
    {
        rayScript = GetComponentInChildren<Raycast>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //input og logik til movement
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        Vector3 newVelocity = Vector3.zero;
        newVelocity += transform.right * inputHorizontal;
        newVelocity += transform.forward * inputVertical;
        newVelocity = newVelocity.normalized * Speed;
        newVelocity.y = rb.velocity.y;
   
        //input og logik til camera
        float inputMouseX = Input.GetAxis("Mouse X");
        float inputMouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, inputMouseX * MouseSens, 0);
        CameraTrans.Rotate(-inputMouseY * MouseSens, 0, 0);
        

        // input og logik til hop
        if(Input.GetButtonDown("Jump") && Grounded)
        {
            newVelocity.y = JumpForce;
        }
        rb.velocity = newVelocity;
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down*jumpRay, Color.red);
        if(Physics.Raycast(ray, out hit, jumpRay))
        {
            Grounded = true;
            Debug.Log("Du står på jorden");
        }
        else
        {
            Grounded = false;
        }
       
    }
}
